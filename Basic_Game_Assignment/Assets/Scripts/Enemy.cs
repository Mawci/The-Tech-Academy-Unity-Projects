using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4;
    [SerializeField] private int health = 2;
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private AudioClip deathSFX;
    private Rigidbody2D target;
    private Rigidbody2D rBody;
    private Vector2 movDir;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().GetComponent<Rigidbody2D>();
        rBody = GetComponent<Rigidbody2D>();
        movDir = target.position - rBody.position;
        float angle = Mathf.Atan2(movDir.y, movDir.x) * Mathf.Rad2Deg + 270f;// - 45f;
        rBody.rotation = angle;
        gameManager = FindObjectOfType<GameManager>();
        //audioSource = FindObjectOfType<Player>().gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (transform.up * Time.deltaTime) * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(damageAmount);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.GameOver();
        }
    }

    private void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            gameManager.RegisterKill(1);
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
