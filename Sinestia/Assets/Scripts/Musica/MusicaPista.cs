using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaPista : MonoBehaviour
{
    public bool pistaBaixo = false;
    public static MusicaPista musicaPista;
    void Update()
    {
        if (pistaBaixo == true)
        {
            TocadorMusica.tocadorMusica.musica1.volume = 1.0f;
            TocadorMusica.tocadorMusica.musica2.volume = 0.0f;
        }
        else if (pistaBaixo == false)
        {
            TocadorMusica.tocadorMusica.musica1.volume = 0.0f;
            TocadorMusica.tocadorMusica.musica2.volume = 1.0f;
        }
    }
    void Start()
    {
        musicaPista = this;
    }
    void Musica1()
    {
        TocadorMusica.tocadorMusica.musica1.volume += 0.1f;
        TocadorMusica.tocadorMusica.musica2.volume -= 0.1f;
    }
    void Musica2()
    {
        TocadorMusica.tocadorMusica.musica1.volume -= 0.1f;
        TocadorMusica.tocadorMusica.musica2.volume += 0.1f;
    }
}
