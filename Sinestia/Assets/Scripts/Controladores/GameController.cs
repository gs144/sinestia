using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public string nomeJogador;
    public int pontosJogador;
    static public GameController game;
    public string PersonagemSelecionado = "P1";

    void Awake()
    {
        if (game == null)
        {
            game = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this);
        game = this;
        
    }

    
    void Update()
    {
        
    }

    public void atualizaNome(InputField nome)
    {
        nomeJogador = nome.text;
    }
}
