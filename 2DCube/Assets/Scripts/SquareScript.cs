using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
   
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PrintNumber(16));
    }

    // Update is called once per frame
    void Update()
    {
        MovingOurCube();
        OutOfBoundsPrinter();
    }

    public void PrintingFromOutside()
    {
        Debug.Log("Hello from the other side!");
    }
    private void OutOfBoundsPrinter()
    {
        if (transform.position.x > 9.5f)
        {
            Debug.LogWarning("Our Cube is out of bounds to the right side!!");
        }
        else if (transform.position.x < -9.5f)
        {
            Debug.LogWarning("Our Cube is out of bounds to the left side");
        }
        else if (transform.position.y > 5.51f)
        {
            Debug.LogWarning("Our cube is out of bounds in the top");
        }
    }

    private void MovingOurCube()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
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
    private string PrintNumber(int num)
    {
        string myString = $"This is printing the value of {num} that was passed";
        return myString;
    }
}
