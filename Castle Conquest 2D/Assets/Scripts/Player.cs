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
    [SerializeField] Vector2 hitKick = new Vector2(50f, 50f);
    [SerializeField] Transform hurtBox;
    [SerializeField] float attackRadius = 3f;

    Rigidbody2D rigidBody2D;
    Animator myAnimator;
    PolygonCollider2D playerFeetCollider;
    BoxCollider2D playerCollider;

    float gravityStartingScale;
    bool isHurting = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        playerFeetCollider = GetComponent<PolygonCollider2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        gravityStartingScale = rigidBody2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isHurting)
        {
            Run();
            Jump();
            Climb();
            Attack();

            if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
            {
                PlayerHit();
            }
        }
    }

    private void Attack()
    {
        if(CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            myAnimator.SetTrigger("Attacking");
            Collider2D[] enemiesToHit = Physics2D.OverlapCircleAll(hurtBox.position, attackRadius, LayerMask.GetMask("Enemy"));

            foreach(Collider2D enemy in enemiesToHit)
            {
                Debug.Log("HAHA I've Hit you");
            }
        }
    }

    public void PlayerHit()
    {
        rigidBody2D.velocity = hitKick * new Vector2(-transform.localScale.x, 1f);
        myAnimator.SetTrigger("Hitting");
        isHurting = true;
        StartCoroutine(HurtCoolDown());
    }

    IEnumerator HurtCoolDown()
    {
        yield return new WaitForSeconds(2f);
        isHurting = false;
    }

    private void Climb()
    {
        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
            Vector2 playerVelocity = new Vector2(rigidBody2D.velocity.x, controlThrow * climbSpeed);
            rigidBody2D.velocity = playerVelocity;
            myAnimator.SetBool("Climbing", true);
            rigidBody2D.gravityScale = 0f;
        }
        else
        {
            myAnimator.SetBool("Climbing", false);
            rigidBody2D.gravityScale = gravityStartingScale;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(hurtBox.position, attackRadius);
    }

}
