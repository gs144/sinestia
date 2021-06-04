using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWindowsBu : MonoBehaviour
{
    public GameObject tela;
    void OnTriggerEnter(Collider outro)
    {
        Time.timeScale = 0;
       if (TutorialPista.tutorialPista.buraco == false && ControleColisao.cont.buracoPronto == false)
        {
            TutorialPista.tutorialPista.buraco = true;
            ControleColisao.cont.buracoPronto = true;
            tela.SetActive(true);
        }
    }
    void Update()
    {
        if (TutorialPista.tutorialPista.buraco == false && ControleColisao.cont.buracoPronto == true)
        {
            tela.SetActive(false);
        }
    }
}
