using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (MusicaPista.musicaPista.pistaBaixo == false)
        {
            MusicaPista.musicaPista.pistaBaixo = true;
        }
    }
}
