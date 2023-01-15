using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


public class Systemio : NetworkBehaviour
{
    // public Animation_control Animation_control;
    private List <string> Slider_values = new List<string>();
    public GameObject Face;
    private int shape_shape_number;
    private SkinnedMeshRenderer Face_render;
    private Mesh Face_shapes;
    public List <string> report_head = new List<string>();
    public  List <string> Value = new List<string>();
    public bool start_record = false;
    // public bool submitted =false;
    void Start()
    {
        if (!isLocalPlayer) { 
                return; }
        Face_shapes = Face.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        Face_render = Face.GetComponent<SkinnedMeshRenderer>();
        shape_shape_number = Face_shapes.blendShapeCount;
        init_header(Face_shapes);
        CSVManager.AppendToReport(report_head.ToArray());
        init_all_values(Face_render);
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        if (!isLocalPlayer) { 
                return; }
        if(start_record == true){
            submit();
        }

    }

    void init_header(Mesh Face_shapes){
        for(int i = 0; i<52; i++){
            report_head.Add(Face_shapes.GetBlendShapeName(i));
        }
        //report_head.Add("Rotation");
    }

    void submit(){
        update_all_values(Face_render);
        string[] values = Value.ToArray();
        // Debug.Log("Values");
        // Debug.Log(values);
        CSVManager.AppendToReport(values);
        // EditorApplication.Beep();
        //Debug.Log("<color=green>Report updated successfully!</color>");
        // restart_the_Questionnaire();
        // Slider_values = new List<string>();
        // Choice = "";
        // Questionnaires.SetActive(false);
        // submitted = true;
    }

    void init_all_values(SkinnedMeshRenderer Face_render){
        for(int i = 0; i<52; i++){
            Value.Add(Face_render.GetBlendShapeWeight(i).ToString());
        }
        //Value.Add(Face.transform.eulerAngles.y.ToString());
        // Slider_values.Add(Animation_control.current_animation);
        // Debug.Log("Test_animations_name"+Animation_control.Current.name);
        // Slider_values.Add(Animation_control.Current.name);
    }
    void update_all_values(SkinnedMeshRenderer Face_render){
        for(int i = 0; i<52; i++){
            Value[i] = Face_render.GetBlendShapeWeight(i).ToString();
        }
        //Value[4]= Face.transform.eulerAngles.y.ToString();
        // Slider_values.Add(Animation_control.current_animation);
        // Debug.Log("Test_animations_name"+Animation_control.Current.name);
        // Slider_values.Add(Animation_control.Current.name);
    }
}
