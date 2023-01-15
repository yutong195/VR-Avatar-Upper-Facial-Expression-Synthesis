using System.Diagnostics;
using System.Xml.Schema;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
// using UnityEngine.CoreModule;

public class Animation_control_revised : NetworkBehaviour
{
    //Test functions to learn about sync with cloth on and off//
    public GameObject Cloth;
    public bool cloth_is_on;
    public List<bool> cloth_is_on_list;
    //=====================================//

    //Test Single Shape key//
    public float First_shape_keys;
    public float _2_shape_keys;
    //=====================================//
    public GameObject Face;
    public readonly SyncList<float> sync_lists = new SyncList<float>();
    public List<float> local_shape_keys = new List<float>();
    [SerializeField] private int sync_list_number;


    private Mesh Face_shapes;
    private int shape_shape_number;
    private SkinnedMeshRenderer Face_render;
    public float Head_rotation;
    [SerializeField] private float shape_key_1;


    public override void OnStartLocalPlayer()
    {
        //Camera.main.enabled = true;
        //Camera.main.transform.SetParent(transform);
        //UnityEngine.Debug.Log("Local player name"+name);
        //if(name =="ManAvatar_2(Clone)"){
            //Camera.main.transform.localPosition = new Vector3(0.63f, 1.787f, 0.269f);
        //}else if(name =="WomenAvatar_3(Clone)"){
            //Camera.main.transform.localPosition = new Vector3(0, 1.65f, 0.06f);
            //Camera.main.transform.localRotation = new Quaternion(0, 360, 0.06f,0);
        //}

        Face_shapes = Face.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        Face_render = Face.GetComponent<SkinnedMeshRenderer>();
        shape_shape_number = Face_shapes.blendShapeCount;
        sync_list_number = sync_lists.Count;
        shape_key_1 = 0;
        init_local_shape_keys(Face_render);
        Cmdinitshapekeys(local_shape_keys);
        //----------------------------Update Synclist trying start----------------------//
        // sync_lists.Callback += Onsync_listsUpdated;
        // // Process initial SyncList payload
        // for (int index = 0; index < sync_lists.Count; index++)
        //     Onsync_listsUpdated(SyncList<float>.Operation.OP_ADD, index, new float(), sync_lists[index]);
        // //----------------------------Update Synclist trying end----------------------//        

        // CmdInit();
    }

    // void Onsync_listsUpdated(SyncList<float>.Operation op, int index, float oldItem, float newItem)
    // {
    //     switch (op)
    //     {
    //         case SyncList<float>.Operation.OP_ADD:

    //             // index is where it was added into the list
    //             // newItem is the new item
    //             break;
    //         case SyncList<float>.Operation.OP_INSERT:
    //             // index is where it was inserted into the list
    //             // newItem is the new item
    //             break;
    //         case SyncList<float>.Operation.OP_REMOVEAT:
    //             // index is where it was removed from the list
    //             // oldItem is the item that was removed
    //             break;
    //         case SyncList<float>.Operation.OP_SET:
    //             // index is of the item that was changed
    //             // oldItem is the previous value for the item at the index
    //             // newItem is the new value for the item at the index
    //             break;
    //         case SyncList<float>.Operation.OP_CLEAR:
    //             // list got cleared
    //             break;
    //     }
    // }


    [SyncVar(hook = nameof(SetCloth))]
    public bool _cloth_is_on=true;
    void SetCloth(System.Boolean _Old, System.Boolean _New){
        _cloth_is_on = _New;
        Cloth.SetActive(_cloth_is_on);
    }    

    [SyncVar(hook = nameof(Set_first_shape))]
    public float _First_shape_keys;
    void Set_first_shape(float _Old, float _New){
        _First_shape_keys = _New;
        Face_render.SetBlendShapeWeight(0, _First_shape_keys);
    }
    [SyncVar(hook = nameof(Set_second_shape))]
    public float _Second_shape_keys;
    void Set_second_shape(float _Old, float _New){
        _Second_shape_keys = _New;
        Face_render.SetBlendShapeWeight(1, _Second_shape_keys);
    }

