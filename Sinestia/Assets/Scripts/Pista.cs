using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista : MonoBehaviour
{
    public Transform gira;
    private float speed = 0.3f;
    Vector3 dir = new Vector3(0.0f, 0.0f, 45.0f);
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            gira.rotation = Quaternion.Euler(0, 90, -90 );
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gira.Rotate(0.0f, 0.0f, -45.0f, Space.World);
        }
    }
}
