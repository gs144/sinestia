using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialWindows : MonoBehaviour
{
    public GameObject tela;

    void OnCollisionEnter(Collision outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            tela.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Hello: ");
        }
    }
}
