using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour {
	public Ball ball;
	public ScoreKeeper scoreKeeper;

	void OnTriggerEnter () {
		GetComponent<AudioSource>().Play ();
		//print ("Ball's z velocity " + ball.GetComponent<Rigidbody>().velocity.z);
		//Invoke("NotifyScoreKeeper",2.5f);
	}
	void NotifyScoreKeeper(){
	//	scoreKeeper.BallOut();
	}
}
