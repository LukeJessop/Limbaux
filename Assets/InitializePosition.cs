using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePosition : MonoBehaviour
{
    public Transform constraint;
    void Update()
    {
        transform.position = constraint.position;
    }
}
