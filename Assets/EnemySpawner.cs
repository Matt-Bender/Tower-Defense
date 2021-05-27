using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Vector3[] spawningLocations;
    [SerializeField] private GameObject[] enemies;

    private float timeBetweenEnemySpawn = 30;
    private float startingTimeBetweenEnemySpawn;
    private float TimeInterval;
    private bool isWave = false;
    private int waveCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        //for(int i = 0; i < spawningLocations.Length; i++)
        //{
        //    Instantiate(enemies[0], spawningLocations[i], Quaternion.identity);
        //}
        startingTimeBetweenEnemySpawn = timeBetweenEnemySpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
        TimeInterval += Time.deltaTime;
        if (TimeInterval >= timeBetweenEnemySpawn)
        {
            TimeInterval = 0;
            timeBetweenEnemySpawn -= 5;
            if(timeBetweenEnemySpawn == 5)
            {
                isWave = true;
                for(int i = 0; i < 10; i++)
                {
                    Invoke("SpawnEnemy", i);
                }
                timeBetweenEnemySpawn = 30;
            }
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int randNum = Random.Range(0, 5);
        Instantiate(enemies[0], spawningLocations[randNum], Quaternion.identity);
    }
}
