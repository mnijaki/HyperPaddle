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
  // Serialized fields
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Single static instance of 'ScoreKeeper' (Singelton pattern).
  private static ScoreKeeper _instance;
  // Score text.
  private TextMeshProUGUI score_txt;
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
    //if(Instance.global_scoreboard.IsHighScore(Instance.score))
    // {
    //   Instance.global_scoreboard.SetCurrentScore(Instance.score);

    // Load h
    // LevelManager.Instance.
    // }
    // else
    //  {
    //Instance.level_manager.LoadLevel("Loose");
    // }
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
  } // End of OnLevelWasLoaded

  #endregion

} // End of ScoreKeeper