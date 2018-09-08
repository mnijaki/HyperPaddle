using System.Collections.Generic;
using UnityEngine;

// Scoreboard.
public class Scoreboard : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------  
  // Public fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Current top score (shared between all instances of 'Scoreboard').
  public static int top_score = 0;
  // List of top scores (shared between all instances of 'Scoreboard').
  public static SortedList<int,string> top_scores = new SortedList<int,string>();

  #endregion

  // ---------------------------------------------------------------------------------------------------------------------  
  // Public methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Set top score.
  public void TopScoreSet(int score)
  {
    Debug.Log("score set to: "+score.ToString());
    // Set top score.
    top_score=score;
  } // End of TopScoreSet

  // Return info if given score is high enough to get to top scores.
  public bool IsTopScore(int score)
  {
    if(score > top_score)
    {
      return true;
    }
    else
    {
      return false;
    }
  } // End of IsTopScore

  // Claim top score.
  public void TopScoreClaim(string name)
  {
    Debug.Log("score ["+top_score+"] claimed by "+name);
    // Add score to list.
    top_scores.Add(top_score,name);
  } // End of TopScoreClaim

  // Return list of top scores.
  public SortedList<int, string> TopScoresGet()
  {
    // TO_DO:change to class that have also date

    // Return top scores.
    return top_scores;
  } // End of TopScoresGet

  #endregion

} // End of Scoreboard