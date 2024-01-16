using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawning : MonoBehaviour
{
    [SerializeField] private List<GameObject> ObstacleTypes;
    [SerializeField] private int ObstacleNum;
    [SerializeField] private Vector2 MinCoord;
    [SerializeField] private Vector2 MaxCoord;

    void Start()
    {
        for(int i = 0; i < ObstacleNum; i++)
        {
            SpawnObstacle();
        }
    }

    void Update()
    {
    }

    private void SpawnObstacle()
    {
        int obstacleselection = Random.Range(0, ObstacleTypes.Count);
        int xcoord = Mathf.RoundToInt(Random.Range(MinCoord.x, MaxCoord.x));
        int zcoord = Mathf.RoundToInt(Random.Range(MinCoord.y, MaxCoord.y));
        GameObject NewFish = Instantiate(ObstacleTypes[obstacleselection], new Vector3(xcoord, 0.377f, zcoord), Quaternion.identity);
    }
}
