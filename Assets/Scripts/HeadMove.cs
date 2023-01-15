using UnityEngine;
using System.Collections;

namespace Valve.VR
{
	public class HeadMove : MonoBehaviour
	{
		private float position_x;
		private float position_y;
		private float position_z;
		private float rotation_x;
		private float rotation_y;
		private float rotation_z;
		
		void Start()
		{

			//if (this.gameObject.GetComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>() == null)
			//{
				//this.gameObject.AddComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>();
			//}
			position_x = this.gameObject.transform.position.x;
			position_y = this.gameObject.transform.position.y;
			position_z = this.gameObject.transform.position.z;

			//this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
			
		}
        private void Update()
        {
			this.gameObject.transform.position = new Vector3(position_x,position_y,position_z);
			rotation_x = WrapAngle(this.gameObject.transform.rotation.eulerAngles.x);
			rotation_y = this.gameObject.transform.eulerAngles.y-180;
			rotation_z = WrapAngle(this.gameObject.transform.rotation.eulerAngles.z);
			//three all false
			//change z
			//1
			if (rotation_x <= -10 & rotation_y <= -40 & rotation_z <= -5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(-10, -40, -5);
			}
			//2
			else if (rotation_x <= -10 & rotation_y <= -40 & rotation_z >= 5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(-10, -40, 5);
			}

			//change y then z
			//3
			else if (rotation_x < -10 & rotation_y >= 40 & rotation_z < -5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(-10, 40, -5);
			}
			//4
			else if (rotation_x <= -10 & rotation_y >= 40 & rotation_z >= 5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(-10, 40, 5);
			}
			//5
			if (rotation_x >= 10 & rotation_y <= -40 & rotation_z <= -5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(10, -40, -5);
			}
			//6
			else if (rotation_x >= 10 & rotation_y <= -40 & rotation_z >= 5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(10, -40, 5);
			}

			//change y then z
			//7
			else if (rotation_x >= 10 & rotation_y >= 40 & rotation_z <= -5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(10, 40, -5);
			}
			//8
			else if (rotation_x >= 10 & rotation_y >= 40 & rotation_z >= 5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(10, 40, 5);
			}

			//two false
			//y,z as false
			//keep y, change z
			//9
			else if((rotation_x > -10 & rotation_x < 10) & rotation_y <= -40 & rotation_z <= -5)
            {
				this.gameObject.transform.eulerAngles = new Vector3(rotation_x, -40, -5);
			}

			//10
			else if ((rotation_x > -10 & rotation_x < 10) & rotation_y <= -40 & rotation_z >= 5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(rotation_x, -40, 5);
			}

			//change y then change z
			//11
			else if ((rotation_x > -10 & rotation_x < 10) & rotation_y >= 40 & rotation_z <= -5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(rotation_x, 40, -5);
			}

			//12
			else if ((rotation_x > -10 & rotation_x < 10) & rotation_y >= 40 & rotation_z >= 5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(rotation_x, 40, 5);
			}

			//x,z as false
			//keep x, change z
			//13
			else if(rotation_x <= -10 & (rotation_y > -40 & rotation_y < 40) & rotation_z <= -5)
            {
				this.gameObject.transform.eulerAngles = new Vector3(-10, rotation_y, -5);
            }

			//14
			else if (rotation_x <= -10 & (rotation_y > -40 & rotation_y < 40) & rotation_z >= 5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(-10, rotation_y, 5);
			}

			//change x then change z
			//15
			else if (rotation_x >= 10 & (rotation_y > -40 & rotation_y < 40) & rotation_z <= -5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(10, rotation_y, -5);
			}

			//16
			else if (rotation_x >= 10 & (rotation_y > -40 & rotation_y < 40) & rotation_z >= 5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(10, rotation_y, 5);
			}

			//x, y as false
			//keep x, change y
			//17
			else if(rotation_x <= -10 & rotation_y <= -40 & (rotation_z > -5 & rotation_z < 5))
            {
				this.gameObject.transform.eulerAngles = new Vector3(-10, -40, rotation_z);
            }

			//18
			else if (rotation_x <= -10 & rotation_y >= 40 & (rotation_z > -5 & rotation_z < 5))
			{
				this.gameObject.transform.eulerAngles = new Vector3(-10, 40, rotation_z);
			}

			//change x, then change y
			//19
			else if (rotation_x >= 10 & rotation_y <= -40 & (rotation_z > -5 & rotation_z < 5))
			{
				this.gameObject.transform.eulerAngles = new Vector3(10, -40, rotation_z);
			}

			//20
			else if (rotation_x >= 10 & rotation_y >= 40 & (rotation_z > -5 & rotation_z < 5))
			{
				this.gameObject.transform.eulerAngles = new Vector3(10, 40, rotation_z);
			}

			//x as false
			//21
			else if(rotation_x <= -10 & (rotation_y > -40 & rotation_y < 40) & (rotation_z > -5 & rotation_z < 5))
            {
				this.gameObject.transform.eulerAngles = new Vector3(-10, rotation_y, rotation_z);
            }

			//22
			else if (rotation_x >= 10 & (rotation_y > -40 & rotation_y < 40) & (rotation_z > -5 & rotation_z < 5))
			{
				this.gameObject.transform.eulerAngles = new Vector3(10, rotation_y, rotation_z);
			}

			//y as false
			//23
			else if((rotation_x > -10 & rotation_x < 10) & rotation_y <= -40 & (rotation_z > -5 & rotation_z < 5))
            {
				this.gameObject.transform.eulerAngles = new Vector3(rotation_x, -40, rotation_z);
            }

			//24
			else if ((rotation_x > -10 & rotation_x < 10) & rotation_y >= 40 & (rotation_z > -5 & rotation_z < 5))
			{
				this.gameObject.transform.eulerAngles = new Vector3(rotation_x, 40, rotation_z);
			}

			//z as false
			//25
			else if((rotation_x > -10 & rotation_x < 10) & (rotation_y > -40 & rotation_y < 40) & rotation_z <= -5)
            {
				this.gameObject.transform.eulerAngles = new Vector3(rotation_x, rotation_y, -5);
            }

			//26
			else if ((rotation_x > -10 & rotation_x < 10) & (rotation_y > -40 & rotation_y < 40) & rotation_z >= 5)
			{
				this.gameObject.transform.eulerAngles = new Vector3(rotation_x, rotation_y, 5);
			}

			//all true
			//27
			//else if ((rotation_x > -10 & rotation_x < 10) & (rotation_y > -40 & rotation_y < 40) & (rotation_z > -5 & rotation_z < 5))
            //{
				//this.gameObject.transform.eulerAngles = new Vector3(rotation_x, rotation_y, rotation_z);
            //}

			else
            {
				this.gameObject.transform.eulerAngles = new Vector3();
            }
			Debug.Log(this.gameObject.transform.eulerAngles.y);

			
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
