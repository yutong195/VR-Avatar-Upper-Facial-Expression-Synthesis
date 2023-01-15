using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Barracuda;

public class Neural_Model : MonoBehaviour
{
    public NNModel nn_model;
    private Model nn_RuntimeModel;

    private IWorker worker;

    private string outputLayerName;
    // Start is called before the first frame update
    void Start()
    {
        nn_RuntimeModel = ModelLoader.Load(nn_model);
        worker = WorkerFactory.CreateWorker(WorkerFactory.Type.Auto, nn_RuntimeModel);
        outputLayerName = nn_RuntimeModel.outputs[nn_RuntimeModel.outputs.Count - 1];
    }

    // Update is called once per frame
    public List<float> Predict(List<float> lipValueList)
    {
        List<float> eyePredValue = new List<float>();
        using Tensor inputTensor = new Tensor(1, 37);
        for(int i = 0; i < lipValueList.Count; i++)
        {
            inputTensor[i] = lipValueList[i];
        }
        worker.Execute(inputTensor);

        Tensor outputTensor = worker.PeekOutput(outputLayerName);

        inputTensor.Dispose();

        for (int i = 0; i < 15; i++)
        {
            float value = outputTensor[i];
            if(value < 0)
            {
                value = 0;
            }
            else if (value > 100)
            {
                value = 100;
            }

            eyePredValue.Add(value);
        }

        return eyePredValue;

    }
}
