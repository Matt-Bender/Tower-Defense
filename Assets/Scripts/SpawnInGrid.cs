using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInGrid : MonoBehaviour
{
    [SerializeField] private GameObject gridBoxSpawn;
    GridBox gridBoxScript;
    // Start is called before the first frame update
    void Start()
    {
        gridBoxScript = gridBoxSpawn.GetComponent<GridBox>();
        transform.position = new Vector3(gridBoxSpawn.transform.position.x + 1, gridBoxSpawn.transform.position.y + .75f, -2);
        gridBoxScript.SetTowerPlaced(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
