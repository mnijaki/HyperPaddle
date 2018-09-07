using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour 
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields
  // ---------------------------------------------------------------------------------------------------------------------
  #region

#endregion

  public GlobalScoreboard global_scoreboard;
  public TextMeshProUGUI score_txt;
	private int score = 0;
	
	// Use this for initialization
	void Start()
  {
		DontDestroyOnLoad(this.gameObject);
    this.score_txt.text = this.score.ToString();
	}
	
	public void Add(int amount)
  {
    this.score += amount;
    // We update here rather than in Update
    // That way we only call when needed not every frame
    this.score_txt.text = this.score.ToString();
	}
	
	public int GetScore()
  {
		// We're doing this to be good
		return this.score;
	}

  public void BallOut()
  {
    if(this.global_scoreboard.IsHighScore(this.score))
    {
      this.global_scoreboard.SetCurrentScore(this.score);
      
      // Load h
     // LevelManager.Instance.
    }
    else
    {
     //this.level_manager.LoadLevel("Loose");
    }
  }
}
