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
    void Update()
    {
        if(TutorialPista.tutorialPista.direita == false && ControleColisao.cont.direitaPronto == true)
        {
            tela.SetActive(false);
        }
    }
}
