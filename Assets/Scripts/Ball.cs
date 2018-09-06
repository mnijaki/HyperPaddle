using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ball.
public class Ball : MonoBehaviour
{
  // Ball initial velocity.
  [SerializeField]
  [Tooltip("Ball initial velocity")]
  private Vector3 init_speed = new Vector3(20.0F,10.0F,-60.0F);


	// Use this for initialization
	void Start ()
  {
    // Set velocity.
    this.GetComponent<Rigidbody>().velocity=this.init_speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
