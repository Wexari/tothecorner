using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum MineType
{
    SCENETELEPORT, MAINMENU
}

public class MineEvent : MonoBehaviour
{
    public MineType type;
    public int id;
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (type)
        {
            case MineType.SCENETELEPORT:
                {
                    if (collision.name == "John(Clone)")
                    {

                        FindObjectOfType<GlobalSystem>().LoadMap(id);
                    }
                    break;
                }
            case MineType.MAINMENU:
                {
                    GlobalSystem globalSys = FindObjectOfType<GlobalSystem>();
                    globalSys.camera.GetComponent<CameraController>().FadeIn();
                    globalSys.camera.transform.position = new Vector3(0, 0, -10);
                    globalSys.camera.orthographicSize = 5f;
                    globalSys.musicPlayer.GetComponent<AudioSource>().Stop();
                    globalSys.overSys.SetActive(false);
                    SceneManager.LoadScene("MainMenu");
                    globalSys.camera.transform.position = new Vector3(0, 0, -10);
                    break;
                }
        }
    }
}
