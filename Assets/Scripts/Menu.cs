using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using Newtonsoft.Json;
using UnityEngine.SceneManagement;
//using Bitrave.Azure;
using System.Collections.Generic;

public class Menu : MonoBehaviour {

    //private AzureMobileServices azure;

    //[SerializeField]
    //public const string _AzureEndPoint = "https://trevorsunityservices.azure-mobile.net";

    //[SerializeField]
    //public const string _ApplicationKey = "CAjWxCUOedxIagsxTkacSQwwntICHT27"; // Your API Key

    //public List<LeaderBoard> myLeaderboard = new List<LeaderBoard>();

    public InputField input;
    public Text username;
    public Text currentPlayerScore;

    void Start()
    {
        //displaying top score on start up 
         currentPlayerScore.text = "" + PlayerPrefs.GetInt("SCORE");
    }

    void Update()
    {
        //displaying the name entered
        username.text = PlayerPrefs.GetString("NAME");
    }
    //setting the username
    public void setName()
    {

            string name = input.text;

            PlayerPrefs.SetString("NAME", name);
      


    }
    //starting the game 
    public void Play() 
    {
        SceneManager.LoadScene("Main");
       // Application.LoadLevel("Main");
    }
    //move to high scores scene
    public void HighScore()
    {
        SceneManager.LoadScene("HighScore");
        //Application.LoadLevel("HighScore");
    }

}
