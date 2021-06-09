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
    public GameObject seta1, seta2;
    public AudioSource Som;
    public Button P1, P2;
    public void SfxChange()
    {
        mixer.SetFloat("Sfxvolume", sliderSFX.value);
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
        StartCoroutine(SceneWait());
        
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        if (Player.player.Pontos != 0)
        {
            Player.player.Pontos = 0;
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
        GameController.game.Pausado = true;
        tela.SetActive(true);
        Time.timeScale = 0;
        Som.Play();
    }
    public void DesPausa()
    {
        Som.Play();
        Invoke("Fechar", 0.1f);
        GameController.game.Pausado = false;
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
    IEnumerator SceneWait()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(cena);
    }
    public void Escolha(string selecionado)
    {
        GameController.game.PersonagemSelecionado = selecionado ;
    }
    public void GameOverButton()
    {
        this.gameObject.SetActive(false);
    }
    public void Update()
    {
        if(GameController.game.PersonagemSelecionado == "P1")
        {
            seta1.SetActive(true);
            seta2.SetActive(false);
        }
        if (GameController.game.PersonagemSelecionado == "P2")
        {
            seta2.SetActive(true);
            seta1.SetActive(false);
        }
    }
}
