using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPista : MonoBehaviour
{
    public Transform gira;
    public float speed = 0.01f;
    Vector3 goalRotation = new Vector3(0, 0, 0);
    Vector3 rotation = new Vector3(0, 0, 45.0f);
    private float posToqueIniX, posToqueFinX;
    private bool tocando = false;
    public bool direita = false, esquerda = false, buraco = false;
    public static TutorialPista tutorialPista;
    void Start()
    {
        tutorialPista = this;
    }
    void Update()
    {
        gira.rotation = Quaternion.Lerp(gira.rotation, Quaternion.Euler(goalRotation), Time.time * speed);
        if (direita == true)
        {

#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.A))
                {
                    goalRotation += rotation;
                    direita = false;
                    Time.timeScale = 1;
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
                            Debug.Log("comecou");
                            Debug.Log(Input.touchCount);
                            break;

                        case TouchPhase.Ended:
                            posToqueFinX = Input.GetTouch(0).position.x;
                            tocando = false;
                            Debug.Log("terminou");
                            if (posToqueFinX > posToqueIniX)
                            {
                                Time.timeScale = 1;
                                goalRotation += rotation;
                                direita = false;
                            }
                            break;
                    }
                    }
#endif
        }

        if (esquerda == true)
        {
#if UNITY_EDITOR
         if (Input.GetKeyDown(KeyCode.D))
                {
                    goalRotation -= rotation;
                    esquerda = false;
                    Time.timeScale = 1;
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
                            Debug.Log("comecou");
                            Debug.Log(Input.touchCount);
                            break;

                        case TouchPhase.Ended:
                            posToqueFinX = Input.GetTouch(0).position.x;
                            tocando = false;
                            Debug.Log("terminou");
                            if (posToqueFinX < posToqueIniX)
                            {
                                Time.timeScale = 1;
                                goalRotation -= rotation;
                                esquerda = false;
                            }
                            break;
                    }
                    }
#endif
        }
        if (buraco == true)
        {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.D))
        {
            goalRotation -= rotation;
            Time.timeScale = 1;
            buraco=false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            goalRotation += rotation;
            Time.timeScale = 1;
            buraco=false;
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
                    posToqueFinX = Input.GetTouch(0).position.x;
                    tocando = false;
                    if (posToqueFinX > posToqueIniX)    
                    {
                        goalRotation += rotation;
                        Time.timeScale = 1;
                        buraco=false;
                    }
                    if (posToqueFinX < posToqueIniX)
                    {
                        goalRotation -= rotation;
                        Time.timeScale = 1;
                        buraco=false;
                    }
                    break;
            }
        }

#endif
        }
    }
}

