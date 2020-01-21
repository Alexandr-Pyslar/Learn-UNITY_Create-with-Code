using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 50f;
    void Start()
    {
        
    }


    void Update()
    {
        float horInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horInput * rotationSpeed * Time.deltaTime);
    }
}
