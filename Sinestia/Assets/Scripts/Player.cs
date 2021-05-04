using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    static public Player player;
    Vector3 anda = Vector3.forward;
    int cont;
    public Transform alvo;
    float speed = 10;
    private int vida = 3;
    private int pontos=0;
    public GameObject Escudo;
    public AudioSource audioVida;

    void Awake()
    {
        player = this;
        
    }
    void Start()
    {
        InvokeRepeating("Movimenta", 0, 0.05f);
        InvokeRepeating("ContPontos", 1.0f, 2.0f);
        Invoke("StartHUD", 0.5f);
        audioVida.Play();

    }
    void Update()
    {
        Viver();
        
        
    }

    void Movimenta()
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
            //audioVida.Play();
        }
    }
    void Pulo()
    {

    }
    void Deslizar()
    {

    }
    void ContPontos()
    {
        Pontos += 100;
    }
    public int Vida
    {
        get
        {
            return vida;
        }
        set
        {
            if (value > 3)
            {
                vida = 3;
            }else if (value < 0)
            {
                vida = 0;
            }
            else
            {
                vida = value;
                
            }
            ControleHUD.controleHUD.Vida(vida);
        }
    }
    public int Pontos
    {
        get
        {
            return pontos;
        }
        set
        {
            if(value > 100000000)
            {
                value = 100000000;
            }else if(value < 0)
            {
                value = 0;
            }
            else
            {
                pontos = value;
            }
            
            ControleHUD.controleHUD.Pontos(pontos);
        }
    }
    void StartHUD()
    {
        ControleHUD.controleHUD.Vida(vida);
        ControleHUD.controleHUD.Pontos(pontos);
    }
}
