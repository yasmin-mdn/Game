using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlacer : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject[] comboPrefabs;
    public float minX;
    public float maxX;
    public PlayerController playerController;
    public float timerMaxTime;
    private float currentTimerValue;
    private static int[] foodIndex;
    private static int[] comboIndex;
   

    private void Start()
    {
        /*
        0->4
        1->7
        2->3
        3->4
        4->2
        5->5
        6->3
         */
        foodIndex = new int[] {0,1,2,3,4,5,6,0,0,0,1,1,1,1,1,1,2,2,3,3,3,4,5,5,5,5,6,6 };
        comboIndex = new int[] {0,1,2,0,0,0,0,1,1,2,2,2,2,2,2,2,2};
        currentTimerValue = timerMaxTime;
        

    }

    void Update()
    {
        if (currentTimerValue > 0)
        {
            currentTimerValue -= Time.deltaTime;
        }
        else
        {
            GameObject go;
            var temp = UnityEngine.Random.Range(0, 2000);

            if (temp % 6 == 0||temp%6==4)
            {
                go = Instantiate(comboPrefabs[GetRandomPrefabType("combo")]);
            }
            else
            {
                go = Instantiate(prefabs[GetRandomPrefabType("food")]);
            }

            go.transform.position = new Vector3(GetRandomPrefabInitialX(), transform.position.y, transform.position.z);

            UpdateTimerValueBasedOnScore();

            // reset timer
            currentTimerValue = timerMaxTime;
        }
    }

    private void UpdateTimerValueBasedOnScore()
    {
        
        if ((playerController.playerScore % 400 < 200 && playerController.playerScore % 400 >= 0)|| playerController.playerHeartsCount>=5)
        {
            timerMaxTime -= 0.015f;

            if (timerMaxTime < 0.5f)
                timerMaxTime = 0.5f;
        }
        

    }
    
    int GetRandomPrefabType(string st)
    {
        if (st == "combo")
        {
            return comboIndex[UnityEngine.Random.Range(0, comboIndex.Length)];
        }
        return foodIndex[UnityEngine.Random.Range(0, foodIndex.Length)];
    }

    float GetRandomPrefabInitialX()
    {
        return UnityEngine.Random.Range(minX,maxX);
    }
}
