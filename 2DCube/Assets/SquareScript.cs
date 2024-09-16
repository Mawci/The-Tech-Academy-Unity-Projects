using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigidbody2D.velocity = new Vector2(0f, 10f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myRigidbody2D.velocity = new Vector2(0f, -10f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myRigidbody2D.velocity = new Vector2(-10f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myRigidbody2D.velocity = new Vector2(10f, 0f);
        }

    }
}
