using UnityEngine;
using System.Collections;
using Unity.Mathematics;


namespace Valve.VR
{
	public class HeadMoveTest : MonoBehaviour
	{
		private float position_x;
		private float position_y;
		private float position_z;
		private float rotation_x;
		private float rotation_y;
		private float rotation_z;
		private float rotation_w;
		private bool headMove;
		private float remember_rotation_x;
		private float remember_rotation_y;
		private float remember_rotation_z;
		private float remember_rotation_w;
		private float upperBodyOffset;
		//public pivot pivot;
		public GameObject pivot;
		public GameObject head;
		//public GameObject upperBody;

		void Start()
		{

			//if (pivot.gameObject.GetComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>() == null)
			//{
			//pivot.gameObject.AddComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>();
			//}
			position_x = pivot.gameObject.transform.position.x;
			position_y = pivot.gameObject.transform.position.y;
			position_z = pivot.gameObject.transform.position.z;
			//pivot = head.gameObject.GetComponentInParent<pivot>().gameObject;
			//pivot.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);

		}
		private void Update()
		{
			
			//pivot.gameObject.transform.position = new Vector3(position_x, position_y, position_z);
			rotation_x = WrapAngle(pivot.gameObject.transform.rotation.eulerAngles.x) / 300;
			//rotation_y = WrapAngle(pivot.gameObject.transform.eulerAngles.y) / 8;
			rotation_z = WrapAngle(pivot.gameObject.transform.rotation.eulerAngles.z) / 300;
			rotation_y = pivot.gameObject.transform.eulerAngles.y - 180;
			//upperBodyOffset = Mathf.Abs(upperBody.gameObject.transform.eulerAngles.y);


			head.gameObject.transform.eulerAngles = new Vector3(0, pivot.gameObject.transform.eulerAngles.y, 0);
			//if(upperBodyOffset <= 90)
			//{
			//if((pivot.gameObject.transform.eulerAngles.y <= (90 + upperBodyOffset)) & (pivot.gameObject.transform.eulerAngles.y >= (270 + upperBodyOffset)))
			//{
			//head.gameObject.transform.eulerAngles = new Vector3(0, pivot.gameObject.transform.eulerAngles.y, 0);
			//}
			//else if(pivot.gameObject.transform.eulerAngles.y > (90 + upperBodyOffset))
			//{
			//head.gameObject.transform.eulerAngles = new Vector3(0, 90+upperBodyOffset, 0);
			//}
			//else
			//{
			//head.gameObject.transform.eulerAngles = new Vector3(0, 270 + upperBodyOffset, 0);
			//}

			//}

			//else
			//{
			//if((pivot.gameObject.transform.eulerAngles.y <= (90 + upperBodyOffset)) & (pivot.gameObject.transform.eulerAngles.y >= (upperBodyOffset-90)))
			//{
			//head.gameObject.transform.eulerAngles = new Vector3(0, pivot.gameObject.transform.eulerAngles.y, 0);
			//}
			//else if(pivot.gameObject.transform.eulerAngles.y > upperBodyOffset+90)
			//{
			//head.gameObject.transform.eulerAngles = new Vector3(0, 90 + upperBodyOffset, 0);
			//}
			//else
			//{
			//head.gameObject.transform.eulerAngles = new Vector3(0, 270 + upperBodyOffset, 0);
			//}
			//}
			//head.gameObject.transform.eulerAngles = new Vector3(0, pivot.gameObject.transform.eulerAngles.y, 0);


			//if((rotation_x >= -15 & rotation_x <= 15) & (rotation_y >= -37 & rotation_y <= 37) & (rotation_z >= -10 & rotation_z <= 10 ))
			//{
			//headMove = true;
			//return;
			//}
			//else
			//{
			//if(headMove)
			//{
			//remember_rotation_x = rotation_x;
			//remember_rotation_y = rotation_y-180;
			//remember_rotation_z = rotation_z;
			//headMove = false;
			//pivot.gameObject.transform.eulerAngles = new Vector3(remember_rotation_x, remember_rotation_y, remember_rotation_z);

			//}

			//else
			//{
			//pivot.gameObject.transform.eulerAngles = new Vector3(remember_rotation_x, remember_rotation_y, remember_rotation_z);
			//}
			//}

			//rotation_x = pivot.gameObject.transform.rotation.x;
			//rotation_y = pivot.gameObject.transform.rotation.y;
			//rotation_z = pivot.gameObject.transform.rotation.z;
			//rotation_w = pivot.gameObject.transform.rotation.w;

			//if((rotation_x >= -0.1 & rotation_x <= 0.1) & (rotation_y >= -1 & rotation_y <= -0.8) & (rotation_z >= -0.4 & rotation_z <= 0.4) & (rotation_w >= -0.1 & rotation_w <= 0.1))
			//{
			//headMove = true;
			//pivot.gameObject.transform.rotation = new Quaternion(rotation_x, rotation_y, rotation_z, rotation_w);
			//}

			//else
			//{
			//if(headMove)
			//{
			//remember_rotation_x = rotation_x;
			//remember_rotation_y = rotation_y;
			//remember_rotation_z = rotation_z;
			//remember_rotation_w = rotation_w;
			//headMove = false;
			//pivot.gameObject.transform.rotation = new Quaternion(remember_rotation_x, remember_rotation_y, remember_rotation_z, remember_rotation_w);
			//}

			//else
			//{
			//pivot.gameObject.transform.rotation = new Quaternion(remember_rotation_x, remember_rotation_y, remember_rotation_z, remember_rotation_w);
			//}
			//}

			//Debug.Log(pivot.gameObject.transform.eulerAngles.y);
		}
		private static float WrapAngle(float angle)
		{
			angle %= 360;
			if (angle > 180)
				return angle - 360;

			return angle;
		}

        


    }
}


