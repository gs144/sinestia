﻿using System.Collections;
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
    public AudioSource Som;

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
        Som.Play();
        SceneManager.LoadScene(cena);
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

    }
    public void Open()
    {
        tela.SetActive(true);
        Som.Play();
    }
    public void Close()
    {

        Som.Play();
        StartCoroutine(tempo());
    }
    public void Pausa()
    {
        tela.SetActive(true);
        Time.timeScale = 0;
        Som.Play();
    }
    public void DesPausa()
    {
        Som.Play();
        Invoke("Fechar", 0.1f);
        Time.timeScale = 1;
    }
    void Fechar()
    {
        tela.SetActive(false);
    }
    IEnumerator tempo()
    {

        yield return new WaitForSecondsRealtime(0.1f);
        tela.SetActive(false);
    }

}
