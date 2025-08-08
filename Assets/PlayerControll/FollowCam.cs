using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // public GameObject controller;
    // private FollowMouse controllerScript;
    public GameObject target;

    private void Start()
    {
        // controllerScript = controller.GetComponent<FollowMouse>();
    }

    // Update is called once per frame
    void Update()
    {
        // target = controllerScript.apendages[controllerScript.currentApendage];
        var targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 10);
    }
}
