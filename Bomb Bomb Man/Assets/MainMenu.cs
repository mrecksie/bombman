using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //loads the game scene when the play button is clicked
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //exits the application when the quit button is clicked
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
