//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Parse;
//using System.Linq;


//// ***********************************************************************************************************************
////                                                    INFO
//// ***********************************************************************************************************************
////
//// * Parse is a server, cloud service/database. You can download it from 'parse.com'.
//// * new ParseObject("Scores") - you can treat it like colection/grouping node, if this node exist data will be add at 
////   the end of old node (new node will not be created).
//// * You can check if data is stored correctly by going online to 'parse.com' and check data there (like in sqldeveloper).
//// * Parse library should be changed in script execution order (it must be instantiated befor any calls from other 
////   scripts).
//// * In current construction you can add scores to infinity, you can change it if you want.
//// * If you want implement 'ScoreboardGlobal' just replace 'ScoreboardLocal' all in code and editor.
////
//// ***********************************************************************************************************************


//// Global scoreboard.
//public class ScoreboardGlobal:MonoBehaviour
//{
//  // ---------------------------------------------------------------------------------------------------------------------  
//  // Private fields
//  // ---------------------------------------------------------------------------------------------------------------------
//  #region

//  // Top score.
//  static int top_score = 0;
//  // List of top scores.
//  private List<ScoreItem> top_scores = new List<ScoreItem>();

//  #endregion


//  // ---------------------------------------------------------------------------------------------------------------------  
//  // Public methods
//  // ---------------------------------------------------------------------------------------------------------------------
//  #region

//  // Set top score.
//  public void TopScoreSet(int score)
//  {
//    top_score = score;
//  } // End of TopScoreSet

//  // Return info if given score is high enough to get to top scores.
//  public bool IsTopScore(int score)
//  {
//    // Get top five scores.
//    var top_five = this.top_scores.Take(5);
//    // If there is any score.
//    if(top_five.Any())
//    {
//      return (score > top_five.Last().score);
//    }
//    // If there is no score.
//    else
//    {
//      return true;
//    }
//  } // End of IsTopScore

//  // Claim top score.
//  public void TopScoreClaim(string name)
//  {
//    ParseObject gameScore = new ParseObject("GameScore");
//    gameScore["playerName"] = name;
//    gameScore["score"] = top_score;
//    gameScore.SaveAsync();
//  } // End of TopScoreClaim

//  // Return list of top scores.
//  public List<ScoreItem> TopScoresGet()
//  {
//    return this.top_scores;
//  } // End of TopScoresGet

//  #endregion

//  // ---------------------------------------------------------------------------------------------------------------------  
//  // Private methods
//  // ---------------------------------------------------------------------------------------------------------------------
//  #region

//  // Getting scores from parse is awake because it can take a while (so better to do it as faast as you can).
//  // Awake (used to initialize any variables or game state before the game starts).
//  private void Awake()
//  {
//    // Create query.
//    var query = ParseObject.GetQuery("GameScore")
//                           .WhereExists("playerName")
//                           .WhereExists("score")
//                           .OrderByDescending("score")
//                           .Limit(5);
//    // Run query and recive task.
//    var task = query.FindAsync();
//    // 'ContinueWith()' will run inline function when task is compleated, passing there task (as t), t is a colleciont of
//    // parse objects that can be iterated (delgates and anynomuse functions).
//    // If task has ended.
//    task.ContinueWith((t) => 
//    {
//      // Clear top scores.
//      this.top_scores.Clear();
//      // Loop over items from database.
//      foreach(ParseObject item in t.Result)
//      {
//        // Add item to top scores (brackeys works hera as something similar to constructor).
//        this.top_scores.Add(new ScoreItem()
//        {
//          score=item.Get<int>("score"),
//          name=item.Get<string>("playerName")
//        });
//      }
//    });
//  } // End of Awake

//  // Here is other way of handling parse object:
//  // Exectue it in 'Awake()' as follow: 'task.ContinueWith(DataReadContinuation);'.
//  private void DataReadContinuation(Task<IEnumerable<ParseObject>> task)
//  {
//    // Loop over items from database.
//    foreach(ParseObject item in task.Result)
//    {
//      // Add item to top scores (brackeys works hera as something similar to constructor).
//      this.top_scores.Add(new ScoreItem()
//      {
//        score=item.Get<int>("score"),
//        name=item.Get<string>("playerName")
//      });
//    }
//  } // End of DataReadContinuation

//  #endregion


//  // ---------------------------------------------------------------------------------------------------------------------  
//  // Public classes
//  // ---------------------------------------------------------------------------------------------------------------------
//  #region

//  // Data that stores information about one score.
//  public struct ScoreItem
//  {
//    public int score;
//    public string name;
//  } // End of ScoreItem

//  #endregion

//} // End of ScoreboardGlobal