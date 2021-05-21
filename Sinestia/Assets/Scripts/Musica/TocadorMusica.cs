using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocadorMusica : MonoBehaviour
{
    public AudioSource musica1, musica2;
    public static TocadorMusica tocadorMusica;
    void Start()
    {
        tocadorMusica = this;
    }
}
