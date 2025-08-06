using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject[] parts = new GameObject[4];
    public int currentPart;

    public GameObject[] bones = new GameObject[4];

    public float sense = 5f;
    public Vector3 mouseControl;

    public float x;
    public float y;


    public Rigidbody[] rb = new Rigidbody[4];
    public Rigidbody mainRb;

    private void Start()
    {
        x = parts[currentPart].transform.position.x;
        y = parts[currentPart].transform.position.y;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        mainRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        SwapPart(); // changes controlled limb
        x = Input.GetAxis("Mouse X") * sense;
        y = Input.GetAxis("Mouse Y") * sense;
        mouseControl = new Vector3(x, y, 0);
        var bodyVelocity = mainRb.velocity;
        rb[currentPart].AddForce(mouseControl , ForceMode.Force);
    }

    public void SwapPart()
    {
        //for dev testing purposes, this will switch the controlled limb!
        if (Input.GetKeyDown(KeyCode.Alpha1)) //right hand
        {
            currentPart = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) //left hand
        {
            currentPart = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) //right leg
        {
            currentPart = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) //left leg
        {
            currentPart = 3;
        }
    }
}


//for some reason the feet broke, not sure why at the moment, will look into fix. Goodnight its super late