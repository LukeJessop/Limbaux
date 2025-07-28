using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Transform[] centers = new Transform[2];
    private int activeCenter = 0;
    private float xRadius = 1;
    private float yRadius = .8f;

    public GameObject[] parts = new GameObject[4];
    public int currentPart;

    private float currentX;
    public float senseX = .05f;
    private float currentY;
    public float senseY = .005f;

    private void Start()
    {
        currentX = parts[currentPart].transform.position.x;
        currentY = parts[currentPart].transform.position.y;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        Debug.Log(Input.GetAxisRaw("Mouse X"));

        SwapPart();
        currentX += Input.GetAxisRaw("Mouse X") * senseX;
        currentY += Input.GetAxisRaw("Mouse Y") * senseY;
        var clampedX = Mathf.Clamp(currentX, centers[activeCenter].position.x - xRadius,
            centers[activeCenter].position.x + xRadius);
        var clampedY = Mathf.Clamp(currentY,
            centers[activeCenter].position.y - yRadius, centers[activeCenter].position.y + yRadius);
        parts[currentPart].transform.position = new Vector3(clampedX, clampedY, 0f);
    }

    public void SwapPart()
    {
        //for dev testing purposes, this will switch the controlled limb!
        if (Input.GetKeyDown(KeyCode.Alpha1)) //right hand
        {
            currentPart = 0;
            yRadius = .8f;
            activeCenter = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) //left hand
        {
            currentPart = 1;
            yRadius = .8f;
            activeCenter = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) //right leg
        {
            currentPart = 2;
            yRadius = 1f;
            activeCenter = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) //left leg
        {
            currentPart = 3;
            yRadius = 1f;
            activeCenter = 1;
        }
    }
}