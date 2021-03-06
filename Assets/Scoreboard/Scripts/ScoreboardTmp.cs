﻿using System.Collections.Generic;
using UnityEngine;
using System;

// Temporary scoreboard (only for duration of the game).
public class ScoreboardTmp: MonoBehaviour
{
  //// ---------------------------------------------------------------------------------------------------------------------  
  //// Public fields                  
  //// ---------------------------------------------------------------------------------------------------------------------
  //#region

  //// Current top score (shared between all instances of 'Scoreboard').
  //public static int top_score = 0;
  //// List of top scores (shared between all instances of 'Scoreboard').
  //public static SortedList<int,ScoreboardData> top_scores = new SortedList<int,ScoreboardData>();

  //#endregion


  //// ---------------------------------------------------------------------------------------------------------------------  
  //// Public methods                  
  //// ---------------------------------------------------------------------------------------------------------------------
  //#region

  //// Set top score.
  //public void TopScoreSet(int score)
  //{
  //  // Set top score.
  //  top_score=score;
  //} // End of TopScoreSet

  //// Return info if given score is high enough to get to top scores.
  //public bool IsTopScore(int score)
  //{
  //  if(score > top_score)
  //  {
  //    return true;
  //  }
  //  else
  //  {
  //    return false;
  //  }
  //} // End of IsTopScore

  //// Claim top score.
  //public void TopScoreClaim(string player_name,string player_nick)
  //{
  //  // Create new score data.
  //  ScoreboardData scoreboard_data = new ScoreboardData(top_score,player_name,player_nick,DateTime.Now);
  //  // Add score to list.
  //  top_scores.Add(top_score,scoreboard_data);
  //} // End of TopScoreClaim

  //// Return list of top scores.
  //public SortedList<int,ScoreboardData> TopScoresGet()
  //{
  //  // Return top scores.
  //  return top_scores;
  //} // End of TopScoresGet

  //#endregion

} // End of ScoreboardTmp