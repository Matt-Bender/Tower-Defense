using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemyRangeCheck : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;

    private bool enemyInRange;
    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 20, enemyLayer);

        if(hit.collider != null)
        {
            enemyInRange = true;
        }
        else
        {
            enemyInRange = false;
        }
    }

    public bool GetEnemyInRange()
    {
        return enemyInRange;
    }
}
