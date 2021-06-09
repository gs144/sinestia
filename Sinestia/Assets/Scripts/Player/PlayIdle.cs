using UnityEngine;

public class PlayIdle : MonoBehaviour
{
    public  Animator anim; 
    void Start()
    {
        anim.SetBool("Idle", true);
    }
}
