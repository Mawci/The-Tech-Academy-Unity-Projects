using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRigidBody;
    [SerializeField] float enemySpeed =5f;
    [SerializeField] AudioClip deathSFX;
    BoxCollider2D enemyBoxCollider;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyBoxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    public void Dying()
    {
        animator.SetTrigger("Die");
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, 0.05f);
        GetComponent<CapsuleCollider2D>().enabled = false;
        enemyBoxCollider.enabled = false;
        enemyRigidBody.bodyType = RigidbodyType2D.Static;
        StartCoroutine(DespawnTime());
    }

    IEnumerator DespawnTime()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void EnemyMove()
    {
        if (isFacingLeft())
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
