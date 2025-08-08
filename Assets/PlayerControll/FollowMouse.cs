using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject[] apendages = new GameObject[4];
    public int currentApendage;

    

    void Update()
    {
        SwapPart(); // changes controlled limb
    }

    public void SwapPart()
    {
        //for dev testing purposes, this will switch the controlled limb!
        if (Input.GetKeyDown(KeyCode.Alpha1)) //right hand
        {
            currentApendage = 0;
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) //left hand
        {
            currentApendage = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) //right leg
        {
            currentApendage = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) //left leg
        {
            currentApendage = 3;
        }
    }
}


//for some reason the feet broke, not sure why at the moment, will look into fix. Goodnight its super late