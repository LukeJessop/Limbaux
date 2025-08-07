using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPhysics : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject controller;
    private Rigidbody controllerRb;
    private FollowMouse followMouse;

    // Start is called before the first frame update
    void Start()
    {
        controllerRb = controller.GetComponent<Rigidbody>();
        followMouse = controller.GetComponent<FollowMouse>();
    }

    private void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log(gameObject.name + " is stay");
        if (Input.GetKeyDown(KeyCode.E))
        {
            followMouse.parts[followMouse.currentPart].transform.position = other.contacts[0].point;
        }

        controllerRb.AddForce(-followMouse.mouseControl, ForceMode.Force);
    }
}