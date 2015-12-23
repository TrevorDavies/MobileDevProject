using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

    public Sprite[] cards = new Sprite[52]; // creating card array

    int rNum;

    public int suit;

    
	// Use this for initialization
	void Awake () 
    {
	    rNum = Random.Range(0,52); // random number between 0 and 51

        //setting the image of the card object to the random number selected
        gameObject.GetComponent<SpriteRenderer>().sprite = cards[rNum];

        suit = rNum / 14;//setting the of the card

	}
	

}
