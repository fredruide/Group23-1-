using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack = 0;
    public float startTimeBetweenAttack;
    public Transform attackPos;
    public LayerMask isEnemy;
    public float attackRangecombo1;
    public float attackRangecombo2;
    public float attackRangecombo3;
    public float damagecombo1;
    public float damagecombo2;
    public float damagecombo3;


    void Update(){

        if (timeBetweenAttack >= 0){

            if (Input.GetKeyDown(KeyCode.X)){
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRangecombo1, isEnemy);

                for (int i = 0; i < enemiesToDamage.Length; i++){
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damagecombo1);
                }

            }

            timeBetweenAttack = startTimeBetweenAttack;

        }
        else{

            timeBetweenAttack -= Time.deltaTime;
        }
    }

    //private void attack1()
    //{
    //    Animator.Instantiate<>
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRangecombo1);
    }
}
    