    [SyncVar(hook = nameof(Set_third_shape))]
    public float _3_shape_keys;
    void Set_third_shape(float _Old, float _New){
        if(_New !=_Old){
            _3_shape_keys = _New;
            Face_render.SetBlendShapeWeight(2, _3_shape_keys);
        }
    }

    [SyncVar(hook = nameof(Set_4_shape))]
    public float _4_shape_keys;
    void Set_4_shape(float _Old, float _New){
        _4_shape_keys = _New;
        Face_render.SetBlendShapeWeight(3, _4_shape_keys);
    }

    [SyncVar(hook = nameof(Set_5_shape))]
    public float _5_shape_keys;
    void Set_5_shape(float _Old, float _New){
        _5_shape_keys = _New;
        Face_render.SetBlendShapeWeight(4, _5_shape_keys);
    }

    [SyncVar(hook = nameof(Set_6_shape))]
    public float _6_shape_keys;
    void Set_6_shape(float _Old, float _New){
        _6_shape_keys = _New;
        Face_render.SetBlendShapeWeight(5, _6_shape_keys);
    }

    [SyncVar(hook = nameof(Set_7_shape))]
    public float _7_shape_keys;
    void Set_7_shape(float _Old, float _New){
        _7_shape_keys = _New;
        Face_render.SetBlendShapeWeight(6, _7_shape_keys);
    }

    [SyncVar(hook = nameof(Set_8_shape))]
    public float _8_shape_keys;
    void Set_8_shape(float _Old, float _New){
        _8_shape_keys = _New;
        Face_render.SetBlendShapeWeight(7, _8_shape_keys);
    }

    [SyncVar(hook = nameof(Set_9_shape))]
    public float _9_shape_keys;
    void Set_9_shape(float _Old, float _New){
        _9_shape_keys = _New;
        Face_render.SetBlendShapeWeight(8, _9_shape_keys);
    }

    [SyncVar(hook = nameof(Set_10_shape))]
    public float _10_shape_keys;
    void Set_10_shape(float _Old, float _New){
        _10_shape_keys = _New;
        Face_render.SetBlendShapeWeight(9, _10_shape_keys  );
    }

    [SyncVar(hook = nameof(Set_11_shape))]
    public float _11_shape_keys;
    void Set_11_shape(float _Old, float _New){
        _11_shape_keys = _New;
        Face_render.SetBlendShapeWeight(10, _11_shape_keys);
    }

    [SyncVar(hook = nameof(Set_12_shape))]
    public float _12_shape_keys;
    void Set_12_shape(float _Old, float _New){
        _12_shape_keys = _New;
        Face_render.SetBlendShapeWeight(11, _12_shape_keys);
    }

        [SyncVar(hook = nameof(Set_13_shape))]
    public float _13_shape_keys;
    void Set_13_shape(float _Old, float _New){
        _13_shape_keys = _New;
        Face_render.SetBlendShapeWeight(12, _13_shape_keys);
    }
    [SyncVar(hook = nameof(Set_14_shape))]
    public float _14_shape_keys;
    void Set_14_shape(float _Old, float _New){
        _14_shape_keys = _New;
        Face_render.SetBlendShapeWeight(13, _14_shape_keys);
    }
    [SyncVar(hook = nameof(Set_15_shape))]
    public float _15_shape_keys;
    void Set_15_shape(float _Old, float _New){
        _15_shape_keys = _New;
        Face_render.SetBlendShapeWeight(14, _15_shape_keys);
    }
    [SyncVar(hook = nameof(Set_16_shape))]
    public float _16_shape_keys;
    void Set_16_shape(float _Old, float _New){
        if(_New!=_Old){
            _16_shape_keys = _New;
            Face_render.SetBlendShapeWeight(15, _16_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_17_shape))]
    public float _17_shape_keys;
    void Set_17_shape(float _Old, float _New){
        if(_New!=_Old){
            _17_shape_keys = _New;
            Face_render.SetBlendShapeWeight(16, _17_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_18_shape))]
    public float _18_shape_keys;
    void Set_18_shape(float _Old, float _New){
        if(_New!=_Old){
            _18_shape_keys = _New;
            Face_render.SetBlendShapeWeight(17, _18_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_19_shape))]
    public float _19_shape_keys;
    void Set_19_shape(float _Old, float _New){
        if(_New!=_Old){
            _19_shape_keys = _New;
            Face_render.SetBlendShapeWeight(18, _19_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_20_shape))]
    public float _20_shape_keys;
    void Set_20_shape(float _Old, float _New){
        if(_New!=_Old){
            _20_shape_keys = _New;
            Face_render.SetBlendShapeWeight(19, _20_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_21_shape))]
    public float _21_shape_keys;
    void Set_21_shape(float _Old, float _New){
        if(_New!=_Old){
            _21_shape_keys = _New;
            Face_render.SetBlendShapeWeight(20, _21_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_22_shape))]
    public float _22_shape_keys;
    void Set_22_shape(float _Old, float _New){
        if(_New!=_Old){
            _22_shape_keys = _New;
            Face_render.SetBlendShapeWeight(21,_22_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_23_shape))]
    public float _23_shape_keys;
    void Set_23_shape(float _Old, float _New){
        if(_New!=_Old){
            _23_shape_keys = _New;
            Face_render.SetBlendShapeWeight(22,_23_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_24_shape))]
    public float _24_shape_keys;
    void Set_24_shape(float _Old, float _New){
        if(_New!=_Old){
            _24_shape_keys = _New;
            Face_render.SetBlendShapeWeight(23,_24_shape_keys);
        }
    }

