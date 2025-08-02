using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPhysics : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        // transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z);
        Debug.Log(other.gameObject.name);
    }
}
