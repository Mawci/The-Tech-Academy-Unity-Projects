using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float radius = 3f;
    [SerializeField] Vector2 explosionForce = new Vector2(200f, 100f);
    [SerializeField] AudioClip burningSFX;
    [SerializeField] AudioClip boomSFX;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void ExplodeBomb()
    {
        //returns a collider of anything within the circle radius at the time of being called
        Collider2D playercollider = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Player"));

        //if there was something returned from the overlap function, add force to it
        if(playercollider)
        {
            playercollider.GetComponent<Rigidbody2D>().AddForce(explosionForce);
            playercollider.GetComponent<Player>().PlayerHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Burn");
    }

    void DestroyBomb()
    {
        Destroy(gameObject);
    }

    //Draw a wireframe around the bomb to show the damage radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
    void PlayBurnSFX()
    {
        AudioSource.PlayClipAtPoint(burningSFX, Camera.main.transform.position, 0.05f);
    }

    void PlayBoomSFX()
    {
        AudioSource.PlayClipAtPoint(boomSFX, Camera.main.transform.position, 0.05f);
    }
}
