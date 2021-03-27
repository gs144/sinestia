using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista : MonoBehaviour
{
    public Transform gira;
    public float speed = 0.001f;
    Vector3 dir = new Vector3(0.0f, 0.0f, 45.0f);
    Vector3 goalRotation = new Vector3(-70, 90, -90);
    Vector3 rotation = new Vector3(45f, 0, 0);
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            goalRotation -= rotation;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            goalRotation += rotation;
            // gira.Rotate(0.0f, 0.0f, -45.0f, Space.World);
        }
        gira.rotation = Quaternion.Lerp(gira.rotation, Quaternion.Euler(goalRotation), Time.time * speed);
    }
}
