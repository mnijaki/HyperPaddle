using System;

// Data associated with score (serializable).
[Serializable]
public class ScoreboardData
{
  // ---------------------------------------------------------------------------------------------------------------------  
  // Public fields
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Score. 
  public int score;
  // Player name.
  public string player_name;
  // Player nick;
  public string player_nick;
  // Date.
  public DateTime score_datetime;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Public methods
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Constructor.
  public ScoreboardData(int score, string player_name, string player_nick, DateTime score_datetime)
  {
    this.score=score;
    this.player_name=player_name;
    this.player_nick=player_nick;
    this.score_datetime=score_datetime;
  } // End of ScoreboardData

  #endregion

} // End of ScoreboardData