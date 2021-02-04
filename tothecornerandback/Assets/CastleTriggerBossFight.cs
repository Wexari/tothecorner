using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossType
{
    SPADES, HEARTS, DIAMONDS, CLUBS
}

public class CastleTriggerBossFight : MonoBehaviour
{
    public BossType type;
    public GameObject sprite;
    public CastleChanger changer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(type)
        {
            case BossType.SPADES:
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    changer.musicState = MusicState.THIRD;
                    StartCoroutine(ChangeMusicBack());
                    FindObjectOfType<DevConsole>().ExecuteCommand("say К огромному сожалению, я слишком поздно понял, что у меня не получится сохранить состояние замка после битвы. Но её всё ещё можно пройти, с помощью loadfight 13 из главного меню.");
                    break;
                }
            case BossType.HEARTS:
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    changer.musicState = MusicState.THIRD;
                    StartCoroutine(ChangeMusicBack());
                    FindObjectOfType<DevConsole>().ExecuteCommand("say К огромному сожалению, я слишком поздно понял, что у меня не получится сохранить состояние замка после битвы. Но её всё ещё можно пройти, с помощью loadfight 14 из главного меню.");

                    break;
                }

            case BossType.DIAMONDS:
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    changer.musicState = MusicState.THIRD;
                    StartCoroutine(ChangeMusicBack());
                    FindObjectOfType<DevConsole>().ExecuteCommand("say К огромному сожалению, я слишком поздно понял, что у меня не получится сохранить состояние замка после битвы. Но её всё ещё можно пройти, с помощью loadfight 16 из главного меню.");

                    break;
                }

            case BossType.CLUBS:
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    changer.musicState = MusicState.THIRD;
                    StartCoroutine(ChangeMusicBack());
                    FindObjectOfType<DevConsole>().ExecuteCommand("say К огромному сожалению, я слишком поздно понял, что у меня не получится сохранить состояние замка после битвы. Но её всё ещё можно пройти, с помощью loadfight 15 из главного меню.");

                    break;
                }
            default:
                {
                    break;
                }

        }
    }

    public IEnumerator ChangeMusicBack()
    {
        yield return new WaitForSeconds(9f);
        changer.musicState = MusicState.SECOND;
    }
}
