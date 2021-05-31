using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    Animator animEnemy;
    [SerializeField] private float movementSpeed;
    //Enemy stops moving when attacking
    private bool moving = true;

    private int currHP;
    [SerializeField] private int maxHP;

    //Reference to the gameobject the enemy is currently attacking
    private GameObject attackingTower;

    [SerializeField] private EnemyBreak enemyBreakScript;



    // Start is called before the first frame update
    void Start()
    {
        animEnemy = GetComponent<Animator>();
        currHP = maxHP;

        enemyBreakScript = GetComponent<EnemyBreak>();

    }
    private void FixedUpdate()
    {
        //base movement speed towards left side
        if (moving)
        {
            transform.Translate(-transform.right * Time.deltaTime * movementSpeed, transform);
        }
        
    }
    // Update is called once per frame
    void Update()
    {

    }

    #region HP
    private void TakeDamage(int dmgTaken)
    {
        currHP -= dmgTaken;
        if(currHP <= 0)
        {
            Destroy(gameObject);
        }
        if(enemyBreakScript != null)
        {
            enemyBreakScript.BreakTower();
        }
    }

    public int GetHP()
    {
        return currHP;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Tower"))
        {
            //moving = false;
            //attackingTower = collision.gameObject;
            //animEnemy.SetTrigger("Attack");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            moving = true;
        }
    }

    public void Attack()
    {
        if(attackingTower != null)
        {
            attackingTower.GetComponent<TowerBasic>().TakeDamage(1);
        }
        
    }
    //Called at end of attack animations
    public void TriggerAttack()
    {
        Invoke("AnimAttack", .5f);
    }
    //Called .5 seconds after attack animation
    //Either repeat or keep moving
    private void AnimAttack()
    {
        if(attackingTower != null)
        {
            animEnemy.SetTrigger("Attack");
        }
        else
        {
            moving = true;
            animEnemy.SetBool("isAttacking", false);
        }

    }

    public void GetTower(GameObject tower)
    {
        animEnemy.SetBool("isAttacking", true);
        //Debug.Log("Tower Got");
        if(tower != null)
        {
            attackingTower = tower;
        }
        moving = false;
        animEnemy.SetTrigger("Attack");
    }
    #endregion
}
