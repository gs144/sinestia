using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWindowsEs : MonoBehaviour
{
    public GameObject tela;
    void OnTriggerEnter(Collider outro)
    {
    Time.timeScale = 0;
        
        if (TutorialPista.tutorialPista.esquerda == false && ControleColisao.cont.esquerdaPronto == false)
        {
            TutorialPista.tutorialPista.esquerda = true;
            ControleColisao.cont.esquerdaPronto = true;
            tela.SetActive(true);
        }
    }
    void Update()
{
    if (TutorialPista.tutorialPista.esquerda == false && ControleColisao.cont.esquerdaPronto == true)
    {
        tela.SetActive(false);
    }
}
}
