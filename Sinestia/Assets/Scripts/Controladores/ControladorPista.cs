using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPista : MonoBehaviour
{
    public static ControladorPista controladorPista;
    public Vector3 goalRotation = new Vector3(0, 0, 0);
    private float posToqueIniX, posToqueFinX;
    private bool tocando = false;
    Vector3 rotation = new Vector3(0, 0, 45.0f);
    public float startTime = 0;

    void Start()
    {
        controladorPista = this;
    }

    
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.D))
        {
            goalRotation -= rotation;
            startTime= Time.time;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            goalRotation += rotation;
            startTime= Time.time;
        }
        
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);
            switch (toque.phase)
            {
                case TouchPhase.Began:
                    tocando = true;   
                    posToqueIniX = Input.GetTouch(0).position.x;
                    break;
                case TouchPhase.Ended:  
                tocando = false;
                startTime= Time.time;
                posToqueFinX =posToqueIniX;         
                    posToqueFinX = Input.GetTouch(0).position.x;
                    tocando = false;
                    if (posToqueFinX - posToqueIniX>200)
                    {
                       goalRotation += rotation;
                    }
                    if (posToqueFinX - posToqueIniX<-200)
                    {
                        goalRotation -= rotation;
                    }
                    break;    
            }
        }

#endif
    }
}
