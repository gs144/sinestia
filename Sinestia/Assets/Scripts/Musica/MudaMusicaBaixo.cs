using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaMusicaBaixo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (MusicaPista.musicaPista.pistaBaixo == true)
        {
            MusicaPista.musicaPista.pistaBaixo = false;
        }
    }
}
