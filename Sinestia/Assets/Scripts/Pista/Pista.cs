using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista : MonoBehaviour
{
    public Transform gira;
    float speed = 2.0f;
    public Transform conector;
    public GameObject[] PowerUp_List;
    private void OnEnable()
    {
        PowerUp();
    }
    private void OnDisable()
    {
        for (int x = 0; x < PowerUp_List.Length; x++)
        {
            PowerUp_List[x].SetActive(false);
        }
        Procedural.procedural.PoolPista.Add(this);
    }
    void Update()
    {
        gira.rotation = Quaternion.Lerp(gira.rotation, Quaternion.Euler(ControladorPista.controladorPista.goalRotation), (Time.time - 
            ControladorPista.controladorPista.startTime) * speed* Time.timeScale);
        
        
    }
    void PowerUp()
    {
        int numer = Random.Range(0, PowerUp_List.Length);
        PowerUp_List[numer].SetActive(true);
    }
}
