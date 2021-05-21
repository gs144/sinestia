using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleHUD : MonoBehaviour
{
    public Image vida;
    public Text pontos;
    static public ControleHUD controleHUD;
    

    public void Vida(int vidaPlayer)
    {
        vida.fillAmount = vidaPlayer/3.0f;
    }

    public void Pontos(int pontosPlayer)
    {
        
        pontos.text = pontosPlayer.ToString();
    }

    void Awake()
    {
        controleHUD = this;
    }

    
    void Update()
    {
        //Debug.Log(GameOverController.Pontos);
        //Pontos();
    }
}
