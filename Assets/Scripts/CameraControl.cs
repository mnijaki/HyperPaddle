using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	[Range (0.05F,0.5F)]
	public float factor= 0.05F;
	
	public void ShiftAroundPaddle (Vector3 position) {
		print ("Moving camera. Paddle position: " + position);
		Vector3 newCameraPos;
		newCameraPos.x = Mathf.Clamp(position.x * factor,-10,10);
		newCameraPos.y = Mathf.Clamp(position.y * factor,-10,10);
		newCameraPos.z = transform.position.z; // i.e. don't move in z
		
		transform.position = newCameraPos;
	}
	
	void Update () {
		//if (Input.GetKeyDown(KeyCode.UpArrow)) {
		//	factor = Mathf.Clamp(factor + 0.05f, 0.05f, 0.5f);
		//} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
		//	factor = Mathf.Clamp(factor - 0.05f, 0.05f, 0.5f);
		//}
	}
}
