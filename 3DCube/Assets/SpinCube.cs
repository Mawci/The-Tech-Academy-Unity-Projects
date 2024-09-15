using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCube : MonoBehaviour
{
    public Vector3 RotateAmount;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press any arrow key");
        Debug.LogWarning("No input detected");
        Debug.LogError("There is nothing set up to register input!");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotateAmount);
    }
}
