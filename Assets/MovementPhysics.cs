using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPhysics : MonoBehaviour
{
    private Rigidbody mainRigidBody;
    private Rigidbody apendageRigidBody;
    private FollowMouse followMouse;

    private int currentPart;
    // Start is called before the first frame update
    void Start()
    {
        followMouse = GetComponent<FollowMouse>();
        currentPart = followMouse.currentPart;
        apendageRigidBody = followMouse.rb[currentPart];
        mainRigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        mainRigidBody.velocity = -1 * apendageRigidBody.velocity;
    }
}
