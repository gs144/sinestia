using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleColisao : MonoBehaviour
{
    public bool direitaPronto = false, esquerdaPronto = false, cimaPronto = false, baixoPronto = false;
    public static ControleColisao cont;
    void Start()
    {
        cont = this;
    }
}
