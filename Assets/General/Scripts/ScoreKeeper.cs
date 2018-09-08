using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Public fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Single static instance of 'ScoreKeeper' (Singelton pattern).
  public static ScoreKeeper Instance
  {
    get
    {
      return ScoreKeeper._instance;
    }
  }

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Single static instance of 'ScoreKeeper' (Singelton pattern).
  private static ScoreKeeper _instance;
  // Score text.
  private TextMeshProUGUI score_txt;
  // Scoreboard.
  ScoreboardLocal scoreboard;
  // Current score.
  private int score = 0;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Public methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Increase score value.
  public void ScoreIncrease(int val)
  {
    // Actualize score.
    Instance.score += val;
    // Set text.
    Instance.score_txt.text = Instance.score.ToString();
  } // End of ScoreIncrease

  // Return score.
  public int ScoreGet()
  {
    // Return score.
    return Instance.score;
  } // End of ScoreGet

  // Event - on ball out.
  public void OnBallOut(float delay)
  {
    // If given score is high enough to get to top scores.
    if(Instance.scoreboard.IsTopScore(Instance.score))
    {
      // Save current score in top scores.
      Instance.scoreboard.TopScoreSet(Instance.score);
      // Load enter name level.
      LevelManager.Instance.TopScoresNameLoad(0.0F);
    }
    // If given score is not high enough to get to high score.
    else
    {
      // Load lose screen.
      LevelManager.Instance.LoseLoad(0.0F);
    }
  } // End of OnBallOut

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Awake (used to initialize any variables or game state before the game starts).
  private void Awake()
  {
    if(ScoreKeeper._instance==null)
    {
      ScoreKeeper._instance=this;
    }
    else
    {
      GameObject.Destroy(this.gameObject);
    }
  } // End of Awake  

  // Initialization.
  private void Start()
  {
    // Make sure that game object will not be destroyed after loading next scene.
    GameObject.DontDestroyOnLoad(Instance.gameObject);
  } // End of Start

  // On level was loaded.
  private void OnLevelWasLoaded(int level)
  {
    // If not game level.
    if(LevelManager.Instance.CurLvlGet()== LevelManager.Lvls.NONE)
    {
      // Reset score.
      Instance.score=0;
      // Exit.
      return;
    }
    // Get score text.
    Instance.score_txt=GameObject.FindGameObjectWithTag("score_txt").GetComponent<TextMeshProUGUI>();
    // Set score.
    Instance.score_txt.text = Instance.score.ToString();
    // Get scoreboard.
    Instance.scoreboard=GameObject.FindObjectOfType<ScoreboardLocal>();
  } // End of OnLevelWasLoaded

  #endregion

} // End of ScoreKeeper