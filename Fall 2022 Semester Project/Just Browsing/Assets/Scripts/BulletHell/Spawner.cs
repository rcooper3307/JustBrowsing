using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] enemies;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnRate, spawnRate);
    }
    public void SpawnEnemy()
    {
        Instantiate(enemies[(int)Random.Range(0, enemies.Length)],new Vector3(20 ,Random.Range(-8.5f,8.5f)), Quaternion.identity);
    }
}
