using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Vector3 anda = Vector3.forward;
    float speed = 20;
    public Transform alvo;

    void Start()
    {
        InvokeRepeating("Movimenta", 0, 0.05f);
    }

    void Movimenta()
    { 
        alvo.position += anda * Time.deltaTime * speed;
    }
}
