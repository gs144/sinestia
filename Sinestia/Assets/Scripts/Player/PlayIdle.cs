using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayIdle : MonoBehaviour
{
    public  Animator anim;
    
    void Start()
    {
        anim.SetBool("Idle", true);
    }

    
    void Update()
    {
        
    }
}
