using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    static public Player player;
    static Animator anim;
    Vector3 anda = new Vector3(0, 0, 1);
    int cont;
    public Transform alvo;
    float speed = 20;
    private int vida = 3;
    public GameObject Escudo;
    public AudioSource audios;
    public AudioClip audio_vida, audio_escudo, audio_perderVida, audio_Slide, audio_Pulo;
    private float posToqueIni, posToqueFin;
    private static int pontos = 0;
    public bool shield = false;
    public Renderer text_costas;

    void Awake()
    {
        player = this;
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        anim.SetBool("Idle", false);
        InvokeRepeating("Movimenta", 0, 0.05f);
        InvokeRepeating("ContPontos", 1.0f, 0.1f);
        Invoke("StartHUD", 0.5f);
    }
    void Update()
    {
        Viver();
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
    void OnTriggerEnter(Collider outro)
    {
        if (outro.gameObject.CompareTag("Vida"))
        {
            audios.PlayOneShot(audio_vida, 1.0f);
            Vida++;
            TextItem();
        }
        if (outro.gameObject.CompareTag("Escudo"))
        {
            audios.PlayOneShot(audio_escudo, 1.0f);
            shield = true;
            Escudo.SetActive(true);
            TextItem();
            Invoke("DesativaEscudo", 10.0f);
        }
        if (outro.gameObject.CompareTag("Obstaculo"))
        {
            if (shield == true)
            {
                Escudo.SetActive(false);
                shield = false;
                Vida = Vida;

            }
            else
            {
                Vida--;
                audios.PlayOneShot(audio_perderVida, 1.0f);
                TextHit();
            }
        }
        if (outro.gameObject.CompareTag("Buraco"))
        {
            Debug.Log("aaaaaa");
            anda = new Vector3(0, -2.0f, 1.0f);
        }
    }
    void Pulo()
    {
        audios.PlayOneShot(audio_Pulo, 1.0f);
        anim.SetTrigger("Jump");
    }
    void Deslizar()
    {
        audios.PlayOneShot(audio_Slide, 1.0f);
        anim.SetTrigger("Slide");
    }
    void ContPontos()
    {
        Pontos += 10;
    }
    void TextHit()
    {
        text_costas.material.SetTextureOffset("_MainTex", new Vector2(0, -0.25f));
        StartCoroutine(TextWait());
    }
    void TextItem()
    {
        text_costas.material.SetTextureOffset("_MainTex", new Vector2(0, -0.125f));
        StartCoroutine(TextWait());
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
    public int Pontos
    {
        get
        {
            return pontos;
        }
        set
        {
            if (value > 100000000)
            {
                value = 100000000;
            }
            else if (value < 0)
            {
                value = 0;
            }
            else
            {
                pontos = value;
            }

            ControleHUD.controleHUD.Pontos(pontos);
            GameController.game.pontosJogador = pontos;
        }
    }

    void StartHUD()
    {
        ControleHUD.controleHUD.Vida(vida);
        ControleHUD.controleHUD.Pontos(pontos);
    }
    void DesativaEscudo()
    {
        Escudo.SetActive(false);
    }
    void Dano()
    {
        vida--;
    }
    IEnumerator TextWait()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        text_costas.material.SetTextureOffset("_MainTex", new Vector2(0, 0));
    }
}
