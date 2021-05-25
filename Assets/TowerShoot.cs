using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    TowerBasic towerBasicScript;
    TowerEnemyRangeCheck towerRangeScript;
    Animator animShoot;

    private float timeInterval = 0;
    [SerializeField] private float shootCooldown;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        towerBasicScript = GetComponent<TowerBasic>();
        towerRangeScript = GetComponent<TowerEnemyRangeCheck>();
        animShoot = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (towerBasicScript.GetIsPlaced() && towerRangeScript.GetEnemyInRange())
        {
            timeInterval += Time.deltaTime;
            if (timeInterval >= shootCooldown)
            {
                timeInterval = 0;
                animShoot.SetTrigger("shoot");
            }
        }
    }
    private void Update()
    { 

    }

    public void EventShoot()
    {
        GameObject temp = Instantiate(bullet, bulletSpawnPoint.position, bullet.transform.rotation);
        Rigidbody2D tempRB = temp.GetComponent<Rigidbody2D>();
        tempRB.velocity = -transform.up * 10;
    }
}
