using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBasic : MonoBehaviour
{
    //Will contain basic logic for each tower hp, and checks if placed
    [SerializeField] private bool isPlaced = false;
    [SerializeField] private int hp;
    [SerializeField] private int resourceCost;

    [SerializeField] private GridBox gridBoxScript;

    // Start is called before the first frame update
    void Start()
    {

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
    }

    public int GetResourceCost()
    {
        return resourceCost;
    }

    //Gets the current gridbox the tower is placed on
    public void GetGridBox(GridBox gridBox)
    {
        gridBoxScript = gridBox;
    }
    private void OnDestroy()
    {
        if(gridBoxScript != null)
        {
            gridBoxScript.SetTowerPlaced(false);
        }
        
    }
}
