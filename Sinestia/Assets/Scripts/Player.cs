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
    //private int pontos = 0;
    public GameObject Escudo;
    public AudioSource audios;
    public AudioClip audio_vida, audio_escudo, audio_perderVida, audio_Slide, audio_Pulo;
    private float posToqueIni, posToqueFin;

    void Awake()
    {
        player = this;

    }
    void Start()
    {
        InvokeRepeating("Movimenta", 0, 0.05f);
        InvokeRepeating("ContPontos", 1.0f, 0.1f);
        Invoke("StartHUD", 0.5f);
        //InvokeRepeating("Dano", 0, 2.0f);

    }
    void Update()
    {
        Viver();
        Debug.Log(vida);
        #if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.X))
        {
            Pulo();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Deslizar();

        }
        #endif
        #if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                posToqueIni = Input.GetTouch(0).position.y;



            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                posToqueFin = Input.GetTouch(0).position.y;
                Debug.Log(posToqueFin);
                if (posToqueFin > posToqueIni)
                {
                    Pulo();
                }
                if (posToqueFin < posToqueIni)
                {
                    Deslizar();
                }


            }
        }

        #endif

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
        if (outro.gameObject.CompareTag("Obstaculo"))
        {
            vida--;
            audios.PlayOneShot(audio_perderVida, 1.0f);
        }

    }
    void OnTriggerEnter(Collider outro)
    {
        if (outro.gameObject.CompareTag("Vida"))
        {
            audios.PlayOneShot(audio_vida, 1.0f);
            Vida++;

            /*if (vida < 3 && vida > 0)
           {
               vida++;
            }
            else
            {
             vida = vida;
            }*/
        }
        if (outro.gameObject.CompareTag("Escudo"))
        {
            audios.PlayOneShot(audio_escudo, 1.0f);
            Escudo.SetActive(true);
            Invoke("DesativaEscudo", 10.0f);
        }
    }
    void Pulo()
    {
        audios.PlayOneShot(audio_Pulo, 1.0f);
        Debug.Log("pulo");
        Debug.Log(posToqueFin);
    }
    void Deslizar()
    {
        audios.PlayOneShot(audio_Slide, 1.0f);
        Debug.Log("deliza");
        Debug.Log(posToqueIni);
    }
    void ContPontos()
    {
        GameOverController.Pontos += 10;
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
            }
            else if (value < 0)
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

    void StartHUD()
    {
        ControleHUD.controleHUD.Vida(vida);
        //ControleHUD.controleHUD.Pontos(pontos);
    }
    void DesativaEscudo()
    {
        Escudo.SetActive(false);
    }
    void Dano()
    {
        vida--;
    }
}
