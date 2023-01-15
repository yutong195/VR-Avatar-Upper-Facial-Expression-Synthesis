using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;



namespace ViveSR
{
    namespace anipal
    {
        namespace Lip
        {
            public class DisableLip : NetworkBehaviour
            {
                // Start is called before the first frame update
                void Start()
                {
                    if(!isLocalPlayer)
                    {
                        this.gameObject.GetComponent<SRanipal_AvatarLipSample_v2_first>().enabled = false;
                    }
                }

                // Update is called once per frame
                void Update()
                {
                    if (!isLocalPlayer)
                    {
                        this.gameObject.GetComponent<SRanipal_AvatarLipSample_v2_first>().enabled = false;
                    }
                }
            }
        }
    }
}
