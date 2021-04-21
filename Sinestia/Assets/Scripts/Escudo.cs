using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
   void OnCollisionEnter(Collision Outro)
    {
        this.gameObject.SetActive(false);
    }
}
