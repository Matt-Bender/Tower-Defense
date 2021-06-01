using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildEnemy : MonoBehaviour
{
    [SerializeField] private GameObject robot;
    //will set to 120
    private int timeBetweenBuilds = 150;
    private float TimeInterval;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        TimeInterval += Time.deltaTime;
        if (TimeInterval >= timeBetweenBuilds)
        {
            TimeInterval = 0;
            timeBetweenBuilds -= 80;
            if (timeBetweenBuilds <= 5)
            {
                timeBetweenBuilds = 15;
            }
            


            BuildRobot();
        }
    }
    private void BuildRobot()
    {
        Debug.Log("Robot Built");
        Instantiate(robot, new Vector3(transform.position.x, transform.position.y + .25f, -3), transform.rotation);
    }
}
