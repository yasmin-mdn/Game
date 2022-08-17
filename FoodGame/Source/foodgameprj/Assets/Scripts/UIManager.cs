using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text HeartCountText;
    public Text ScoreText;
    public EventSystemCustom eventSystem;
    GameObject obj;
    PlayerController player;
    public Text finalScoreText;

    void Start()
    {
        obj = GameObject.Find("Player");
        player = obj.GetComponent<PlayerController>();
        ScoreText.text = player.playerScore.ToString();
        finalScoreText.text = "Score : " + player.playerScore.ToString();
    }

    private void Update()
    {
        HeartCountText.text = player.playerHeartsCount.ToString();
        ScoreText.text = player.playerScore.ToString();
        if (player.playerHeartsCount == 0)
        {
            finalScoreText.text = "Score : " + player.playerScore.ToString();
        }
        

    }


    
}
