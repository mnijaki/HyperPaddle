using UnityEngine;
using System.Collections;

public class PaddleAI : MonoBehaviour {
	private Ball ball;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>() as Ball;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 paddlePos;
		paddlePos.x = Mathf.Clamp (ball.transform.position.x, -7.5f, 7.5f);
		paddlePos.y = Mathf.Clamp (ball.transform.position.y, -7.5f, 7.5f);
		paddlePos.z = transform.position.z;
		
		transform.position = paddlePos;
	}
}
