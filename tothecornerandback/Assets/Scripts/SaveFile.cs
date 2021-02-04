using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveFile : MonoBehaviour
{

    public CurLevel currentLevel;
    public DateTime saveDate; 

    public Vector2 PlayerLastMove;
    public float PlayerSpeed;

    public Item[] inventory = new Item[10];

    public AudioClip curMusic;
    public float curMusicTime;
    public Vector3 camPos;
    public float camSize;
    public Vector2 camBordX;
    public Vector2 camBordY;
    public Vector3 actPos;
    public Vector3 actScale;

    public int RandEncLevel;
    public bool RandEncEnabled;

    public GameObject[] PlayerParty = new GameObject[4];

    public void Clear()
    {

    }
}