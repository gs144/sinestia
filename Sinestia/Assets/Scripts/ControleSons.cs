using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ControleSons : MonoBehaviour
{
    public Slider sliderMusic, sliderUI, sliderSFX,sliderGeral;
    public AudioMixer mixer;
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
}
