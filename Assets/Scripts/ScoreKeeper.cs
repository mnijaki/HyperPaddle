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

  public LevelManager levelManager;

  //public GlobalScoreboard scoreboard;

  public TextMeshProUGUI score_txt;
	private int score = 0;
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
    this.score_txt.text = this.score.ToString();
	}
	
	public void Add (int amount) {
    this.score += amount;
    // We update here rather than in Update
    // That way we only call when needed not every frame
    this.score_txt.text = this.score.ToString();
	}
	
	public int GetScore () {
		// We're doing this to be good
		return this.score;
	}
	
	//public void BallOut(){
	//	if(scoreboard.IsHighScore(score)){
	//		scoreboard.SetCurrentScore(score);
	//		levelManager.LoadLevel("Enter Name");
	//	}else{
	//		levelManager.LoadLevel("Loose Menu");
	//	}
	//}
}
