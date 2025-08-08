using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotScript : MonoBehaviour
{
    public Rigidbody rb;
    public float moveForce = 30f;
    public float limit;
    public Rigidbody jointRb;
    private Vector3 force;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        force = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
        
        Vector3 offset = transform.position - jointRb.transform.position;
        float distance = offset.magnitude;
        if (distance < limit)
        {
            rb.AddForce(force * moveForce, ForceMode.Acceleration);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(-offset * moveForce, ForceMode.Force);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        jointRb.AddForce(-force * moveForce, ForceMode.Acceleration);
    }
}
