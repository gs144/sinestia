using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaPista : MonoBehaviour
{
    public static bool pistaBaixo;
    public static MusicaPista musicaPista;

    void Update()
    {
        if (pistaBaixo == true)
        {
            TocadorMusica.tocadorMusica.musica1.volume = 0.0f;
            TocadorMusica.tocadorMusica.musica2.volume = 1.0f;
            Debug.Log("musica1");
        }
        else
        {
            TocadorMusica.tocadorMusica.musica1.volume = 1.0f;
            TocadorMusica.tocadorMusica.musica2.volume = 0.0f;
            Debug.Log("musica2");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (pistaBaixo == true)
        {
            pistaBaixo = false;
        }
        else if (pistaBaixo == false)
        {
            pistaBaixo = true;
        }
    }
}
