using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    public InputField nomeJogador;
    public Text pontosJogador;
    public Ranking ranking;

    void Start()
    {
        ranking = new Ranking();
        pontosJogador.text = GameController.game.pontosJogador.ToString();

    }

    
    void Update()
    {
        
    }

    public void atualizaNome(InputField nome)
    {
        RankingEntryData rankingEntryData;
        GameController.game.nomeJogador = nome.text;
        rankingEntryData.entryName = nome.text;
        rankingEntryData.entryScore = GameController.game.pontosJogador;
        ranking.AddEntry(rankingEntryData);
        
    }
}
