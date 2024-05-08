using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SoundSettingsController : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;

    public void AdjustMasterVolume(){
       mixer.SetFloat("MasterVolume", Mathf.Log10(masterSlider.value) * 20);
    }

    public void AdjustMusicVolume(){
       mixer.SetFloat("MusicVolume", Mathf.Log10(musicSlider.value) * 20);
    }

    public void AdjustSFXVolume(){
        mixer.SetFloat("SFXVolume", Mathf.Log10(SFXSlider.value) * 20);
    }

}
