using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Transform[] centers = new Transform[3];
    private int activeCenter = 0;
    
    
    public float xRadius = 1;
    public float yRadius = .8f;
    public float radius = .8f;

    public GameObject[] parts = new GameObject[4];
    public int currentPart;

    public GameObject[] bones = new GameObject[4];

    private float x;
    public float senseX = .05f;
    private float y;
    public float senseY = .005f;
    
    
    public Rigidbody[] rb = new Rigidbody[4];    
    
    
    private Vector3 centerPos;

    private void Start()
    {

        x = parts[currentPart].transform.position.x;
        y = parts[currentPart].transform.position.y;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        // rb = GetComponent<Rigidbody[]>();
    }

    void Update()
    {
        SwapPart(); // changes controlled limb
        x += Input.GetAxisRaw("Mouse X") * senseX;
        y += Input.GetAxisRaw("Mouse Y") * senseY;
        centerPos = centers[activeCenter].position;
        var partDist = Vector3.Distance(centerPos, parts[currentPart].transform.position);
        var clampedValue = Vector3.ClampMagnitude(new Vector3(x, y, 0f), radius);
        
        if (currentPart > 1) //legs are being controlled
        {
            radius = .9f;
            if (partDist > radius)
            {
                rb[currentPart].velocity = Vector3.zero;
            }
            // rb.Move(new Vector3(x, y, 0f), new Quaternion(x, 0f, 0f, 0f));
            rb[currentPart].AddForce(new Vector3(x, y, 0f), ForceMode.Impulse);
            // rb[currentPart].transform.position = clampedValue + centerPos;
            
        }
        else //arms being controlled
        {
            radius = .65f;

            parts[currentPart].transform.position = new Vector3(x, y, 0f);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(centerPos, radius);
        
    }

    public void SwapPart()
    {
        //for dev testing purposes, this will switch the controlled limb!
        if (Input.GetKeyDown(KeyCode.Alpha1)) //right hand
        {
            currentPart = 0;
            activeCenter = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) //left hand
        {
            currentPart = 1;
            activeCenter = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) //right leg
        {
            currentPart = 2;
            activeCenter = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) //left leg
        {
            currentPart = 3;
            activeCenter = 3;
        }
    }
}