using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    [SerializeField] AudioClip openSFX;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetTrigger("Open");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayOpenDoorSFX()
    {
        AudioSource.PlayClipAtPoint(openSFX, Camera.main.transform.position, 0.05f);
    }
}
