using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;

    private Rigidbody2D myRigidBody;
    private Animator anim;

    [SerializeField]
    private float movSpeed;

    private bool isFacingRight = true;
    public GameObject bloodEffect;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
    }


    private void HandleMovement(float horizontal)
    {
        myRigidBody.velocity = new Vector2(horizontal * movSpeed, myRigidBody.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(horizontal));
        Flip(horizontal);
    }

    public void TakeDamage(int damage)
    {
        anim.SetTrigger("Hurt");
        health -= damage;
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight) { 
            isFacingRight  = !isFacingRight;
            Vector3 playerScale =  transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
    }
}
