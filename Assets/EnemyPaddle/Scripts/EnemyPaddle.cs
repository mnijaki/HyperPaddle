using UnityEngine;

// Enemy paddle.
public class EnemyPaddle: MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Ball.
  private Ball ball;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Get ball.
    this.ball = GameObject.FindObjectOfType<Ball>();
  } // End of Start

  // Update (called once per frame).
  private void Update()
  {
    // Set position of enemy paddle to position of ball.
    this.transform.position = new Vector3(Mathf.Clamp(this.ball.transform.position.x,-7.5f,7.5f),
                                          Mathf.Clamp(this.ball.transform.position.y,-7.5f,7.5f),
                                          this.transform.position.z);
  } // End of Update

  #endregion

} // End of EnemyPaddle