    [SyncVar(hook = nameof(Set_25_shape))]
    public float _25_shape_keys;
    void Set_25_shape(float _Old, float _New){
        if(_New!=_Old){
            _25_shape_keys = _New;
            Face_render.SetBlendShapeWeight(24,_25_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_26_shape))]
    public float _26_shape_keys;
    void Set_26_shape(float _Old, float _New){
        if(_New!=_Old){
            _26_shape_keys = _New;
            Face_render.SetBlendShapeWeight(25,_26_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_27_shape))]
    public float _27_shape_keys;
    void Set_27_shape(float _Old, float _New){
        if(_New!=_Old){
            _27_shape_keys = _New;
            Face_render.SetBlendShapeWeight(26,_27_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_28_shape))]
    public float _28_shape_keys;
    void Set_28_shape(float _Old, float _New){
        if(_New!=_Old){
            _28_shape_keys = _New;
            Face_render.SetBlendShapeWeight(27,_28_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_29_shape))]
    public float _29_shape_keys;
    void Set_29_shape(float _Old, float _New){
        if(_New!=_Old){
            _29_shape_keys = _New;
            Face_render.SetBlendShapeWeight(28,_29_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_30_shape))]
    public float _30_shape_keys;
    void Set_30_shape(float _Old, float _New){
        if(_New!=_Old){
            _30_shape_keys = _New;
            Face_render.SetBlendShapeWeight(29,_30_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_31_shape))]
    public float _31_shape_keys;
    void Set_31_shape(float _Old, float _New){
        if(_New!=_Old){
            _31_shape_keys = _New;
            Face_render.SetBlendShapeWeight(30,_31_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_32_shape))]
    public float _32_shape_keys;
    void Set_32_shape(float _Old, float _New){
        if(_New!=_Old){
            _32_shape_keys = _New;
            Face_render.SetBlendShapeWeight(31,_32_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_33_shape))]
    public float _33_shape_keys;
    void Set_33_shape(float _Old, float _New){
        if(_New!=_Old){
            _33_shape_keys = _New;
            Face_render.SetBlendShapeWeight(32,_33_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_34_shape))]
    public float _34_shape_keys;
    void Set_34_shape(float _Old, float _New){
        if(_New!=_Old){
            _34_shape_keys = _New;
            Face_render.SetBlendShapeWeight(33,_34_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_35_shape))]
    public float _35_shape_keys;
    void Set_35_shape(float _Old, float _New){
        if(_New!=_Old){
            _35_shape_keys = _New;
            Face_render.SetBlendShapeWeight(34,_35_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_36_shape))]
    public float _36_shape_keys;
    void Set_36_shape(float _Old, float _New){
        if(_New!=_Old){
            _36_shape_keys = _New;
            Face_render.SetBlendShapeWeight(35,_36_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_37_shape))]
    public float _37_shape_keys;
    void Set_37_shape(float _Old, float _New){
        if(_New!=_Old){
            _37_shape_keys = _New;
            Face_render.SetBlendShapeWeight(36,_37_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_38_shape))]
    public float _38_shape_keys;
    void Set_38_shape(float _Old, float _New){
        if(_New!=_Old){
            _38_shape_keys = _New;
            Face_render.SetBlendShapeWeight(37,_38_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_39_shape))]
    public float _39_shape_keys;
    void Set_39_shape(float _Old, float _New){
        if(_New!=_Old){
            _39_shape_keys = _New;
            Face_render.SetBlendShapeWeight(38,_39_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_40_shape))]
    public float _40_shape_keys;
    void Set_40_shape(float _Old, float _New){
        if(_New!=_Old){
            _40_shape_keys = _New;
            Face_render.SetBlendShapeWeight(39,_40_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_41_shape))]
    public float _41_shape_keys;
    void Set_41_shape(float _Old, float _New){
        if(_New!=_Old){
            _41_shape_keys = _New;
            Face_render.SetBlendShapeWeight(40,_41_shape_keys);
        }
    }
    [SyncVar(hook = nameof(Set_42_shape))]
    public float _42_shape_keys;
    void Set_42_shape(float _Old, float _New){
        if(_New!=_Old){
            _42_shape_keys = _New;
            Face_render.SetBlendShapeWeight(41,_42_shape_keys);
        }
    }

