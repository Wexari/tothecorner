using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audiosource;
    public DataContainer data;

    public void Start()
    {
        DontDestroyOnLoad(this);
        audiosource = GetComponent<AudioSource>();
        data = FindObjectOfType<DataContainer>();
    }

    public void SetVolume(float volume)
    {
        audiosource.volume = volume;
    }

    public void PlayMusic(int id)
    {
        switch (id)
        {
            //null
            case 0:
                {
                    audiosource.Stop();
                    break;
                }
            //tutorial 
            case 1:
                {
                    audiosource.clip = data.musicTutorial1;
                    audiosource.Play();
                    break;
                }
            //tutorial grammaphone
            case 2:
                {
                    audiosource.clip = data.musicTutorial2;
                    audiosource.Play();
                    break;
                }
            //tutorial fight
            case 3:
                {
                    audiosource.clip = data.musicTutorial3;
                    audiosource.Play();
                    break;
                }

            //snow
            case 4:
                {
                    audiosource.clip = data.musicSnowForest1;
                    audiosource.Play();
                    break;
                }

            //lab
            case 5:
                {
                    audiosource.clip = data.musicLab1;
                    audiosource.Play();
                    break;
                }

            //hills
            case 6:
                {
                    audiosource.clip = data.musicHills1;
                    audiosource.Play();
                    break;
                }

            //forest
            case 7:
                {
                    audiosource.clip = data.musicForest1;
                    audiosource.Play();
                    break;
                }

            //castle
            case 8:
                {
                    audiosource.clip = data.musicCastle1;
                    audiosource.Play();
                    break;
                }

            //castle
            case 9:
                {
                    audiosource.clip = data.musicEpilogue1;
                    audiosource.Play();
                    break;
                }

        }
    }
}
