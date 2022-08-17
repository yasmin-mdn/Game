using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text FianalScoreText;
    public Text CurreanScoreText;
    [SerializeField]GameOverScreen gameover;

    GameObject obj;
    PlayerController player;
    public MassagePanelManager manager;
    public CollectScoreManager currscoreManager;
    public WeaponManager weaponManager;
    public Text timer;
    private void Awake()
    {
        EventSystemCustom.Instance.OnWeaponChange.AddListener(OnweaponUse);
        EventSystemCustom.Instance.OnTimerChange.AddListener(OnTimerChange);
    }
    void Start()
    {
        
        obj = GameObject.Find("Player");
        if (obj!=null)
        {
            player = obj.GetComponent<PlayerController>();
            EventSystemCustom.Instance.OnIncreaseScore.AddListener(IncreaseScoreBoard);
            EventSystemCustom.Instance.OnGameOver.AddListener(GameOver);
            EventSystemCustom.Instance.OnMessage.AddListener(MessageEmit);
        }
       
    }

    public void IncreaseScoreBoard(float scoreToAdd)
    {
        player.Score += scoreToAdd;
        if (PlayerPrefs.GetFloat("High Score",0)< player.Score)
        {
            PlayerPrefs.SetFloat("High Score", player.Score);
        }
        FianalScoreText.text = player.Score.ToString();
        CurrentScoreCollected(scoreToAdd);
        // Debug.Log(player.Score);
    }
    public void GameOver()
    {
        gameover.SetUp(player.Score);
    }

    public void MessageEmit(string message)
    {
        manager.Setup(message);
    }

    public void CurrentScoreCollected(float score)
    {
        currscoreManager.Setup(score);
    }

    public void OnweaponUse(float score)
    {
        weaponManager.Setup(score);
    }

    public void OnTimerChange(float time)
    {

        timer.text = ((int)time).ToString();
    }
}
