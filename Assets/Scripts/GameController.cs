using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameController : MonoBehaviour {

    public GameObject blankCard;

    public Text textLives;
    public Text textScore;
    public Text textTimer;
    public Text textSuit;

    public int cardSuit;

    public float startTimer;
    int minutes = 0;
    int score = 0;
    public int lifeCount = 5;

    bool addScore = false;
    bool spawn = false;

    Camera mainCamera;

	// Use this for initialization
	void Start () 
    {
        startTimer = Time.deltaTime;//setting the starttimer to current time
        ChangeSuit();

     //   mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        startTimer += Time.deltaTime ;

        if (Mathf.Floor(startTimer) % 2 == 0)
        {
            if (spawn == false)
            {
                StartCoroutine(CreateCard());
            }

        }
        //increasing the score every 5 seconds
        if (Mathf.Floor(startTimer) % 5 == 0 && Mathf.Floor(startTimer)!=0)
        {
            if(addScore==false)
            {
                StartCoroutine(IncreaseScore());
            }        
            
        }
        //checking for when the seconds = 1 minute 
        if(startTimer/60 > 1)
        {
            startTimer = Time.deltaTime;
            minutes++;
        }
        //displaying the timer, score and amount of lives 
        textTimer.text = "Time: : " + minutes + "m " + Mathf.Ceil(startTimer) + "s";

        textScore.text = "Score: "+score;

        textLives.text = "Lives: " + lifeCount;
	
	}

    IEnumerator CreateCard()
    {
        float rNum = Random.Range(0, Screen.width);//random position between within the window/screen size

        //making sure the cards spawn within the window size
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(40f, Screen.width - 40f), Random.Range(Screen.height + 40f, Screen.height + 40f), Camera.main.farClipPlane / 2));

        spawn = true;

        //create the card
        Instantiate(blankCard, screenPosition, transform.rotation);
        yield return new WaitForSeconds(0.7f);

        spawn = false;
    }
    //increasing the by 20 used in update call
    IEnumerator IncreaseScore()
    {
        addScore = true;

        score += 20;

        yield return new  WaitForSeconds(1);

        addScore = false;
    }

    public void RightCard()
    {
        score += 100;
    }

    public void loseLife() 
    {
        lifeCount--;
    
    }

    public void ChangeSuit() {

        int rNum = Random.Range(0, 4);
        cardSuit = rNum;

        switch (rNum)
        {
            case 0:
 
                textSuit.text = "Suit: Club";
                break;
            case 1:
               
                textSuit.text = "Suit: Diamond";
                break;
            case 2:

                textSuit.text = "Suit: Heart";
                break;
            case 3:
 
                textSuit.text = "Suit: Spade";
                break;
        }
    }
    //if the wrong card is hit you loose a life and get - points
    public void WrongCard()
    {
        LooseLife();
     
        if (score - 50 > 0)
        {
            score -= 50;
            
        }
    }
    public void LooseLife() {

        if(lifeCount - 1 <= 0)
        {
            if (score > PlayerPrefs.GetInt("SCORE") || PlayerPrefs.GetInt("SCORE") == null)
            {
                PlayerPrefs.SetInt("SCORE", score);  
            }


            Application.LoadLevel("HighScore");        
        }

        lifeCount -= 1;
    }
}
