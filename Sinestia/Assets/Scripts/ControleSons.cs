using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ControleUI : MonoBehaviour
{
    public Slider sliderMusic, sliderUI, sliderSFX,sliderGeral;
    public AudioMixer mixer;
    public string cena;
    public GameObject tela;
    void Start()
    {
        
    }

    public void SfxCnhage()
    {
        mixer.SetFloat("sSfxVolume", sliderSFX.value);
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
        SceneManager.LoadScene("cena");
    }
    public void Open()
    {
        tela.SetActive(true);
    }
    public void Close()
    {
        tela.SetActive(false);
    }
}
