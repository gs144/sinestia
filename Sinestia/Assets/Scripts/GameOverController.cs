using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController
{
    public int score;
    public string nome;
    private static int pontos = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public static int Pontos
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

            //ControleHUD.controleHUD.Pontos(pontos);
        }
    }
}