    [SyncVar(hook = nameof(Set_Head_Rotation_y))]
    public float head_rotation_y;
    void Set_Head_Rotation_y(float _Old, float _New)
    {
        if(_New!=_Old)
        {
            head_rotation_y = _New;
            Face.gameObject.transform.eulerAngles = new Vector3(0, head_rotation_y, 0);
        }
    }



    void Start(){
        cloth_is_on = Cloth.activeSelf;
        cloth_is_on_list.Add(cloth_is_on);
        Face_shapes = Face.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        Face_render = Face.GetComponent<SkinnedMeshRenderer>();
        First_shape_keys = Face_render.GetBlendShapeWeight(0);
        _2_shape_keys = Face_render.GetBlendShapeWeight(1);

        // init_local_shape_keys(Face_render);
        // Cmdinitshapekeys(local_shape_keys);
    }

    void Update()
    { 
        if (!isLocalPlayer)
        { 
            return; 
        }
            // cloth_is_on = Cloth.activeSelf;
        cloth_is_on_list[0] = Cloth.activeSelf;
        Cmdchangecloth(cloth_is_on_list);
            // Try to set the first shape key value//
        First_shape_keys = Face_render.GetBlendShapeWeight(0);
        _2_shape_keys = Face_render.GetBlendShapeWeight(1);

        Head_rotation = Face.gameObject.transform.eulerAngles.y;
        Cmdupdateheadrotation_y(Head_rotation);


        //------------------------------------------------//
        // Face_shapes = Face.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        // Face_render = Face.GetComponent<SkinnedMeshRenderer>();       
        // CmdUpdate();
        // Cloth.SetActive(_cloth_is_on);
        // write_blendshapes(Face_render,sync_lists);
        update_shape_keys(Face_render);
        Cmdchangefirstshapekey(First_shape_keys);
        Cmdchangesecondshapekey(local_shape_keys[1]);
        Cmdchangeshapekey3(local_shape_keys[2]);
        Cmdchangeshapekey4(local_shape_keys[3]);
        Cmdchangeshapekey5(local_shape_keys[4]);
        Cmdchangeshapekey6(local_shape_keys[5]);
        Cmdchangeshapekey7(local_shape_keys[6]);
        Cmdchangeshapekey8(local_shape_keys[7]);      
        Cmdchangeshapekey9(local_shape_keys[8]);  
        Cmdchangeshapekey10(local_shape_keys[9]);
        Cmdchangeshapekey11(local_shape_keys[10]);  
        Cmdchangeshapekey12(local_shape_keys[11]);
        Cmdchangeshapekey13(local_shape_keys[12]);
        Cmdchangeshapekey14(local_shape_keys[13]);
        Cmdchangeshapekey15(local_shape_keys[14]);
        Cmdchangeshapekey16(local_shape_keys[15]);
        Cmdchangeshapekey17(local_shape_keys[16]);
        Cmdchangeshapekey18(local_shape_keys[17]);
        Cmdchangeshapekey19(local_shape_keys[18]);
        Cmdchangeshapekey20(local_shape_keys[19]);
        Cmdchangeshapekey21(local_shape_keys[20]);
        Cmdchangeshapekey22(local_shape_keys[21]);
        Cmdchangeshapekey23(local_shape_keys[22]);
        Cmdchangeshapekey24(local_shape_keys[23]);
        Cmdchangeshapekey25(local_shape_keys[24]);  
        Cmdchangeshapekey26(local_shape_keys[25]);
        Cmdchangeshapekey27(local_shape_keys[26]);
        Cmdchangeshapekey28(local_shape_keys[27]);
        Cmdchangeshapekey29(local_shape_keys[28]);
        Cmdchangeshapekey30(local_shape_keys[29]);
        Cmdchangeshapekey31(local_shape_keys[30]);
        Cmdchangeshapekey32(local_shape_keys[31]);
        Cmdchangeshapekey33(local_shape_keys[32]);
        Cmdchangeshapekey34(local_shape_keys[33]);
        Cmdchangeshapekey35(local_shape_keys[34]);
        Cmdchangeshapekey36(local_shape_keys[35]);
        Cmdchangeshapekey37(local_shape_keys[36]);
        Cmdchangeshapekey38(local_shape_keys[37]);
        Cmdchangeshapekey39(local_shape_keys[38]);
        Cmdchangeshapekey40(local_shape_keys[39]);
        Cmdchangeshapekey41(local_shape_keys[40]);
        Cmdchangeshapekey42(local_shape_keys[41]);
        
            // Cmdchangethirdhapekey(local_shape_keys[2]);


        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 110.0f;
        float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * 4f;

        transform.Rotate(0, moveX, 0);
        transform.Translate(0, 0, moveZ);
    }

// ------------------------These are functions that I tried to test networking sync lists-------------------------------------.//
    // [Command]
    // public void CmdInitTest(){
    //     sync_lists_test_easy.Add(2);
    //     sync_lists_test_easy.Add(3);
    //     sync_lists_test_easy.Add(4);
    // }
    // [Command]  
    // public void CmdUpdateTest(){
    //     sync_lists_test_easy[0] = 5;
    // }

// ------------------------These are functions that I tried to test the list read and write-------------------------------------.//
    [Command] 
    public void Cmdchangecloth(List<bool> list){
        _cloth_is_on = list[0];
        Cloth.SetActive(_cloth_is_on);
    }

