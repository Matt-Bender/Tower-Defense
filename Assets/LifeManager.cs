using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private GameObject[] heart;
    [SerializeField] private Sprite emptyHeart;
    private int hearts = 3;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHeart()
    {
        if (hearts == 3)
        {
            heart[0].GetComponent<SpriteRenderer>().sprite = emptyHeart;
            hearts--;
        }
        else if(hearts == 2)
        {
            heart[1].GetComponent<SpriteRenderer>().sprite = emptyHeart;
            hearts--;
        }
        else if(hearts == 1)
        {
            heart[2].GetComponent<SpriteRenderer>().sprite = emptyHeart;
            hearts--;
            GetComponent<LevelManager>().GoMenu();
        }
    }

}
