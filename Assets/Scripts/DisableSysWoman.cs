using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DisableSysWoman : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            this.gameObject.GetComponent<Systemiowoman>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            this.gameObject.GetComponent<Systemiowoman>().enabled = false;
        }
    }
}
