using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;


// ***********************************************************************************************************************
//                                                    INFO
// ***********************************************************************************************************************
//
// * We serialize data to binary file, becouse dictionary is not so simple to save as xml or json.
// * 'Application.persistentDataPath()' points to :
//   - %userprofile%\AppData\Local\Packages\<productname>\LocalState -> on Android, iOS, Windows
//   - ~/Library/Application Support/company name/product name -> on Mac
// * 'Path.Combine()' combines to strings into path (platform independant, eg linux, windows and mac use 
//   backslashes and slashes diffrently).
// * Current path: C:\Users\Marek\AppData\LocalLow\DefaultCompany\HyperPaddle\
//   or :          C:/Users/Marek/AppData/LocalLow/MusliComp/HyperPaddle\HyperPaddle_Topcores.dat
//
// ***********************************************************************************************************************


// Local scoreboard (saved to file on local disc).
public class ScoreboardLocal : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------  
  // Private fields
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Scoreboard file data.
  ScoreboardFileData data;
  // File path.
  private string file_path;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Public methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Set top score.
  public void TopScoreSet(int score)
  {
    // Set top score.
    this.data.top_score=score;
  } // End of TopScoreSet

  // Return info if given score is high enough to get to top scores.
  public bool IsTopScore(int score)
  {
    // TO_DO: Belov code will return true only if player have higher value
    // than current highest value. You can change it if you want to so 
    // if current top scores are 1,3,4,5,6 and someone have 2 he will get
    // to top scores. If you do so you must also change 'TopScoresSet' etc...

    // Get top five scores.
    var top_five = this.data.top_scores.Take(5);
    // If there is any score.
    if(top_five.Any())
    {
      //return (score > top_five.Last().score);
      return (score > top_five.First().score);
    }
    // If there is no score.
    else
    {
      return true;
    }
  } // End of IsTopScore

  // Claim top score.
  public void TopScoreClaim(string player_name,string player_nick)
  {
    // Create new score data.
    ScoreboardData scoreboard_data = new ScoreboardData(this.data.top_score,player_name,player_nick,DateTime.Now);
    // Add score to list.
    this.data.top_scores.Insert(0,scoreboard_data);
  } // End of TopScoreClaim

  // Return list of top scores.
  public List<ScoreboardData> TopScoresGet()
  {
    // Return top scores.
    return this.data.top_scores;
  } // End of TopScoresGet

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Set path.
    this.file_path = Path.Combine(Application.persistentDataPath,"HyperPaddle_Topcores.dat");
    // Read from file.
    ReadBinFromFile();
    // If there is  'ScoreboardDisplayer'.
    if(GameObject.FindObjectOfType<ScoreboardDisplayer>())
    {
      // Display score.
      GameObject.FindObjectOfType<ScoreboardDisplayer>().ScoreDisplay();
    }
  } // End of Start

  // Write to file (exist only for purpose of learning).
  private void WriteToFile()
  {
    // Begin of block.
    try
    {
      // Open or create file for writing.
      Stream file = new FileStream(this.file_path,FileMode.OpenOrCreate,FileAccess.Write);
      // Write to file.
      StreamWriter file_writer = new StreamWriter(file);
      file_writer.Write("Hello ads a sd");
      // Close file.
      file_writer.Close();
    }
    // IO exception.
    catch(IOException e)
    {
      // Write info to console.
      Debug.Log("Error writing to file");
      // Throw error.
      Debug.LogException(e);
    }
    // Serialization exception.
    catch(SerializationException e)
    {
      // Write info to console.
      Debug.Log("Error sarialising file");
      // Throw error.
      Debug.LogException(e);
    }
  } // End of WriteToFile

  // Write binary data to file.
  private void WriteBinToFile()
  {
    // Create binary formatter (this will pass object to serialize to stream as binary data).
    IFormatter bin_formatter = new BinaryFormatter();
    // Begin of block.
    try
    {
      // Open or create file for writing.
      Stream file = new FileStream(this.file_path,FileMode.OpenOrCreate,FileAccess.Write);
      // Write to file (will autoamticly create new 'ScoreboardFileData').
      bin_formatter.Serialize(file,this.data);
      // Close file.
      file.Close();
    }
    // IO exception.
    catch(IOException e)
    {
      // Write info to console.
      Debug.Log("Error writing to file");
      // Throw error.
      Debug.LogException(e);
    }
    // Serialization exception.
    catch(SerializationException e)
    {
      // Write info to console.
      Debug.Log("Error sarialising file");
      // Throw error.
      Debug.LogException(e);
    }
  } // End of WriteBinToFile

  // Read from file (exist only for purpose of learning).
  private void ReadFromFile()
  {
    // Begin of block.
    try
    {
      // Open file for reading.
      Stream file = new FileStream(this.file_path,FileMode.Open,FileAccess.Read);
      // Read from file.
      StreamReader file_reader = new StreamReader(file);
      string txt=file_reader.ReadToEnd();
      // Close file.
      file_reader.Close();
    }
    // IO exception.
    catch(IOException e)
    {
      // Create default scoreboard file data.
      this.data=new ScoreboardFileData();
      // Write info to console.
      Debug.Log("Error reading from file");
      // Throw error.
      Debug.LogException(e);
    }
    // Serialization exception.
    catch(SerializationException e)
    {
      // Create default scoreboard file data.
      this.data=new ScoreboardFileData();
      // Write info to console.
      Debug.Log("Error desarialising file");
      // Throw error.
      Debug.LogException(e);
    }
    catch(Exception e)
    {
      // Create default scoreboard file data.
      this.data=new ScoreboardFileData();
      // Write info to console.
      Debug.Log("Unhandled error when reading from file");
      // Throw error.
      Debug.LogException(e);
    }
  } // End of ReadFromFile

  // Read binary data from file.
  private void ReadBinFromFile()
  {
    // Create binary formatter (this will pass object to serialize to stream as binary data).
    IFormatter bin_formatter = new BinaryFormatter();
    // Begin of block.
    try
    {
      // Open file for reading.
      Stream file = new FileStream(this.file_path,FileMode.Open,FileAccess.Read);
      // Read from file.
      this.data = bin_formatter.Deserialize(file) as ScoreboardFileData;
      // Close file.
      file.Close();
    }
    // IO exception.
    catch(IOException e)
    {
      // Create default scoreboard file data.
      this.data=new ScoreboardFileData();
      // Write info to console.
      Debug.Log("Error reading from file");
      // Throw error.
      Debug.LogException(e);
    }
    // Serialization exception.
    catch(SerializationException e)
    {
      // Create default scoreboard file data.
      this.data=new ScoreboardFileData();
      // Write info to console.
      Debug.Log("Error desarialising file");
      // Throw error.
      Debug.LogException(e);
    }
    catch(Exception e)
    {
      // Create default scoreboard file data.
      this.data=new ScoreboardFileData();
      // Write info to console.
      Debug.Log("Unhandled error when reading from file");
      // Throw error.
      Debug.LogException(e);
    }
  } // End of ReadBinFromFile

  // Event - on destory.
  private void OnDestroy()
  {
    WriteBinToFile();
  } // End of OnDestroy

  // Event - on application pause.
  private void OnApplicationPause()
  {
    WriteBinToFile();
  } // End of OnApplicationPause

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private classes.                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Scoreboard data (serializable).
  [Serializable]
  private class ScoreboardFileData
  {
    // Current top score.
    public int top_score = 0;
    // List of top scores.
    public List<ScoreboardData> top_scores = new List<ScoreboardData>();
  } // End of ScoreboardFileData

  #endregion

} // End of ScoreboardLocal