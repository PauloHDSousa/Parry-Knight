using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
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

        if (Input.GetKey(KeyCode.Space) && canCast)
            Attack();

        if (Input.GetKey(KeyCode.X) && canCast)
            Block();
    }

    void Attack()
    {

        playerAnim.SetTrigger("Attack");

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);

        foreach (Collider2D enemy in enemiesToDamage)
        {
            enemy.GetComponent<Enemy>().TakeDamage(20);
            mainCamera.GetComponent<ShakeBehavior>().TriggerShake();
        }


        ResetCastTime();
    }

    void Block()
    {
        playerAnim.SetTrigger("Block");

        ResetCastTime();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    void ResetCastTime()
    {
        nextSkillTime = Time.time + 1f / skillRate;
    }
}
