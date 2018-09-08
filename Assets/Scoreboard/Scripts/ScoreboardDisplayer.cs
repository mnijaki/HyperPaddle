using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Displayer of scoreboard.
public class ScoreboardDisplayer : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------  
  // Serialized fields
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Scoreboard.
  [SerializeField]
  [Tooltip("Scoreboard")]
  private Scoreboard scoreboard;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private fields
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Top scores text.
  private Text top_scores_txt;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private methods
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Get top scores text.
    this.top_scores_txt=this.GetComponent<Text>();
    // Get top scores.
    SortedList<int,string> top_scores = this.scoreboard.TopScoresGet();
    // String builder holding top scores.
    StringBuilder tmp = new StringBuilder("");
    // Loop over top 5 scores.
    foreach(KeyValuePair<int,string> score in top_scores.Reverse().Take(5))
    {
      // Actualize text.
      tmp.AppendLine(score.Value + " (" + score.Key + ")");
    }
    // Set text.
    this.top_scores_txt.text = tmp.ToString();
  } // End of Start

  #endregion

} // End of ScoreboardDisplayer