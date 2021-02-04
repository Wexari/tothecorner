using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Language
{
    ENGLISH, RUSSIAN
}

public class Configurations : MonoBehaviour
{
    [SerializeField]
    public float SoundVolume
    {
        set
        {
            SoundVolume = value;
            //GameObject.Find("SFXPlayer").GetComponent<AudioSource>().volume = SoundVolume / 100;
        }
        get
        {
            return SoundVolume;
        }
    }

    [SerializeField]
    public float MusicVolume
    {
        set
        {
            MusicVolume = value;
            //GameObject.Find("MusicPlayer").GetComponent<AudioSource>().volume = MusicVolume / 100;
        }
        get
        {
#warning пизда со звуком????
            return MusicVolume;
        }
    }
    [Space(15)]
    public Language language;
    [Space(15)]
    public bool DevCons;

    public void Start()
    {
        MusicVolume = 100;
        SoundVolume = 100;
    }
}