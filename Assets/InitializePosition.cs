using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePosition : MonoBehaviour
{
    public Transform constraint;
    void Start()
    {
        transform.position = constraint.position;
    }
}
