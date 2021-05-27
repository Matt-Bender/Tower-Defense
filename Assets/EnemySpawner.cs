using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Vector3[] spawningLocations;
    [SerializeField] private GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        //for(int i = 0; i < spawningLocations.Length; i++)
        //{
        //    Instantiate(enemies[0], spawningLocations[i], Quaternion.identity);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
