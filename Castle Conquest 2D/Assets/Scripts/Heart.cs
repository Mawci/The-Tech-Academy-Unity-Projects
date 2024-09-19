using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] AudioClip heartPickupSFX;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        AudioSource.PlayClipAtPoint(heartPickupSFX, Camera.main.transform.position, .05f);
        FindObjectOfType<GameSession>().AddHealth();
        Destroy(gameObject);
    }
}
