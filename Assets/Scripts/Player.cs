using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;

    [SerializeField]
    private float movSpeed;

    private bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
    }


    private void HandleMovement(float horizontal)
    {
        Debug.Log(horizontal);

        myRigidBody.velocity = new Vector2(horizontal * movSpeed, myRigidBody.velocity.y);
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
        Flip(horizontal);

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
