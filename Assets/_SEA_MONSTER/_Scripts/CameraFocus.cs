/*
Maintaince Logs:
2011-12-22    XuMingzhao    Initial version. controll game camera.
2011-12-23    XuMingzhao    Add Network support.
2011-12-28    XuMingzhao    Add football and player distance controll.
*/

using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour {
	
	public GameObject camTarget;
	
	public float maxY = 10.0f;
	
	Vector3 newPos = Vector3.zero;
	void LateUpdate () 
	{
		newPos = camTarget.transform.position;
		newPos.y = Mathf.Clamp(newPos.y, -maxY, maxY);
		
		newPos.z -= Mathf.Abs(newPos.y) *  0.5f;
		

		transform.position = newPos;
	}
	
	
}
