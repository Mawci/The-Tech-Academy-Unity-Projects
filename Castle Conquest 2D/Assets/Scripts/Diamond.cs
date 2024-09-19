using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] AudioClip diamondPickupSFX;
    [SerializeField] int value = 500;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        AudioSource.PlayClipAtPoint(diamondPickupSFX, Camera.main.transform.position, .05f);
        FindObjectOfType<GameSession>().AddToScore(value);
        Destroy(gameObject); 
    }
}
