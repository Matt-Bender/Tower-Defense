using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    TowerBasic towerBasicScript;
    Animator animGen;

    private float timeInterval = 0;
    [SerializeField] private float produceCooldown;

    [SerializeField] private GameObject basicResource;
    private GameObject temp;

    private bool firstProduce = true;
    // Start is called before the first frame update
    void Start()
    {
        towerBasicScript = GetComponent<TowerBasic>();
        //animGen = GetComponent<Animator>();
        animGen = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (towerBasicScript.GetIsPlaced())
        {
            timeInterval += Time.deltaTime;
            if(timeInterval >= produceCooldown || firstProduce)
            {
                firstProduce = false;
                timeInterval = 0;
                animGen.SetTrigger("produce");
                Debug.Log("Resources Gained");
            }
        }
    }

    public void EventProduce()
    {
        float positionX = transform.position.x;
        float positionY = transform.position.y;
        if(temp != null)
        {
            positionY = temp.transform.position.y + .25f;
        }
        else
        {
            positionY += .5f;
        }
        temp = Instantiate(basicResource, new Vector3(positionX, positionY, -3), transform.rotation);
    }
}
