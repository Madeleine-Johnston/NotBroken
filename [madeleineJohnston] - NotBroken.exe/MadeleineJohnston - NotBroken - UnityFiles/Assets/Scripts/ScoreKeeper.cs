using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public int score;

    private Text myScoreText;

	void Start() {
        //finds where to put the text
		 myScoreText = GetComponent<Text>();
	}

	public void UpdateScore() {
        //updates score and displays. Converts number/score to string so can be input as text
		myScoreText.text = "Score: " + score.ToString();
	}

	
}
