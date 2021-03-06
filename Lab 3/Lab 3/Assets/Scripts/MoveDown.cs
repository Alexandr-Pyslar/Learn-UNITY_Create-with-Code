﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody objectRb;
    private float zDestroy = -15f;
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.forward * -speed);

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }
}
