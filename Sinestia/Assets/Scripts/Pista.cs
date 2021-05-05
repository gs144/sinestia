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
    public GameObject [] PowerUp_List;

    private void OnEnable()
    {
        PowerUp();
    }
    private void OnDisable()
    {
        Procedural.procedural.PoolPista.Add(this);
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
    void PowerUp()
    {
        
        int numer = Random.Range(0, PowerUp_List.Length);
        PowerUp_List[numer].SetActive(true);
    }
}
