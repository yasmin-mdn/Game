using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// first set object body y for height then set rotation
public class ObjectSpawner : MonoBehaviour
{
    public float SpawnInterval;
    [SerializeField] GameObject[] prefabs;
    [SerializeField] int[] weights;
    [SerializeField] TargetIndicator indicator;
    int randomRange;
    int[] maxNums;
    float[] minHeights, maxHeights;
    void Awake()
    {
        var length = prefabs.Length;
        minHeights = new float[length];
        maxHeights = new float[length];
        maxNums = new int[length];
        int sum = 0;
        for (int i = 0; i < length; i++){
            sum += weights[i];
            maxNums[i] = sum;

            var spawnable = prefabs[i].GetComponent<ISpawnable>();
            if(spawnable == null) spawnable = prefabs[i].GetComponentInChildren<ISpawnable>();
            minHeights[i] = spawnable.MinHeight;
            maxHeights[i] = spawnable.MaxHeight;
        }
        randomRange = sum;
    }
    void Start()
    {
        Spawn(prefabs[0], 60f, Quaternion.Euler(-5.86f, 46.17f, 0f));
    }
    void OnEnable() => StartCoroutine(SpawnCoroutine());

    int SelectRandomPrefabIndex(){
        var rand = UnityEngine.Random.Range(1, randomRange+1);
        for (int i = 0; i < randomRange; i++)
            if(rand <= maxNums[i])
                return i;
        return -1;
    }

    void Spawn(GameObject prefab, float height, Quaternion rotations){
        var obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        var body = obj.transform.Find("Body");
        body.transform.localPosition = new Vector3(0, height);
        obj.transform.rotation = rotations;
        // Debug.Log(obj.GetComponent<MonoBehaviour>().GetType().ToString()+" Object spawned");
        indicator.TryAddTarget(obj);
    }

    IEnumerator SpawnCoroutine()
    {
        while (true){
            yield return new WaitForSeconds(SpawnInterval);
            var index = SelectRandomPrefabIndex();
            float height = UnityEngine.Random.Range(minHeights[index], maxHeights[index]);
            Quaternion rotations = Quaternion.Euler(
                UnityEngine.Random.Range(0, 360),
                UnityEngine.Random.Range(0, 360),
                UnityEngine.Random.Range(0, 360)
            );
            Spawn(prefabs[index], height, rotations);
        }
    }
}

interface ISpawnable
{
    float MinHeight { get; }
    float MaxHeight { get; }
}
