using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Valve.VR
{
    public class DisableBody : NetworkBehaviour
    {
        public GameObject head;
        public GameObject view;
        public GameObject pivot;
        public GameObject Eye_Left;
        public GameObject Eye_Right;
        // Start is called before the first frame update
        void Start()
        {

            if (!isLocalPlayer)
            {
                head.GetComponent<HeadMoveTest>().enabled = false;
                view.SetActive(false);
                pivot.SetActive(false);
                Eye_Left.transform.eulerAngles = new Vector3(0, 0, 0);
                Eye_Right.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            else
            {
                Eye_Left.transform.eulerAngles = new Vector3(0, 0, 0);
                Eye_Right.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!isLocalPlayer)
            {
                head.GetComponent<HeadMoveTest>().enabled = false;
                view.SetActive(false);
                pivot.SetActive(false);

            }
        }
    }
}
    