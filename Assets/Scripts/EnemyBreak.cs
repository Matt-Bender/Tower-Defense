using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBreak : MonoBehaviour
{
    [SerializeField] private GameObject spriteMask;
    EnemyBasic enemyBasicScript;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyBasicScript = GetComponent<EnemyBasic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BreakTower()
    {
        spriteMask.transform.localPosition = new Vector3((enemyBasicScript.GetHP() - 10) * -.3f, spriteMask.transform.localPosition.y, spriteMask.transform.localPosition.z);
    }
}
