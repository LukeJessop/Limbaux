using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Transform center;
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
        currentY += Input.GetAxisRaw("Mouse Y") * senseY; //something here is breaking the logic, it may be using worldspace/localspace wrong
        
        var clampedX = Mathf.Clamp(currentX, center.position.x - xRadius, center.position.x + xRadius);
        var clampedY = Mathf.Clamp(currentY, center.position.y - yRadius, center.position.y + yRadius);
        Debug.DrawLine(new Vector3(center.position.x - xRadius, center.position.y - yRadius, 0f), new Vector3(center.position.x + xRadius, center.position.y - yRadius, 0f), Color.red, .05f);
        Debug.DrawLine(new Vector3(center.position.x - xRadius, center.position.y + yRadius, 0f), new Vector3(center.position.x + xRadius, center.position.y + yRadius, 0f), Color.red, .05f);
        Debug.DrawLine(new Vector3(center.position.x - xRadius, center.position.y - yRadius, 0f), new Vector3(center.position.x - xRadius, center.position.y + yRadius, 0f), Color.blue, .05f);
        Debug.DrawLine(new Vector3(center.position.x + xRadius, center.position.y - yRadius, 0f), new Vector3(center.position.x + xRadius, center.position.y + yRadius, 0f), Color.blue, .05f);
        
        parts[currentPart].transform.position = new Vector3(clampedX, clampedY, 0f);
    }

    public void SwapPart()
    {
        //for dev testing purposes, this will switch the controlled limb!
        if (Input.GetKeyDown(KeyCode.Alpha1)) //right hand
        {
            prevPart = currentPart;
            currentPart = 0;
            yRadius = .8f;
            activeCenter = 0;
            OnDrawGizmosSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) //left hand
        {
            prevPart = currentPart;
            currentPart = 1;
            yRadius = .8f;
            activeCenter = 0;
            OnDrawGizmosSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) //right leg
        {
            prevPart = currentPart;
            currentPart = 2;
            yRadius = 1f;
            activeCenter = 1;
            OnDrawGizmosSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) //left leg
        {
            prevPart = currentPart;
            currentPart = 3;
            yRadius = 1f;
            activeCenter = 1;
            OnDrawGizmosSelected();
        }

        
    }
    
    public void OnDrawGizmosSelected()
    {
        
    }
}