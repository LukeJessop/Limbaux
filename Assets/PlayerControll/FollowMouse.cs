using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Transform[] centers = new Transform[2];
    private int activeCenter = 0;
    public float xRadius = 1;
    public float yRadius = .8f;

    public GameObject[] parts = new GameObject[4];
    public int currentPart;
    private int prevPart;

    public GameObject[] bones = new GameObject[4];

    private float currentX;
    public float senseX = .05f;
    private float currentY;
    public float senseY = .005f;

    private void Start()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].transform.position = bones[i].transform.position;
        }

        currentX = parts[currentPart].transform.position.x;
        currentY = parts[currentPart].transform.position.y;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        SwapPart();
        currentX += Input.GetAxisRaw("Mouse X") * senseX;
        currentY += Input.GetAxisRaw("Mouse Y") * senseY;

        if (currentPart > 1) //legs are being controlled
        {
            yRadius = .8f;
            var clampedX = Mathf.Clamp(currentX, centers[0].position.x - xRadius, centers[0].position.x + xRadius);
            var clampedY = Mathf.Clamp(currentY, centers[0].position.y, centers[0].position.y + yRadius);
            
            //creates a border to show the bounds of the controllers
            Debug.DrawLine(new Vector3(centers[0].position.x - xRadius, centers[0].position.y - yRadius, 0f),
                new Vector3(centers[0].position.x + xRadius, centers[0].position.y - yRadius, 0f), Color.red, .05f);
            Debug.DrawLine(new Vector3(centers[0].position.x - xRadius, centers[0].position.y + yRadius, 0f),
                new Vector3(centers[0].position.x + xRadius, centers[0].position.y + yRadius, 0f), Color.red, .05f);
            Debug.DrawLine(new Vector3(centers[0].position.x - xRadius, centers[0].position.y - yRadius, 0f),
                new Vector3(centers[0].position.x - xRadius, centers[0].position.y + yRadius, 0f), Color.blue, .05f);
            Debug.DrawLine(new Vector3(centers[0].position.x + xRadius, centers[0].position.y - yRadius, 0f),
                new Vector3(centers[0].position.x + xRadius, centers[0].position.y + yRadius, 0f), Color.blue, .05f);
            // parts[currentPart].transform.position = new Vector3(clampedX, clampedY, 0f);
            parts[currentPart].transform.Translate(new Vector3(clampedX, clampedY, 0f));
        }
        else //arms being controlled
        {
            xRadius = .85f;
            yRadius = .65f;
            var clampedX = Mathf.Clamp(currentX, centers[1].position.x - xRadius, centers[1].position.x + xRadius);
            var clampedY = Mathf.Clamp(currentY, centers[1].position.y - yRadius, centers[1].position.y + yRadius);
            
            //creates a border to show the bounds of the controllers
            Debug.DrawLine(new Vector3(centers[1].position.x - xRadius, centers[1].position.y - yRadius, 0f),
                new Vector3(centers[1].position.x + xRadius, centers[1].position.y - yRadius, 0f), Color.red, .05f);
            Debug.DrawLine(new Vector3(centers[1].position.x - xRadius, centers[1].position.y + yRadius, 0f),
                new Vector3(centers[1].position.x + xRadius, centers[1].position.y + yRadius, 0f), Color.red, .05f);
            Debug.DrawLine(new Vector3(centers[1].position.x - xRadius, centers[1].position.y - yRadius, 0f),
                new Vector3(centers[1].position.x - xRadius, centers[1].position.y + yRadius, 0f), Color.blue, .05f);
            Debug.DrawLine(new Vector3(centers[1].position.x + xRadius, centers[1].position.y - yRadius, 0f),
                new Vector3(centers[1].position.x + xRadius, centers[1].position.y + yRadius, 0f), Color.blue, .05f);

            // parts[currentPart].transform.position = new Vector3(clampedX, clampedY, 0f);
            parts[currentPart].transform.Translate(new Vector3(clampedX, clampedY, 0f));
        }
        
    }

    public void SwapPart()
    {
        //for dev testing purposes, this will switch the controlled limb!
        if (Input.GetKeyDown(KeyCode.Alpha1)) //right hand
        {
            prevPart = currentPart;
            currentPart = 0;
            activeCenter = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) //left hand
        {
            prevPart = currentPart;
            currentPart = 1;
            activeCenter = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) //right leg
        {
            prevPart = currentPart;
            currentPart = 2;
            activeCenter = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) //left leg
        {
            prevPart = currentPart;
            currentPart = 3;
            activeCenter = 1;
        }
    }
}