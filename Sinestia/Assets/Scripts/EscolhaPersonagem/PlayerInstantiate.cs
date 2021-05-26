using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiate : MonoBehaviour
{
    public GameObject P1, P2;
    void Start()
    {
        Debug.Log(GameController.game.PersonagemSelecionado);
        if (GameController.game.PersonagemSelecionado == "P1")
        {
            Instantiate(P1);
        }
        else if (GameController.game.PersonagemSelecionado == "P2")
        {
            Instantiate(P2);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
