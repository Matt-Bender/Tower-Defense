using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    GameManager gmScript;
    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private GameObject greyOut;
    private int tutorialSection = 0;
    [SerializeField] private GameObject arrow;

    private GameObject objectPlaced;
    [SerializeField] private GameObject[] towers;
    [SerializeField] private GameObject builder;

    private GameObject tutorialRobot;
    [SerializeField] private GameObject tutorialRock;

    // Start is called before the first frame update
    void Start()
    {
        gmScript = GetComponent<GameManager>();
        greyOut.SetActive(false);
        Tutorial();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StopTime();
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            ContinueTime();
        }

        CheckTutorialDone();
    }
    private void FixedUpdate()
    {
        
    }

    private void StopTime()
    {
        Time.timeScale = 0;
        greyOut.SetActive(true);
    }

    private void ContinueTime()
    {
        Time.timeScale = 1;
        greyOut.SetActive(false);
    }

    public void GetObjectPlaced(GameObject placedTower)
    {
        objectPlaced = placedTower;
    }

    private void Tutorial()
    {
        tutorialSection++;
        if(tutorialSection == 1)
        {
            tutorialText.text = "Wait for cooldown, then left click to select the generator tower";
            arrow.transform.position = new Vector3(-9.5f, 1.6f, -4);
        }
        else if (tutorialSection == 2)
        {
            tutorialText.text = "Right Click on a square to place tower";
            arrow.transform.position = new Vector3(-9.5f, 0, -4);
        }
        else if(tutorialSection == 3)
        {
            tutorialText.text = "Mouse over purple ball to collect basic resource";
            arrow.transform.position = new Vector3(-9.5f, 0, -4);
        }
        else if (tutorialSection == 4)
        {
            tutorialText.text = "Place down a couple more generators as you continue to collect these resources.";
            arrow.transform.position = new Vector3(-7, -.25f, -4);
            arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        else if (tutorialSection == 5)
        {
            tutorialText.text = "You now have enough resources to buy a boulder.";
            arrow.transform.position = new Vector3(-7.5f, 1.6f, -4);
            arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (tutorialSection == 6)
        {
            tutorialText.text = "Place the boulder in front of the robots path.";
            arrow.transform.position = new Vector3(4.5f, 0f, -4);
            builder.GetComponent<BuildEnemy>().BuildRobot();
            StopTime();
        }
        else if (tutorialSection == 7)
        {
            tutorialText.text = "After the boulder has been destroyed mouse over to collect the scrap.";
            arrow.transform.position = new Vector3(4.5f, 0f, -4);
            ContinueTime();
        }
        else if (tutorialSection == 8)
        {
            tutorialText.text = "With the scrap collected select the cannon.";
            arrow.transform.position = new Vector3(-5.5f, 1.5f, -4);
            StopTime();
        }
        else if (tutorialSection == 9)
        {
            tutorialText.text = "Place the cannon to destroy the robot.";
            arrow.transform.position = new Vector3(-5.5f, 0f, -4);
        }
        else if (tutorialSection == 10)
        {
            tutorialText.text = "After destroying the robot the cannon will continue to destroy anything in its path. Destroying the robot builders is the goal.";
            arrow.transform.position = new Vector3(8.5f, 0f, -4);
            ContinueTime();
        }
        else if(tutorialSection == 11)
        {
            tutorialText.text = "You can also use the hammer to get rid of towers. Although be warned you lose the full tower cost";
            arrow.transform.position = new Vector3(-3.5f, 2f, -4);
            Invoke("DestroyTutorialManager", 5);
        }
    }

    private void CheckTutorialDone()
    {
        if(tutorialSection == 1)
        {
            if (gmScript.GetHoldingTower())
            {
                Tutorial();
            }
        }
        else if(tutorialSection == 2)
        {
            if (!gmScript.GetHoldingTower())
            {
                Tutorial();
            }
        }
        else if (tutorialSection == 3)
        {
            if(gmScript.GetBasicResource() >= 2)
            {
                Tutorial();
            }
        }
        else if (tutorialSection == 4)
        {
            if (gmScript.GetBasicResource() >= 4)
            {
                Tutorial();
            }
        }
        else if (tutorialSection == 5)
        {
            if (gmScript.GetHeldTower() == towers[1])
            {
                Tutorial();
            }
        }
        else if (tutorialSection == 6)
        {
            if (!gmScript.GetHoldingTower())
            {
                Tutorial();
            }
        }
        else if (tutorialSection == 7)
        {
            if(gmScript.GetScrapResource() >= 3)
            {
                Tutorial();
            }
        }
        else if (tutorialSection == 8)
        {
            if (gmScript.GetHeldTower() == towers[2])
            {
                Tutorial();
            }
        }
        else if (tutorialSection == 9)
        {
            if (!gmScript.GetHoldingTower())
            {
                Tutorial();
            }
        }
        else if(tutorialSection == 10)
        {
            if(tutorialRock == null)
            {
                Tutorial();
            }
        }
    }

    public void DestroyTutorialManager()
    {
        Destroy(greyOut);
        tutorialText.text = "";
        Destroy(arrow);
        Destroy(gameObject.GetComponent<TutorialManager>());
    }
}
