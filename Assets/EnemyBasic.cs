using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private int currHP;
    [SerializeField] private int maxHP;

    // Start is called before the first frame update
    void Start()
    {
        currHP = maxHP;
    }
    private void FixedUpdate()
    {
        transform.Translate(-transform.right * Time.deltaTime * movementSpeed, transform);
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }
    #endregion
}
