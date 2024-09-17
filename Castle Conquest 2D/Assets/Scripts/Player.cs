using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 10.0f;
    [SerializeField] float jumpForce = 15.0f;
    [SerializeField] float climbSpeed = 2f;
    Rigidbody2D rigidBody2D;
    Animator myAnimator;
    PolygonCollider2D playerFeetCollider;
    BoxCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        playerFeetCollider = GetComponent<PolygonCollider2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        Climb();
    }

    private void Climb()
    {
        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
            Vector2 playerVelocity = new Vector2(rigidBody2D.velocity.x, controlThrow * climbSpeed);
            rigidBody2D.velocity = playerVelocity;
            myAnimator.SetBool("Climbing", true);
        }
        else
        {
            myAnimator.SetBool("Climbing", false);
        }
    }

    private void Jump()
    {
        if(!playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        
        bool isJumping = CrossPlatformInputManager.GetButtonDown("Jump");
        
        if(isJumping)
        {
            Vector2 jumpVelocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
            rigidBody2D.velocity = jumpVelocity;
        }
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        print(controlThrow);
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, rigidBody2D.velocity.y);
        rigidBody2D.velocity = playerVelocity;
        FlipSprite();
        ChangingToRunningState();
    }

    private void ChangingToRunningState()
    {
        bool runningHorizontally = Mathf.Abs(rigidBody2D.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", runningHorizontally);
    }

    private void FlipSprite()
    {
        bool runningHorizontally = Mathf.Abs(rigidBody2D.velocity.x) > Mathf.Epsilon;

        if(runningHorizontally)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidBody2D.velocity.x), 1f); 
        }
    }
}
