﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider outro)
    {
        this.gameObject.SetActive(false);
    }
}
