using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownManager : MonoBehaviour
{
    [SerializeField] private GameObject[] towers;
    [SerializeField] private GameObject[] towerSymbol;
    [SerializeField] private Button[] towerButton;
    //Timeintervals keeps track of current time that has passed for each cooldown
    [SerializeField] private float[] TimeInterval;
    [SerializeField] private float[] Cooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        TimeInterval = new float[towers.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        for(int i = 0; i < towers.Length; i++)
        {
            if (!towerSymbol[i].activeSelf)
            {
                TimeInterval[i] += Time.deltaTime;
                if(TimeInterval[i] >= Cooldown[i])
                {
                    TimeInterval[i] = 0;
                    CanBuyTower(towers[i], true);
                }
            }
        }
        //if (!symbolGenerator.activeSelf)
        //{
        //    genTimeInterval += Time.deltaTime;
        //    if (genTimeInterval >= generatorCooldown)
        //    {
        //        genTimeInterval = 0;
        //        buttonGenerator.interactable = true;
        //        symbolGenerator.SetActive(true);
        //    }
        //}
    }

    public void CanBuyTower(GameObject tower, bool canBuy)
    {
        for (int i = 0; i < towers.Length; i++)
        {
            if(tower == towers[i])
            {
                towerSymbol[i].SetActive(canBuy);
                towerButton[i].interactable = canBuy;
                break;
            }
        }
        ////Generator
        //if(tower == towers[0])
        //{
        //    symbolGenerator.SetActive(setActive);
        //    buttonGenerator.interactable = false;
        //}
        ////Shoot
        //else if(tower == towers[1])
        //{

        //}
    }
}
