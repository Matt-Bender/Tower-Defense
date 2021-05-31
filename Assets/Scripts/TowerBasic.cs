using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBasic : MonoBehaviour
{
    //Will contain basic logic for each tower hp, and checks if placed
    [SerializeField] private bool isPlaced = false;
    [SerializeField] private int hp;
    [SerializeField] private int resourceCost;
    [SerializeField] private int scrapCost;

    [SerializeField] private int scrapDrop = 1;

    [SerializeField] private GridBox gridBoxScript;

    TowerBreak towerBreakScript;
    GameManager gmScript;

    // Start is called before the first frame update
    void Start()
    {
        towerBreakScript = GetComponent<TowerBreak>();
        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIsPlaced(bool placed)
    {
        isPlaced = placed;
        if (isPlaced)
        {
        }
    }

    public bool GetIsPlaced()
    {
        return isPlaced;
    }

    public void TakeDamage(int dmgTaken)
    {
        hp -= dmgTaken;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
        if(towerBreakScript != null)
        {
            towerBreakScript.BreakTower();
        }
    }

    public int GetHP()
    {
        return hp;
    }

    public int GetResourceCost()
    {
        return resourceCost;
    }

    public int GetScrapCost()
    {
        return scrapCost;
    }

    //Gets the current gridbox the tower is placed on
    public void GetGridBox(GridBox gridBox)
    {
        gridBoxScript = gridBox;
    }

    private void OnDestroy()
    {
        if (isPlaced && UnityEditor.EditorApplication.isPlaying == true)
        {
            for(int i = 0; i < scrapDrop; i++)
            {
                Instantiate(gmScript.GetScrap(), new Vector3(transform.position.x + (i * .5f), transform.position.y, transform.position.z), transform.rotation);
            }
            
        }
        
        if(gridBoxScript != null)
        {
            gridBoxScript.SetTowerPlaced(false);
        }
        
    }
}
