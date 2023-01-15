using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;



namespace ViveSR
{
    namespace anipal
    {
        namespace Eye
        {
            public class DisableEye : NetworkBehaviour
            {
                // Start is called before the first frame update
                void Start()
                {
                    if (!isLocalPlayer)
                    {
                        this.gameObject.GetComponent<SRanipal_AvatarEyeSample_v2>().enabled = false;
                    }
                }

                // Update is called once per frame
                void Update()
                {
                    if (!isLocalPlayer)
                    {
                        this.gameObject.GetComponent<SRanipal_AvatarEyeSample_v2>().enabled = false;
                    }
                }
            }
        }
    }
}
