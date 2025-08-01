using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCenter : MonoBehaviour
{
    public Transform[] parts = new Transform[4];
    void Update()
    {
        float avgPointX = (parts[0].position.x + parts[1].position.x + parts[2].position.x + parts[3].position.x) / 4;
        float avgPointY = (parts[0].position.y + parts[1].position.y + parts[2].position.y + parts[3].position.y) / 4;
        
        transform.position = Vector3.Lerp(transform.position, new Vector3(avgPointX, avgPointY, transform.position.z), Time.deltaTime);
        // transform.position = Vector3.Lerp(transform.position, new Vector3(avgPointX, transform.position.y, transform.position.z), Time.deltaTime);
    }
}
