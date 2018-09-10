using UnityEngine;

// Camera control.
public class GameCamera: MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Shift factor of camera movement.
  [SerializeField]
  [Range (0.05F,0.5F)]
  [Tooltip("Shift factor of camera movement")]
	private float shift_factor = 0.05F;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Shift camera around paddle position.
  public void ShiftAroundPaddle(Vector3 pos)
  {
		this.transform.position = new Vector3(Mathf.Clamp(pos.x * this.shift_factor,-10,10),
                                          Mathf.Clamp(pos.y * this.shift_factor,-10,10),
                                          this.transform.position.z);
  } // End of ShiftAroundPaddle

  #endregion

} // End of GameCamera