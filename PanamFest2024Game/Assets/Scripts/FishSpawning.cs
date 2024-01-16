using System.Collections.Generic;
using UnityEngine;

public class FishSpawning : MonoBehaviour
{
    [HideInInspector] public List<GameObject> ExistingFish;
    [SerializeField] private List<GameObject> FishTypes;
    [SerializeField] private int Range;
    [SerializeField] private float SpawnFrequency;
    private float CurrentSpawnTime;

    void Start()
    {
        CurrentSpawnTime = SpawnFrequency;
    }

    void Update()
    {
        CurrentSpawnTime -= Time.deltaTime;
        if(CurrentSpawnTime <= 0f)
        {
            SpawnFish();
            CurrentSpawnTime = SpawnFrequency;
        }
    }

    private void SpawnFish()
    {
        int fishselection = Random.Range(0, FishTypes.Count);
        int xcoord = Mathf.RoundToInt(Random.Range(transform.position.x - Range, transform.position.x + Range));
        int zcoord = Mathf.RoundToInt(Random.Range(transform.position.z - Range, transform.position.z + Range));
        Instantiate(FishTypes[fishselection], new Vector3(xcoord, 0.1f, zcoord), Quaternion.identity);
    }
}
