using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask whatisEnemy;
    public float attackRange;
    public float attackRange1;
    public float attackRange2;
    public int damage;
    public int damage1;
    public int damage2;
    public int attackType;
    public float attackGracePeriod;
    public float startTimeBtwGrace;


    void Update()
    {
        if(timeBtwAttack <= 0)
        {
        if (Input.GetKeyDown(KeyCode.C) && attackType == 1)
        {
            attack(damage, attackRange);
                
        }
        else if (Input.GetKeyDown(KeyCode.C) && attackType == 2)
        {
            attack(damage1, attackRange1);
                
        }
        else if (Input.GetKeyDown(KeyCode.C) && attackType == 3)
        {
            attack(damage2, attackRange2);
        }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        attackGracePeriod -= Time.deltaTime;
        if (attackGracePeriod <= 0)
        {
            attackType = 1;
        }
    }


    private void attack (int dmg, float range)
    {
        attackGracePeriod = startTimeBtwGrace;
        timeBtwAttack = startTimeBtwAttack;
        Collider2D []
        enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, range, whatisEnemy);
                for (int i = 0; i<enemiesToDamage.Length; i++)
                    {
                    enemiesToDamage[i].GetComponent<EnemyTest>().TakeDmg(dmg);
}
        attackType++;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
  
    //private void shoot()
    //{

    //}
}
