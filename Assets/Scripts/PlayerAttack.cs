using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatisEnemy;
    public float attackRange;
    public int damage;

    void Update()
    {
        if(timeBtwAttack <= 0)
        {

            if (Input.GetKeyDown(KeyCode.C))
            {
            timeBtwAttack = startTimeBtwAttack;
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatisEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                    enemiesToDamage[i].GetComponent<EnemyTest>().TakeDmg(damage);
                    }
            }

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
