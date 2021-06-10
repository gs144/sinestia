using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPista : MonoBehaviour
{
    public static ControladorPista controladorPista;
    public Vector3 goalRotation = new Vector3(0, 0, 0);

    void Start()
    {
        controladorPista = this;
    }

    
    void Update()
    {
        
    }
}
