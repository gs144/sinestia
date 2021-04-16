using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    public int tamanhoPista;
    public Pista[] ListaPecas;
    private Pista UltimaPeca;
    public List<Pista> PoolPista;
    public int tamanhoPool;
    static public Procedural procedural;

    public void GeraPista()
    {
        int Sorteio;
        Pista reaproveitada;

        if (PoolPista.Count < tamanhoPool)
        {
            UltimaPeca = Instantiate(ListaPecas[Random.Range(1, ListaPecas.Length)], UltimaPeca.conector.position, UltimaPeca.conector.rotation, this.transform);
        }
        else
        {
            Sorteio = Random.Range(0, PoolPista.Count);
            reaproveitada = PoolPista[Sorteio];
            reaproveitada.gameObject.SetActive(true);
            reaproveitada.transform.position = UltimaPeca.conector.position;
            reaproveitada.transform.rotation = UltimaPeca.conector.rotation;
            UltimaPeca = reaproveitada;
            PoolPista.RemoveAt(Sorteio);

        }
    }
    private void PistaInicial()
    {
        UltimaPeca = Instantiate(ListaPecas[0], this.transform);

        for (int i = 1; i < tamanhoPista; i++)
        {
            GeraPista();
        }
    }
    void Start()
    {

    }


}
