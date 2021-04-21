using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Vector3 anda = Vector3.forward;
    int cont;
    public Transform alvo;
    float speed = 10;
    int vida = 0;
    public GameObject Escudo;
    void Start()
    {
        InvokeRepeating("movimenta", 0, 0.05f);
        
    }
    void Update()
    {
        Viver();
        
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
            SceneManager.LoadScene("GameOver");
        }
        if (alvo.position.y < -5.8)
        {
            SceneManager.LoadScene("GameOver");
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
        if (outro.gameObject.CompareTag("Escudo"))
        {
            for (int x = 0; x < 10; x++) Escudo.SetActive(true);
        }
        if (outro.gameObject.CompareTag("Obstaculo"))
        {
            vida--;
        }
    }
    void Pulo()
    {

    }
    void Deslizar()
    {

    }
}
