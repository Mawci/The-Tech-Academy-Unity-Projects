using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private AudioClip hitSFX;
    private Animator animator;
    private Rigidbody2D rBody;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.position += (transform.up * Time.deltaTime) * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position);
            animator.SetTrigger("Hit");
            speed = 0f;
            GetComponent<BoxCollider2D>().enabled = false;
            rBody.bodyType = RigidbodyType2D.Static;
            StartCoroutine(DespawnTime());
        }
        else if(collision.gameObject.CompareTag("Bounds"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DespawnTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
