using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBox : MonoBehaviour
{
    GameManager gmScript;
    TutorialManager tutorialScript;

    GameObject temp;
    [SerializeField] private bool towerPlaced = false;
    GameObject lastTowerPlaced;
    // Start is called before the first frame update
    void Start()
    {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        tutorialScript = GameObject.Find("GameManager").GetComponent<TutorialManager>();
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
        //Don't place down tower if it doesn't have towerbasic script (is hammer)
        if (gmScript.GetHoldingTower() && !towerPlaced && gmScript.GetHeldTower().GetComponent<TowerBasic>() != null)
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
        else if (towerPlaced && gmScript.GetHeldTower().GetComponent<TowerBasic>() == null)
        {
            //Check if its hammer
            lastTowerPlaced.GetComponent<TowerBasic>().SetHammerDestroyed(true);
            Destroy(lastTowerPlaced);
            gmScript.TowerPlaced();
            
        }

        if(tutorialScript != null)
        {
            tutorialScript.GetObjectPlaced(lastTowerPlaced);
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
