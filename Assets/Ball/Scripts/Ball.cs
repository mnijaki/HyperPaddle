using UnityEngine;

// Ball.
public class Ball : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Ball initial velocity.
  [SerializeField]
  [Tooltip("Ball initial velocity")]
  private Vector3 init_speed = new Vector3(20.0F,10.0F,-60.0F);
  // Speed multiplier.
  [SerializeField]
  [Range(1.0f,1.1f)]
  [Tooltip("Speed multiplier")]
  private float speed_multiplier = 1.02F;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Audio source.
  AudioSource audio_source;
  // Rigidbody.
  Rigidbody rbdy;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Get audio source.
    this.audio_source=this.GetComponent<AudioSource>();
    // Get rigidbody.
    this.rbdy=this.GetComponent<Rigidbody>();
    // Set initial velocity.
    this.GetComponent<Rigidbody>().velocity=this.init_speed;
	} // End of Start

  // On collision.
  private void OnCollisionExit()
  {
    // Play audio.
    this.audio_source.Play();
    // Set new velocity.
    this.rbdy.velocity = new Vector3(this.rbdy.velocity.x + Random.Range(-5.0F,5.0F),
                                     this.rbdy.velocity.y + Random.Range(-5.0F,5.0F),
                                     this.rbdy.velocity.z * this.speed_multiplier);
  } // End of OnCollisionExit

  #endregion

} // End of Ball