using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//using System.Threading.Tasks;
//using Parse;

using System.Linq;
 
public class GlobalScoreboard : MonoBehaviour
{
	static int currentTopScore = 0;
	public struct ScoreEntry
  {
		public int score;
		public string name;
	}
	private List<ScoreEntry> topScores = new List<ScoreEntry>(); 
	
	void Awake ()
  {
		//var query = ParseObject.GetQuery("GameScore")
		//	.WhereExists("playerName")
		//	.WhereExists("score")
		//	.OrderByDescending("score")
		//	.Limit(5);
		//var task = query.FindAsync();
		
		//task.ContinueWith( (t) => {
		//	topScores.Clear();
		//	foreach(ParseObject gameScore in t.Result){
		//		topScores.Add(new ScoreEntry(){
		//			score=gameScore.Get<int>("score"),
		//			name=gameScore.Get<string>("playerName")
		//		});
		//	}
		//});
	}
	
	public void SetCurrentScore(int score)
  {
		currentTopScore = score;
	}
	
	public bool IsHighScore(int score)
  {
		var topfive = topScores.Take(5);
		if(topfive.Any()){
			return (score > topfive.Last().score);
		}else{
			return true;
		}
	}
	public void ClaimCurrentScore(string name)
  {
		//Debug.Log("score of "+currentTopScore.ToString()+" claimed by "+name);
		//ParseObject gameScore = new ParseObject("GameScore");
		//gameScore["playerName"] = name;
		//gameScore["score"] = currentTopScore;
		//gameScore.SaveAsync();
	}
	
	public List<ScoreEntry> GetScores()
  {
		return topScores;
	}
}
