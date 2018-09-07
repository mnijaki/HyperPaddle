using UnityEngine;

// Loose collider.
public class LooseCollider : MonoBehaviour
{
  // On collision.
	private void OnTriggerEnter()
  {
    // Play audio source.
		this.GetComponent<AudioSource>().Play();
    // Notify score keeper after delay.
		Invoke("NotifyScoreKeeper",2.5f);
  } // End Of OnTriggerEnter

  // Notify score keeper.
  private void NotifyScoreKeeper()
  {
		GameObject.FindObjectOfType<ScoreKeeper>().BallOut();
  } // End of NotifyScoreKeeper

} // End of LooseCollider