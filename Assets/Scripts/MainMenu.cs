using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
       // Application.LoadLevel("Menu");
    }

}
