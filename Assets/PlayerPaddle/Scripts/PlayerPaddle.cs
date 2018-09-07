using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Game camera script.
  private GameCamera game_camera_script;
  // Game camera.
  private Camera game_camera;
  // Distance from camera to paddle.
  private float dist_from_camera_to_paddle;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Get game camera script.
    this.game_camera_script=GameObject.FindObjectOfType<GameCamera>();
    // Get game camera.
    this.game_camera=this.game_camera_script.GetComponent<Camera>();
    // Get distance from camera to paddle.
    this.dist_from_camera_to_paddle = this.transform.position.z - this.game_camera.transform.position.z;
  } // End of Start

  // On mouse drag.
  private void OnMouseDrag()
  {
    // Get mouse position.
    Vector3 pos = GetMouseCoordinatesAtDistance(this.dist_from_camera_to_paddle);
    // Move paddle to mouse position.
    this.transform.position=new Vector3(Mathf.Clamp(pos.x,-7.5F,7.5F),
                                        Mathf.Clamp(pos.y,-7.5F,7.5F),
                                        this.transform.position.z);
    // Shift camera around paddle.
    this.game_camera_script.ShiftAroundPaddle(pos);
  } // End of OnMouseDrag

  // Get mouse coordinates.
  private Vector3 GetMouseCoordinatesAtDistance(float distance)
  {
    // Get screen position.
    Vector3 screen_pos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,distance);
    // Get world position.
    Vector3 world_pos = this.game_camera.ScreenToWorldPoint(screen_pos);
    // Return world position.
    return world_pos;
  } // End of GetMouseCoordinatesAtDistance

  // On collision.
  private void OnCollisionExit(Collision col)
  {
    // Increase score.
    ScoreKeeper.Instance.ScoreIncrease(1);
  } // End of OnCollisionExit

  #endregion

}
