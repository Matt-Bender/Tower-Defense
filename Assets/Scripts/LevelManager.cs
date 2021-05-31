using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int currentLevel = 1;
    private int numRobotBuilders;
    [SerializeField] private GameObject[] robotBuilder;
    [SerializeField] private GameObject[] robotRocks;
    private void Awake()
    {
        for (int i = 0; i < robotBuilder.Length; i++)
        {
            robotBuilder[i].SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (currentLevel == 1)
        {
            numRobotBuilders = 1;
        }
        else if(currentLevel == 2)
        {
            numRobotBuilders = 2;
        }
        else if(currentLevel == 3)
        {
            numRobotBuilders = 5;
        }

        for(int i = 0; i < numRobotBuilders; i++)
        {
            robotBuilder[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}