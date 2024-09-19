using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] AudioClip heartPickupSFX;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        AudioSource.PlayClipAtPoint(heartPickupSFX, Camera.main.transform.position, .1f);
        Destroy(gameObject);
    }
}
