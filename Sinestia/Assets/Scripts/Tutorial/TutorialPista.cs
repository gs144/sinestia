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
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.D))
        {
            goalRotation -= rotation;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            goalRotation += rotation;
            // gira.Rotate(0.0f, 0.0f, -45.0f, Space.World);
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
                        goalRotation += rotation;
                    }
                    if (posToqueFinX < posToqueIniX)
                    {
                        goalRotation -= rotation;
                    }
                    break;
            }
        }

#endif
        gira.rotation = Quaternion.Lerp(gira.rotation, Quaternion.Euler(goalRotation), Time.time * speed);
    }
}
