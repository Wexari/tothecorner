using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
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

    public void PlaySound(int id)
    {
        switch(id)
        {
            //null
            case 0:
                {
                    break;
                }
            //default click
            case 1:
                {
                    audiosource.clip = data.click;
                    audiosource.Play();
                    break;
                }
            //item pickup sound
            case 2:
                {

                    break;
                }
            //teleport sound
            case 3:
                {

                    break;
                }

        }
    }
}