    [Command] 
    public void Cmdchangefirstshapekey(float shapekey){
        _First_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(0, _First_shape_keys);
    }

    [Command] 
    public void Cmdchangesecondshapekey(float shapekey){
        _Second_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(1, _Second_shape_keys);
    }

    [Command] 
    public void Cmdchangeshapekey3(float shapekey){
        _3_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(2, _3_shape_keys);
    }

    [Command] 
    public void Cmdchangeshapekey4(float shapekey){
        _4_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(3, _4_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey5(float shapekey){
        _5_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(4, _5_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey6(float shapekey){
        _6_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(5, _6_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey7(float shapekey){
        _7_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(6, _7_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey8(float shapekey){
        _8_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(7, _8_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey9(float shapekey){
        _9_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(8, _9_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey10(float shapekey){
        _10_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(9, _10_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey11(float shapekey){
        _11_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(10, _11_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey12(float shapekey){
        _12_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(11, _12_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey13(float shapekey){
        _13_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(12, _13_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey14(float shapekey){
        _14_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(13, _14_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey15(float shapekey){
        _15_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(14, _15_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey16(float shapekey){
        _16_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(15, _16_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey17(float shapekey){
        _17_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(16, _17_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey18(float shapekey){
        _18_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(17, _18_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey19(float shapekey){
        _19_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(18, _19_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey20(float shapekey){
        _20_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(19, _20_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey21(float shapekey){
        _21_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(20, _21_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey22(float shapekey){
        _22_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(21, _22_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey23(float shapekey){
        _23_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(22, _23_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey24(float shapekey){
        _24_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(23, _24_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey25(float shapekey){
        _25_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(24, _25_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey26(float shapekey){
        _26_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(25, _26_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey27(float shapekey){
        _27_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(26, _27_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey28(float shapekey){
        _28_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(27, _28_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey29(float shapekey){
        _29_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(28, _29_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey30(float shapekey){
        _30_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(29, _30_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey31(float shapekey){
        _31_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(30, _31_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey32(float shapekey){
        _32_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(31, _32_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey33(float shapekey){
        _33_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(32, _33_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey34(float shapekey){
        _34_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(33, _34_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey35(float shapekey){
        _35_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(34, _35_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey36(float shapekey){
        _36_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(35, _36_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey37(float shapekey){
        _37_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(36, _37_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey38(float shapekey){
        _38_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(37, _38_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey39(float shapekey){
        _39_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(38, _39_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey40(float shapekey){
        _40_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(39, _40_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey41(float shapekey){
        _41_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(40, _41_shape_keys);
    }
    [Command] 
    public void Cmdchangeshapekey42(float shapekey){
        _42_shape_keys = shapekey;
        Face_render.SetBlendShapeWeight(41, _42_shape_keys);
    }

    [Command] 
    public void Cmdinitshapekeys(List<float> list){
        for(int i = 0; i<local_shape_keys.Count; i++){
            sync_lists.Add(list[i]);
        }
    }

    [Command] 
    public void Cmdupdateshapekeys(List<float> list){
        for(int i = 0; i<local_shape_keys.Count; i++){
            sync_lists[i] = list[i];
        }
    }

    [Command]
    public void Cmdupdateheadrotation_y(float y_value)
    {
        head_rotation_y = y_value;
        Face.gameObject.transform.eulerAngles = new Vector3(0, head_rotation_y, 0);
    }

// ------------------------These are functions that I tried to test the shape keys-------------------------------------.//
    [Command]
    public void CmdInit(List<float> local_shape_keys){
        if(sync_list_number == 0){
            for(int i = 0; i<shape_shape_number; i++){
            sync_lists.Add(local_shape_keys[i]);
            if(i == 1){
                UnityEngine.Debug.Log("Init the shape keys"+Face_shapes.GetBlendShapeName(1)+"Value"+sync_lists[1]);
            }      
            }
        }
    }

    [Command]
    public void CmdUpdate(List<float> local_shape_keys){
        for(int i = 0; i<shape_shape_number; i++){
            // if(sync_lists[i]!= Face_render.GetBlendShapeWeight(i)){
            sync_lists[i] = local_shape_keys[i];
            float shape_key = sync_lists[i];
            if(i == 3){
                UnityEngine.Debug.Log("Shape keys"+" "+i+" "+shape_key);
            }

            Face_render.SetBlendShapeWeight(i, shape_key);
            // if(i == 1){
            //     Debug.Log("See whether the value changed"+Face_shapes.GetBlendShapeName(1)+"Value"+sync_lists[1]);
            // }
        }
        // write_blendshapes(Face_render,sync_lists);

    }

    void init_local_shape_keys(SkinnedMeshRenderer Face_rend){
        for(int i = 0; i<shape_shape_number; i++){
            local_shape_keys.Add(Face_rend.GetBlendShapeWeight(i));
        }
    }

    void update_shape_keys(SkinnedMeshRenderer Face_rend){
        for(int i = 0; i<shape_shape_number; i++){
            local_shape_keys[i] = Face_rend.GetBlendShapeWeight(i);
        }
    }



    void write_blendshapes(SkinnedMeshRenderer Face_rend,SyncList<float> lists){
        // if(sync_list_number == 0){
        //     return;
        // }
        // Face_shapes = Face.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        // Face_render = Face.GetComponent<SkinnedMeshRenderer>();
        for(int i = 0; i<shape_shape_number; i++){
            Face_rend.SetBlendShapeWeight(i, lists[i]);
        }
    }

    // void read_local_lists(){
    //     if()
    // }

}
