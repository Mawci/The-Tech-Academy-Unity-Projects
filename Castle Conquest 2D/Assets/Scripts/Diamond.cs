using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] AudioClip diamondPickupSFX;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        AudioSource.PlayClipAtPoint(diamondPickupSFX, Camera.main.transform.position, .15f);
        Destroy(gameObject);
        
    }
}
