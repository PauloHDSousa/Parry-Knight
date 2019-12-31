using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed = 2.5f;

    public static bool isAttacking;

    private Animator anim;
    public GameObject bloodEffect;
    
    Rigidbody2D rb;
    float dirX;
    bool isFacingRight = false;
    Vector3 localScale;
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        anim  = GetComponent<Animator>();
        dirX = -1f;
    }

    void Update()
    {
       if (health <= 0)
            Destroy(gameObject);


        if (transform.position.x < -9f)
            dirX = 1f;
       else if(transform.position.x  > 9f)
            dirX =-1f;

        if (isAttacking)
            anim.SetTrigger("Attack");
    }

    private void FixedUpdate()
    {
        if (isAttacking)
            rb.velocity = Vector2.zero;
    }


    public void TakeDamage(int damage)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 0), ForceMode2D.Impulse);

        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        anim.SetTrigger("Hurt");
        health -= damage;
    }
}
