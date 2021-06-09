using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWindowsBa : MonoBehaviour
{
    public GameObject tela;
    void OnTriggerEnter(Collider outro)
    {
        Time.timeScale = 0;
        if (PlayerTutorial.player.baixo == false && ControleColisao.cont.baixoPronto == false)
        {
            tela.SetActive(true);
            PlayerTutorial.player.baixo = true;
            ControleColisao.cont.baixoPronto = true;
        }
    }
    void Update()
    {
        if (PlayerTutorial.player.baixo == false && ControleColisao.cont.baixoPronto == true)
        {
            tela.SetActive(false);
        }
    }
}
