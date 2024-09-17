using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRigidBody;
    [SerializeField] float enemySpeed =5f;
    BoxCollider2D enemyBoxCollider;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFacingLeft())
        {
            enemyRigidBody.velocity = new Vector2(-enemySpeed, 0f);
        }
        else
        {
            enemyRigidBody.velocity = new Vector2(enemySpeed, 0f);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FlipSprite();
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector2(Mathf.Sign(enemyRigidBody.velocity.x), 1f);
    }

    private bool isFacingLeft()
    {
        return transform.localScale.x > 0;
    }
}
