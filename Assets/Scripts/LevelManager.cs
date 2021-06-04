using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        for (int i = 0; i < robotRocks.Length; i++)
        {
            robotRocks[i].SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(currentLevel == 0)
        {
            numRobotBuilders = 1;
        }
        if (currentLevel == 1)
        {
            numRobotBuilders = 2;
            gameObject.GetComponent<TutorialManager>().DestroyTutorialManager();
        }
        else if(currentLevel == 2)
        {
            numRobotBuilders = 3;
            gameObject.GetComponent<TutorialManager>().DestroyTutorialManager();
        }
        else if(currentLevel == 3)
        {
            numRobotBuilders = 5;
            gameObject.GetComponent<TutorialManager>().DestroyTutorialManager();
        }

        for(int i = 0; i < numRobotBuilders; i++)
        {
            robotBuilder[i].SetActive(true);
        }
        for (int i = 0; i < numRobotBuilders; i++)
        {
            robotRocks[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        bool activeBuilders = false;
        for (int i = 0; i < numRobotBuilders; i++)
        {
            if(robotBuilder[i] != null)
            {
                activeBuilders = true;
                break;
            }
        }
        if(activeBuilders == false)
        {
            GoMenu();
        }
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(1);
    }
}
