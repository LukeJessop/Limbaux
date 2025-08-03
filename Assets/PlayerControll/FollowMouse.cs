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

    public GameObject[] parts = new GameObject[4];
    public int currentPart;
    private int prevPart;

    public GameObject[] bones = new GameObject[4];

    private float x;
    public float senseX = .05f;
    private float y;
    public float senseY = .005f;

    private void Start()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].transform.position = bones[i].transform.position;
        }

        x = parts[currentPart].transform.position.x;
        y = parts[currentPart].transform.position.y;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        SwapPart();
        x += Input.GetAxisRaw("Mouse X") * senseX;
        y += Input.GetAxisRaw("Mouse Y") * senseY;

        if (currentPart > 1) //legs are being controlled
        {
            yRadius = .8f;
            var centerPos = centers[0].position;
            var Xmin = centerPos.x - xRadius;
            var Xmax = centerPos.x + xRadius;
            var Ymin = centerPos.y - yRadius;
            var Ymax = centerPos.y + yRadius;
            if (x > Xmax)
            {
                x = Xmax;
            }
            else if (x < Xmin)
            {
                x = Xmin;
            }
            else if (y > Ymax)
            {
                y = Ymax;
            }
            else if (y < Ymin)
            {
                y = Ymin;
            }

            //creates a border to show the bounds of the controllers
            Debug.DrawLine(
                new Vector3(Xmin, Ymin, 0f),
                new Vector3(Xmax, Ymin, 0f), Color.red, .05f);
            Debug.DrawLine(
                new Vector3(Xmin, Ymax, 0f),
                new Vector3(Xmax, Ymax, 0f), Color.red, .05f);
            Debug.DrawLine(
                new Vector3(Xmin, Ymin, 0f),
                new Vector3(Xmin, Ymax, 0f), Color.blue, .05f);
            Debug.DrawLine(
                new Vector3(Xmax, Ymin, 0f),
                new Vector3(Xmax, Ymax, 0f), Color.blue, .05f);

            parts[currentPart].transform.position = new Vector3(x, y, 0f);
        }
        else //arms being controlled
        {
            xRadius = .85f;
            yRadius = .65f;
            var centerPos = centers[1].position;
            var Xmin = centerPos.x - xRadius;
            var Xmax = centerPos.x + xRadius;
            var Ymin = centerPos.y - yRadius;
            var Ymax = centerPos.y + yRadius;
            if (x > Xmax)
            {
                x = Xmax;
            }
            else if (x < Xmin)
            {
                x = Xmin;
            }
            else if (y > Ymax)
            {
                y = Ymax;
            }
            else if (y < Ymin)
            {
                y = Ymin;
            }

            //creates a border to show the bounds of the controllers
            Debug.DrawLine(
                new Vector3(Xmin, Ymin, 0f),
                new Vector3(Xmax, Ymin, 0f), Color.red, .05f);
            Debug.DrawLine(
                new Vector3(Xmin, Ymax, 0f),
                new Vector3(Xmax, Ymax, 0f), Color.red, .05f);
            Debug.DrawLine(
                new Vector3(Xmin, Ymin, 0f),
                new Vector3(Xmin, Ymax, 0f), Color.blue, .05f);
            Debug.DrawLine(
                new Vector3(Xmax, Ymin, 0f),
                new Vector3(Xmax, Ymax, 0f), Color.blue, .05f);

            parts[currentPart].transform.position = new Vector3(x, y, 0f);
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