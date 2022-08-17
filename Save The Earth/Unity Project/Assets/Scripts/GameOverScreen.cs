using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text ScoreText;
    public Text HighScoreText;

    public void SetUp(float score)
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        ScoreText.text = score.ToString();
        HighScoreText.text= PlayerPrefs.GetFloat("High Score").ToString();
    }


    public void Restart()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
       
    }

    public void LoadMenu()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Menu");
        
    }
}
