using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Displayer of scoreboard.
public class ScoreboardDisplayer : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------  
  // Private fields
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Top scores text.
  private Text top_scores_txt;
  // Scoreboard.
  private ScoreboardLocal scoreboard;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private methods
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Get scoreboard.
    this.scoreboard=GameObject.FindObjectOfType<ScoreboardLocal>();
    // Get top scores text.
    this.top_scores_txt=this.GetComponent<Text>();
    // Get top scores.
    SortedList<int,ScoreboardData> top_scores = this.scoreboard.TopScoresGet();
    // String builder holding top scores.
    StringBuilder tmp = new StringBuilder("");
    // Loop over top 5 scores.
    foreach(KeyValuePair<int,ScoreboardData> item in top_scores)
    {
      Debug.Log(item.Value.player_name +" (" +item.Value.score +")  " +item.Value.player_nick +"  " +item.Value.score_datetime);
    }
    foreach(KeyValuePair<int,ScoreboardData> item in top_scores.Reverse().Take(5))
    {
      // Actualize text.
      tmp.AppendLine(item.Value.player_name +" (" +item.Value.score +")  " +item.Value.player_nick +"  " +item.Value.score_datetime);
    }
    // Set text.
    this.top_scores_txt.text = tmp.ToString();
  } // End of Start

  #endregion

} // End of ScoreboardDisplayer