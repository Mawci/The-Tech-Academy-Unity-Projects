using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<SquareScript>().PrintingFromOutside();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
