using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	int cameraVelocity = 10;
	//Vector3 forwards = new Vector3(0,Mathf.Sin(30*Mathf.Deg2Rad),Mathf.Cos(30*Mathf.Deg2Rad));
	//Vector3 backwards = new Vector3(0,-Mathf.Sin(30*Mathf.Deg2Rad),-Mathf.Cos(30*Mathf.Deg2Rad));

	public void move_camera(int in_direction){
		switch (in_direction) {
		case 0:
			this.transform.Translate ((Vector3.down * cameraVelocity) * Time.deltaTime);
			break;
		case 1:
			this.transform.Translate ((Vector3.left * cameraVelocity) * Time.deltaTime);
			break;
		case 2:
			this.transform.Translate ((Vector3.up * cameraVelocity) * Time.deltaTime);
			break;
		case 3:
			this.transform.Translate ((Vector3.right * cameraVelocity) * Time.deltaTime);
			break;
		}
	}
		
	void Start () {
		
	}

	void Update () {
		
	}
}