using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPhysics : MonoBehaviour
{
    private Rigidbody rb;
    public Rigidbody controllerRb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
    }

    private void OnCollisionStay(Collision other)
    {
        var x = Input.GetAxis("Mouse X") * 5f;
        var y = Input.GetAxis("Mouse Y") * 5f;
        var mouseControl = new Vector3(x, y, 0);
        Debug.Log(controllerRb + " is stay");
        controllerRb.AddForce(-mouseControl, ForceMode.Force);
    }
}