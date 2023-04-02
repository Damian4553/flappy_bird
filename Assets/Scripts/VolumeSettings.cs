using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider master;
    [SerializeField] private Slider background;
    [SerializeField] private Slider effects;

    private void Awake()
    {
        master.onValueChanged.AddListener(SetMasterVolume);
        background.onValueChanged.AddListener(SetBackgroundVolume);
        effects.onValueChanged.AddListener(SetEffectsVolume);
    }

    void SetMasterVolume(float val)
    {
        mixer.SetFloat("Master", Mathf.Log10(val) * 20);
    }
    void SetBackgroundVolume(float val)
    {
        mixer.SetFloat("Background", Mathf.Log10(val) * 20);
    }
    void SetEffectsVolume(float val)
    {
        mixer.SetFloat("Effects", Mathf.Log10(val) * 20);
    }
}
