using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista : MonoBehaviour
{
    public Transform gira;
    public float speed = 0.01f;
    Vector3 goalRotation = new Vector3(0, 0, 0);
    Vector3 rotation = new Vector3(0, 0, 45.0f);
    public Transform conector;
    public GameObject[] PowerUp_List;
    private float posToqueIniX, posToqueFinX;
    private bool tocando = false;

    private void OnEnable()
    {
        PowerUp();
    }
    private void OnDisable()
    {
        for(int x = 0; x < PowerUp_List.Length; x++)
        {
            PowerUp_List[x].SetActive(false);
        }
        Procedural.procedural.PoolPista.Add(this);
    }
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
    void PowerUp()
    {
        int numer = Random.Range(0, PowerUp_List.Length);
        PowerUp_List[numer].SetActive(true);
    }
}
