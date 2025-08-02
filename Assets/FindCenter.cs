using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCenter : MonoBehaviour
{
    public Transform[] parts = new Transform[4];
    void Update()
    {
        float avgHeightArms = (parts[0].position.y + parts[1].position.y) / 2;
        float avgHeightLegs = (parts[2].position.y + parts[3].position.y) / 2;
        
        // transform.position = Vector3.Lerp(transform.position, new Vector3(avgPointX, avgPointY, transform.position.z), Time.deltaTime);
        // transform.position = Vector3.Lerp(transform.position, new Vector3(avgPointX, transform.position.y, transform.position.z), Time.deltaTime);
    }
}
