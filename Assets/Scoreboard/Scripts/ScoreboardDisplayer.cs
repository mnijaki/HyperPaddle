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
  // Public methods
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Display score.
  public void ScoreDisplay()
  {
    // TO_DO: All ot this code should be moved to update of event function when you get score
    // data from databse (because getting scores online can return values after some time).

    // Get scoreboard.
    this.scoreboard=GameObject.FindObjectOfType<ScoreboardLocal>();
    // Get top scores text.
    this.top_scores_txt=this.GetComponent<Text>();
    // Get top scores.
    List<ScoreboardData> top_scores = this.scoreboard.TopScoresGet();
    // String builder holding top scores.
    StringBuilder tmp = new StringBuilder("");
    // Loop over top 5 scores.
    foreach(ScoreboardData item in top_scores.Take(5))
    {
      // Actualize text.
      tmp.AppendLine(item.player_name +" (" +item.score +")  " +item.player_nick +"  " +item.score_datetime);
    }
    // Set text.
    this.top_scores_txt.text = tmp.ToString();
  } // End of ScoreDisplay

  #endregion

} // End of ScoreboardDisplayer