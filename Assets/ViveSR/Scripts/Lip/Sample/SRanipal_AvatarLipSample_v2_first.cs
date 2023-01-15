//========= Copyright 2019, HTC Corporation. All rights reserved. ===========
using System.Collections.Generic;
using UnityEngine;


namespace ViveSR
{
    namespace anipal
    {
        namespace Lip
        {
            public class SRanipal_AvatarLipSample_v2_first : MonoBehaviour
            {
                public bool startEye;
                public bool exagEyeMove;
                public bool reduceEyeMove;
                public bool exagMouthMove;
                public bool reduceMouthMove;
                public float exagEyeFactor;
                public float reduceEyeFactor;
                public float exagMouthFactor;
                public float reduceMouthFactor;
                public Neural_Model model;
                [SerializeField] private List<LipShapeTable_v2> LipShapeTables;
                

                public bool NeededToGetData = true;
                private Dictionary<LipShape_v2, float> LipWeightings;
                //public static float[] lipBlendShapesArray = new float[37];
                List<float> lipValueList = new List<float>();

                private void Start()
                { 
                    if (!SRanipal_Lip_Framework.Instance.EnableLip)
                    {
                        enabled = false;
                        return;
                    }
                    SetLipShapeTables(LipShapeTables);
                }

                private void Update()
                {
                    if (SRanipal_Lip_Framework.Status != SRanipal_Lip_Framework.FrameworkStatus.WORKING) return;

                    if (NeededToGetData)
                    {
                        SRanipal_Lip_v2.GetLipWeightings(out LipWeightings);
                        UpdateLipShapes(LipWeightings);
                    }

                    //Debug.Log(lipBlendShapesArray.GetLength(0));
                    //Debug.Log(lipValueList.Count);
                }

                public void SetLipShapeTables(List<LipShapeTable_v2> lipShapeTables)
                {
                    bool valid = true;
                    if (lipShapeTables == null)
                    {
                        valid = false;
                    }
                    else
                    {
                        for (int table = 0; table < lipShapeTables.Count; ++table)
                        {
                            if (lipShapeTables[table].skinnedMeshRenderer == null)
                            {
                                valid = false;
                                break;
                            }
                            for (int shape = 0; shape < lipShapeTables[table].lipShapes.Length; ++shape)
                            {
                                LipShape_v2 lipShape = lipShapeTables[table].lipShapes[shape];
                                if (lipShape > LipShape_v2.Max || lipShape < 0)
                                {
                                    valid = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (valid)
                        LipShapeTables = lipShapeTables;
                }

                public void UpdateLipShapes(Dictionary<LipShape_v2, float> lipWeightings)
                {
                    foreach (var table in LipShapeTables)
                        RenderModelLipShape(table, lipWeightings);
                }

                private void RenderModelLipShape(LipShapeTable_v2 lipShapeTable, Dictionary<LipShape_v2, float> weighting)
                {
                    List<float> lipValueList = new List<float>();
                    List<float> eyePredValue = new List<float>();
                    for (int i = 0; i < lipShapeTable.lipShapes.Length; i++)
                    {
                        int targetIndex = (int)lipShapeTable.lipShapes[i];
                        if (targetIndex >= (int)LipShape_v2.Max || targetIndex < 0) continue;
                        //if (targetIndex > 51 || targetIndex < 0) continue;
                        lipValueList.Add(weighting[(LipShape_v2)targetIndex] * 100);
                        if (exagMouthMove)
                        {
                            if(weighting[(LipShape_v2)targetIndex] * 100*exagMouthFactor>100)
                            {
                                float m;
                                m = weighting[(LipShape_v2)targetIndex] * 100 * exagMouthFactor;
                                m = 100/m;
                                lipShapeTable.skinnedMeshRenderer.SetBlendShapeWeight(i, weighting[(LipShape_v2)targetIndex] * 100*exagMouthFactor*m);
                            }
                        }

                        else if(reduceMouthMove)
                        {
                            lipShapeTable.skinnedMeshRenderer.SetBlendShapeWeight(i, weighting[(LipShape_v2)targetIndex] * 100 * reduceMouthFactor);
                        }

                        else if((!exagMouthMove)&(!reduceMouthMove))
                        {
                            lipShapeTable.skinnedMeshRenderer.SetBlendShapeWeight(i, weighting[(LipShape_v2)targetIndex] * 100);
                        }
                        
                        //Debug.Log(lipShapeTable.lipShapes.Length);
                        //if((targetIndex>=0 & targetIndex<26))
                        {
                            //if(targetIndex>=0 & targetIndex<26)
                            //{
                            //lipBlendShapesArray[targetIndex] = weighting[(LipShape_v2)targetIndex] * 100;

                            //}

                            //else
                            //{
                            //lipBlendShapesArray[targetIndex-15] = weighting[(LipShape_v2)targetIndex] * 100;
                            //}
                            //lipValueList.Add(weighting[(LipShape_v2)targetIndex] * 100);
                        }

                        //else if((targetIndex >= 41 & targetIndex < 52))
                        {
                            //lipValueList.Add(weighting[(LipShape_v2)targetIndex] * 100);
                        }
                        

                    }
                    //The lipValueList contains all the blendshape values of the facial tracker!!!!!! This lipValueListcan directly put into the nerual network model!!!!!
                    if(startEye)
                    {
                        eyePredValue = model.Predict(lipValueList);

                        if(exagEyeMove)
                        {
                            for (int j = 0; j < 15; j++)
                            {
                                if(eyePredValue[j]*exagEyeFactor>100)
                                {
                                    float n;
                                    n = eyePredValue[j] * exagEyeFactor;
                                    n = 100f;
                                    lipShapeTable.skinnedMeshRenderer.SetBlendShapeWeight(j + 26, n);
                                    continue;
                                }
                                lipShapeTable.skinnedMeshRenderer.SetBlendShapeWeight(j + 26, eyePredValue[j]*exagEyeFactor);
                            }
                        }

                        else if(reduceEyeMove)
                        {
                            for (int j = 0; j < 15; j++)
                            {
                                lipShapeTable.skinnedMeshRenderer.SetBlendShapeWeight(j + 26, eyePredValue[j] * reduceEyeFactor);
                            }
                        }

                        else if((!exagEyeMove)&(!reduceEyeMove))
                        {
                            for (int j = 0; j < 15; j++)
                            {
                                lipShapeTable.skinnedMeshRenderer.SetBlendShapeWeight(j + 26, eyePredValue[j]);
                            }
                        }
                    }
                    
                    //write here
                    //Debug.Log(lipValueList.Count);
                   
                }
            }
        }
    }
}