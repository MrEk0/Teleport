using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float speed = 10f;

    Rigidbody2D rd;
    Transform myTransform;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rd.velocity = Vector2.down*speed;
    }
}
