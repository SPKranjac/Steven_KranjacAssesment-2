using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Setting Level to load from main screen
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
	
    //Setting game to quit 
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
