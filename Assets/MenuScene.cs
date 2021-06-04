using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void GoLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void GoLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void GoLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void GoCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
