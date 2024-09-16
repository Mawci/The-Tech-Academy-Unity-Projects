using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCube : MonoBehaviour
{
    int numberOfTimes = 5;
    string nameOfKey = "ENTER";
    float speed = 5.7f;

    public Vector3 RotateAmount;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"Press any {numberOfTimes} arrow key");
        //Debug.LogWarning($"No {nameOfKey} detected");
        //Debug.LogError("There is nothing set up to register input!");
        //Debug.Log($"Adding a new line of code with speed {speed}");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotateAmount);
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("The up arrow was pressed.");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("The right arrow was pressed.");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("The left arrow was pressed.");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("The down arrow was pressed.");
        }
    }
}
