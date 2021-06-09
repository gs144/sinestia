using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWindowsAl : MonoBehaviour
{
    public GameObject tela;
    void OnTriggerEnter(Collider outro)
    {
        Time.timeScale = 0; 
        if (PlayerTutorial.player.cima == false && ControleColisao.cont.cimaPronto == false)
        {
            tela.SetActive(true);
            PlayerTutorial.player.cima = true;
            ControleColisao.cont.cimaPronto = true;
        }
    }
    void Update()
    { 
        if (PlayerTutorial.player.cima == false && ControleColisao.cont.cimaPronto == true)
        {
            tela.SetActive(false);
        }
    }
}
