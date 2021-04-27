using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ControleUI : MonoBehaviour
{
    public Slider sliderMusic, sliderUI, sliderSFX, sliderGeral;
    public AudioMixer mixer;
    public string cena;
    public GameObject tela;
    void Start()
    {

    }

    public void SfxChange()
    {
        mixer.SetFloat("SfxVolume", sliderSFX.value);
    }
    public void MusicChange()
    {
        mixer.SetFloat("musicVolume", sliderMusic.value);
    }
    public void UiChange()
    {
        mixer.SetFloat("uiVolume", sliderUI.value);
    }
    public void AllChange()
    {
        mixer.SetFloat("MasterVolume", sliderGeral.value);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(cena);
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    public void Open()
    {
        tela.SetActive(true);
    }
    public void Close()
    {
        tela.SetActive(false);
    }
    public void Pausa()
    {
        tela.SetActive(true);
        Time.timeScale = 0;
    }
    public void DesPausa()
    {
        tela.SetActive(false);
        Time.timeScale = 1;
    }
}
