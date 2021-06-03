using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TutorialWindows : MonoBehaviour
{
    public GameObject tela;
    public static TutorialWindows tut;

    void OnTriggerEnter(Collider outro)
    {
        Time.timeScale = 0;
        if (TutorialPista.tutorialPista.direita == false && ControleColisao.cont.direitaPronto == false)
        {
            TutorialPista.tutorialPista.direita = true;
            ControleColisao.cont.direitaPronto = true;
            tela.SetActive(true);
            Debug.Log("direita");
        }
        else if (TutorialPista.tutorialPista.esquerda == false && ControleColisao.cont.esquerdaPronto == false)
        {
            tela.SetActive(true);
            TutorialPista.tutorialPista.esquerda = true;
            ControleColisao.cont.esquerdaPronto = true;
            Debug.Log("esquerda");
        }
        else if(PlayerTutorial.player.cima==false&& ControleColisao.cont.cimaPronto == false)
        {
            tela.SetActive(true);
            PlayerTutorial.player.cima = true;
            ControleColisao.cont.cimaPronto = true;
        }
        else if (PlayerTutorial.player.baixo == false && ControleColisao.cont.baixoPronto == false)
        {
            tela.SetActive(true);
            PlayerTutorial.player.baixo = true;
            ControleColisao.cont.baixoPronto = true;
        }
        else if(TutorialPista.tutorialPista.buraco == false && ControleColisao.cont.buracoPronto == false)
        {
            TutorialPista.tutorialPista.buraco = true;
            ControleColisao.cont.buracoPronto = true;
            tela.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }


    }
    void Start()
    {
        tut = this;
    }
}
