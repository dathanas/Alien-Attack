//Despina Athanasleri 154427
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer introAudioMixer;
    public AudioMixer gameAudioMixer;
    

    //Συνδεση του slider με το Audio Mixer
    public void SetVolumeIntro (float introVolume)
    {
        introAudioMixer.SetFloat("introVolume", introVolume); 

    }

    //Συνδεση του slider με το Audio Mixer
    public void SetVolumeGame(float gameVolume)
    {
        gameAudioMixer.SetFloat("gameVolume", gameVolume);

    }
}
