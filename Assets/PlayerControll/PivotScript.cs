using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotScript : MonoBehaviour
{
    public float moveForce = 30f;
    public Rigidbody jointRb;
    public FollowMouse followMouse;
    public int id;
    private Rigidbody rb;
    private Vector3 force;
    private Boolean isGrabbing;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (followMouse.currentApendage == id)
        {
            force = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
            rb.AddForce(force * moveForce, ForceMode.Force);
            jointRb.AddForce(-force * moveForce, ForceMode.Force);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        jointRb.AddForce(-force * moveForce, ForceMode.Force);
    }
}