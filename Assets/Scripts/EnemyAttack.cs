using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float skillRate = 0.5f;
    float nextSkillTime;


    public Camera mainCamera;

    public Transform attackPos;
    public float attackRange;
    public LayerMask enemies;
    public Animator playerAnim;
    public int damage;

    void Update()
    {
        bool canCast = Time.time >= nextSkillTime;

        if(canCast)
            Attack();
    }

    void Attack()
    {

        ResetCastTime();

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);

        foreach (Collider2D enemy in enemiesToDamage)
        {

            SoundManager.PlaySound("attack");
            playerAnim.SetTrigger("Attack");

            enemy.GetComponent<Player>().TakeDamage(20);
            mainCamera.GetComponent<ShakeBehavior>().TriggerShake();
        }

    }

    void Block()
    {
        ResetCastTime();
        playerAnim.SetTrigger("Block");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    void ResetCastTime()
    {
        nextSkillTime = Time.time + 0.5f / skillRate;
    }
}
