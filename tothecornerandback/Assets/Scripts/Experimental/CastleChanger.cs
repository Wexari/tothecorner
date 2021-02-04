using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicState
{
    FIRST, SECOND, THIRD
}
public class CastleChanger : MonoBehaviour
{
    public bool Active;
    public Item triggerItem;

    public GameObject Darkness;

    public GameObject GlobalSafespace;

    public GameObject[] Bosses;
    public GameObject[] Triggers;
    public GameObject[] Barriers;
    public GameObject[] ForDisabling;

    public MusicPlayer musicPlayer;
    public AudioClip musicTrack;
    public MusicState musicState;
    public Vector2 FirstMusicPart;
    public Vector2 SecondMusicPart;
    public Vector2 ThirdMusicPart;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Active)
        {
            CheckMusicTiming();
        }
       else
        {

        }
    }

    public void CheckMusicTiming()
    {
        switch(musicState)
        {
            case MusicState.FIRST:
                {
                    if (musicPlayer.audiosource.time < FirstMusicPart.x || musicPlayer.audiosource.time > FirstMusicPart.y)
                        musicPlayer.audiosource.time = FirstMusicPart.x;
                    break;
                }
            case MusicState.SECOND:
                {
                    if (musicPlayer.audiosource.time < SecondMusicPart.x || musicPlayer.audiosource.time > SecondMusicPart.y)
                        musicPlayer.audiosource.time = SecondMusicPart.x;
                    break;
                }
            case MusicState.THIRD:
                {
                    if (musicPlayer.audiosource.time < ThirdMusicPart.x || musicPlayer.audiosource.time > ThirdMusicPart.y)
                        musicPlayer.audiosource.time = ThirdMusicPart.x;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void Activate()
    {
        GetComponent<BoxCollider2D>().enabled = false;

        Active = true;
        Darkness.SetActive(true);
        Darkness.GetComponent<Animation>().Play();

        GlobalSafespace.SetActive(true);
        musicPlayer.audiosource.clip = musicTrack;
        musicPlayer.audiosource.Play();

        for(int i = 0; i < Bosses.Length; i++)
        {
            Bosses[i].SetActive(true);
        }

        for (int i = 0; i < Triggers.Length; i++)
        {
            Triggers[i].SetActive(true);
        }

        for (int i = 0; i < Barriers.Length; i++)
        {
            Barriers[i].SetActive(true);
        }

        for (int i = 0; i < ForDisabling.Length; i++)
        {
            ForDisabling[i].SetActive(false);
        }



    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (FindObjectOfType<OverworldSystem>().DoesPlayerHaveItem(triggerItem))
        Activate();
    }
}
