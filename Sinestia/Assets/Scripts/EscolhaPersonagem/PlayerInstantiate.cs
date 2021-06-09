using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiate : MonoBehaviour
{
    public GameObject P1, P2;
    void Start()
    {
        if (GameController.game.PersonagemSelecionado == "P1")
        {
            Instantiate(P1, transform.position, transform.rotation);
        }
        else if (GameController.game.PersonagemSelecionado == "P2")
        {
            Instantiate(P2, transform.position, transform.rotation);
        }
    }
}
