using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    public Text highScore;
    public Text userName;

	// Use this for initialization
	void Start () {

        /*
            Setting the text on the highscores scene to the username, and the score 
        */

        highScore.text = "" + PlayerPrefs.GetInt("SCORE");
        userName.text = PlayerPrefs.GetString("NAME");

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
