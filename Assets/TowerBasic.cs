using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBasic : MonoBehaviour
{
    //Will contain basic logic for each tower hp, and checks if placed
    [SerializeField] private bool isPlaced = false;
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
    }

    public bool GetIsPlaced()
    {
        return isPlaced;
    }
}
