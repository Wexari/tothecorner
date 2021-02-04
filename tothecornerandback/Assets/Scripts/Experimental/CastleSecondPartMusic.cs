using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleSecondPartMusic : MonoBehaviour
{
    public CastleChanger changer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        changer.musicState = MusicState.SECOND;
        gameObject.SetActive(false);
    }
}
