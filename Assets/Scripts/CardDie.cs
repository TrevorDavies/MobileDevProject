using UnityEngine;
using System.Collections;

public class CardDie : MonoBehaviour {

   // public GameController gameContoller;
	// Use this for initialization
	void Start () 
    {
        StartCoroutine(Die());
	
	}

    IEnumerator Die()
    {

        yield return new WaitForSeconds(3);
        //gameContoller.loseLife();
        Destroy(gameObject);
    }
	
}
