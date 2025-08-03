using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCenter : MonoBehaviour
{
    public Transform[] parts = new Transform[2];
    private float avgX;
    private float avgY;
    
    void Update()
    {
        avgX = (parts[0].position.x + parts[1].position.x) / 2f;
        avgY = (parts[0].position.y + parts[1].position.y) / 2f;
        
        
        
        float distance = Vector2.Distance(parts[0].position, parts[1].position);
        
        transform.rotation = Quaternion.LookRotation(parts[0].position - parts[1].position, Vector3.up);
        transform.localScale = new Vector3(.1f, .1f, Mathf.Clamp(distance, .2f, 1f));
        transform.position = Vector3.Lerp(transform.position, new Vector3(avgX, avgY, transform.position.z), Time.deltaTime * 200f);
    }
}
