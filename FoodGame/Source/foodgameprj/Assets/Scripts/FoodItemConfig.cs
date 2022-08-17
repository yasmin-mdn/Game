using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "FoodItemConfig", menuName = "FoodGameConfigs/FoodItemConfig")]
public class FoodItemConfig : ScriptableObject
{
    public string foodName;
    public float weight;
    public int score;
}
