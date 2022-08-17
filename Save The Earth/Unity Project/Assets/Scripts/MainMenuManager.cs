using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        // Debug.Log("Quited");
        Application.Quit();
    }
}
