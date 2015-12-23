using UnityEngine;
using System.Collections;

public class PlayerHand : MonoBehaviour {

    //default speed of the hand object
    float defaultVelocity = 450f;

    public GameController gameController;
 

	void Start ()
    {
        
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, 60f , Camera.main.farClipPlane / 2));
        transform.position = screenPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 handPosition = Camera.main.WorldToScreenPoint(transform.position);
        //reposition the hand on the left side when it goes past the width of screen on right side
        if (handPosition.x > Screen.width)
        {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 60f, Camera.main.farClipPlane / 2));
            transform.position = screenPosition;
        }
        //reposition the hand on the right side when it goes past the width of screen on left side
        if (handPosition.x < 0)//left side 
        {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 60f, Camera.main.farClipPlane / 2));
            transform.position = screenPosition;
        }

        //allowing the use of the arrow keys to move the hand left or right 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Right();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Left();
        }
    }
    //setting the speed the hand object moves 
    public void Right()
    {

           GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
           GetComponent<Rigidbody2D>().AddForce(Vector2.right * defaultVelocity);
        
    }
    public void Left()
    {

            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * defaultVelocity);
        
    }

   
    public void OnCollisionEnter2D(Collision2D col)
    {

        int cardsuit = col.gameObject.GetComponent<Card>().suit;

        if (cardsuit == gameController.cardSuit)
        {
            gameController.ChangeSuit();
            gameController.RightCard();
        }
        else
        {
            gameController.WrongCard();
        }

        Destroy(col.gameObject);
    }

}
