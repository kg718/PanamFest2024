using System.Collections.Generic;
using UnityEngine;

public class FishSpawning : MonoBehaviour
{
    [SerializeField] private int MaxFishCount;
    [HideInInspector] public int CurrentFishTotal;
    [SerializeField] private List<GameObject> FishTypes;
    [SerializeField] private int Range;
    [SerializeField] private float SpawnFrequency;
    private float CurrentSpawnTime;
    private Transform PlayerPos;

    void Start()
    {
        CurrentSpawnTime = SpawnFrequency;
        PlayerPos = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = PlayerPos.position;
        CurrentSpawnTime -= Time.deltaTime;
        if(CurrentSpawnTime <= 0f)
        {
            SpawnFish();
            CurrentSpawnTime = SpawnFrequency;
        }
    }

    private void SpawnFish()
    {
        if(CurrentFishTotal < MaxFishCount)
        {
            int fishselection = Random.Range(0, FishTypes.Count);
            int xcoord = Mathf.RoundToInt(Random.Range(transform.position.x - Range, transform.position.x + Range));
            int zcoord = Mathf.RoundToInt(Random.Range(transform.position.z - Range, transform.position.z + Range));
            GameObject NewFish = Instantiate(FishTypes[fishselection], new Vector3(xcoord, 0.1f, zcoord), Quaternion.identity);
            CurrentFishTotal += 1;
        }
    }
}
