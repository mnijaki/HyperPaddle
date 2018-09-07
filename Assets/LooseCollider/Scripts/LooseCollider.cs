using UnityEngine;

// Loose collider.
public class LooseCollider : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // On collision.
  private void OnTriggerEnter()
  {
    // Play audio source.
    this.GetComponent<AudioSource>().Play();
    // Notify score keeper after delay.
    ScoreKeeper.Instance.OnBallOut(0.0F);
  } // End Of OnTriggerEnter

  #endregion

} // End of LooseCollider