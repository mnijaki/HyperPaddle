using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour
{
  public Camera myCamera;
  public ScoreKeeper scoreKeeper;

  private float cameraToPaddleDistance;
  private CameraControl cameraControl;

  // Use this for initialization
  void Start()
  {
    cameraToPaddleDistance = transform.position.z - myCamera.transform.position.z;
    cameraControl = myCamera.GetComponent<CameraControl>() as CameraControl;
  }

  void OnCollisionEnter(Collision col)
  {
    scoreKeeper.Add(1);
  }

  void OnMouseDrag()
  {
    Vector3 mousePos = GetMouseCoordinatesAtDistance(cameraToPaddleDistance);
    MovePaddleTo(mousePos);
    cameraControl.ShiftAroundPaddle(mousePos);
  }

  Vector3 GetMouseCoordinatesAtDistance(float worldUnitsFromCamera)
  {
    float mouseX = Input.mousePosition.x;
    float mouseY = Input.mousePosition.y;
    Vector3 screenPos = new Vector3(mouseX,mouseY,worldUnitsFromCamera);
    Vector3 worldPos = myCamera.ScreenToWorldPoint(screenPos);
    return worldPos;
  }

  void MovePaddleTo(Vector3 worldPos)
  {
    Vector3 moveTo = new Vector3(
      Mathf.Clamp(worldPos.x,-7.5f,7.5f),
      Mathf.Clamp(worldPos.y,-7.5f,7.5f),
      transform.position.z
    );
    transform.position = moveTo;
  }
}
