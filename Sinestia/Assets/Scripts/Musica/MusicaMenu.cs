using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaMenu : MonoBehaviour
{
    private static MusicaMenu instance;
    private Scene scene;
    void Awake()
    {
       if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }   
    void Update()
    {
        scene = SceneManager.GetActiveScene();
        if(scene.name != "Main Menu" && scene.name != "Credits")
        {
            if (scene.name != "Character")
            {
                Destroy(this.gameObject);
            }
        } 
    }
}
