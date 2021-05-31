using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBox : MonoBehaviour
{
    GameManager gmScript;

    GameObject temp;
    [SerializeField] private bool towerPlaced = false;
    GameObject lastTowerPlaced;
    // Start is called before the first frame update
    void Start()
    {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Allows for right click to place tower
        if (temp != null && Input.GetMouseButtonDown(1))
        {
            PlaceTower();
        }

    }
    private void FixedUpdate()
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
    //Left click place tower
    private void OnMouseDown()
    {
        PlaceTower();
    }

    private void PlaceTower()
    {
        if (gmScript.GetHoldingTower() && !towerPlaced)
        {
            //Remove resource cost from pool
            gmScript.AddBasicResource(-gmScript.GetHeldTower().GetComponent<TowerBasic>().GetResourceCost());
            gmScript.AddScrapResource(-gmScript.GetHeldTower().GetComponent<TowerBasic>().GetScrapCost());
            //Create the tower in the grid space
            lastTowerPlaced = Instantiate(gmScript.GetHeldTower(), new Vector3(transform.position.x + 1f, transform.position.y + .75f, -2), gmScript.GetHeldTower().transform.rotation);
            TowerBasic towerScript = lastTowerPlaced.GetComponent<TowerBasic>();
            //Tell scripts (gamemanager, tower, grid) that there is a tower in the grid space to prevent another tower from being placed / enemies to attack
            towerScript.SetIsPlaced(true);
            towerScript.GetGridBox(GetComponent<GridBox>());
            gmScript.TowerPlaced();
            towerPlaced = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (towerPlaced)
        //{
        //    if (collision.CompareTag("Enemy"))
        //    {
        //        Debug.Log("Trigger Enemy");
        //        if(lastTowerPlaced != null)
        //        {
        //            collision.gameObject.GetComponent<EnemyBasic>().GetTower(lastTowerPlaced);
        //        }
                
        //    }
        //}
    }

    public void SetTowerPlaced(bool isPlaced)
    {
        towerPlaced = isPlaced;
    }

    public GameObject CheckTowerForEnemy()
    {
        if (towerPlaced)
        {
            return lastTowerPlaced;
        }
        else
        {
            return null;
        }
    }
}
