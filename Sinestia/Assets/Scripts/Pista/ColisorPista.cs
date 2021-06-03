using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorPista : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        Procedural.procedural.GeraPista();
        this.transform.parent.gameObject.SetActive(false);
    }
}
