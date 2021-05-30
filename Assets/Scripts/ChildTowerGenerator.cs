using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTowerGenerator : MonoBehaviour
{
    TowerGenerator parentGeneratorScript;
    // Start is called before the first frame update
    void Start()
    {
        parentGeneratorScript = GetComponentInParent<TowerGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EventCallProduce()
    {
        parentGeneratorScript.EventProduce();
    }
}
