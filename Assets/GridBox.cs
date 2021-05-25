using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBox : MonoBehaviour
{
    GameManager gmScript;

    GameObject temp;
    private bool towerPlaced = false;
    // Start is called before the first frame update
    void Start()
    {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        if (gmScript.GetHoldingTower() && !towerPlaced)
        {
            temp = Instantiate(gmScript.GetTempHeldTower(), new Vector3(transform.position.x + 1f, transform.position.y + .75f, -2), gmScript.GetHeldTower().transform.rotation);
        }
        //Debug.Log("MOUSEOVER");
    }
    private void OnMouseExit()
    {
        Destroy(temp);
        //Debug.Log("MOUSENOTOVER");
    }

    private void OnMouseDown()
    {
        if (gmScript.GetHoldingTower() && !towerPlaced)
        {
            GameObject lastTowerPlaced = Instantiate(gmScript.GetHeldTower(), new Vector3(transform.position.x + 1f, transform.position.y + .75f, -2), gmScript.GetHeldTower().transform.rotation);
            lastTowerPlaced.GetComponent<TowerBasic>().SetIsPlaced(true);
            gmScript.TowerPlaced();
            towerPlaced = true;
        }
    }
}
