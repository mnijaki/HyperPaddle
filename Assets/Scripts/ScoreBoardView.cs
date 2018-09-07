using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScoreBoardView : MonoBehaviour {

	public GlobalScoreboard global_scoreboard;
	private Text scoresText;
	
	void Start () {
    this.scoresText = this.gameObject.GetComponent<Text>();
	}
	
	void Update () {
		List<GlobalScoreboard.ScoreEntry> scores = this.global_scoreboard.GetScores();
		if(scores.Count > 0){
			string scoreString = "";
			foreach(GlobalScoreboard.ScoreEntry entry in scores.Take(5)){
				scoreString += entry.name +" ("+ entry.score.ToString()+")\n";
			}
      this.scoresText.text = scoreString;
		}
	}
}
