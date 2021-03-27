using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 anda = Vector3.forward;
    int cont;
    public Transform alvo;
    float speed = 10;
    int vida = 0;
    void Start()
    {
        InvokeRepeating("movimenta", 0, 0.05f);
        InvokeRepeating("Viver", 0, 1.0f);
    }
    void Update()
    {
        
    }

    void movimenta()
    {
        //cont++;
        //ebug.Log(cont);

        alvo.position += anda * Time.deltaTime * speed;
    }
    void Viver()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision outro)
    {
        if (outro.gameObject.CompareTag("Vida")){
            if (vida < 3 && vida > 0)
            {
                vida++;
            }
            else
            {
                vida = vida;
            }
        }
    }
}
