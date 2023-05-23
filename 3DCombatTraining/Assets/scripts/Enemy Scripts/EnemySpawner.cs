using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Vector3 spawnPos; // The position where the enemy is spawned
    public GameObject enemyPrefab; // The prefab of the enemy we want to spawn

    [SerializeField] private float spawnRangeX = 8.5f; //The possible x range enemies can spawn
    [SerializeField] private float spawnRangeZ = 8.5f; //The possible z range enemies can spawn
    [SerializeField] private float spawnInterval = 5.0f;      //The amount of time in between spawning a new enemy


    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        InvokeRepeating("SpawnEnemy", 5.0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity, gameObject.transform);
    }

}
