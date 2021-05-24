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
            temp = Instantiate(gmScript.GetTempHeldTower(), new Vector3(transform.position.x, transform.position.y, -2), transform.rotation);
        }
        Debug.Log("MOUSEOVER");
    }
    private void OnMouseExit()
    {
        Destroy(temp);
        Debug.Log("MOUSENOTOVER");
    }

    private void OnMouseDown()
    {
        if (gmScript.GetHoldingTower() && !towerPlaced)
        {
            Instantiate(gmScript.GetHeldTower(), transform.position, transform.rotation);
            gmScript.TowerPlaced();
            towerPlaced = true;
        }
    }
}
