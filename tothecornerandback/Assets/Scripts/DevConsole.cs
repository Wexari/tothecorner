using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//игра слишком зависима от консоли - это нужно исправить
public class DevConsole : MonoBehaviour
{
    public InputField input;
    public GameObject inputObj;

    public GlobalSystem globalSys;
    void Start()
    {
        DontDestroyOnLoad(this);
        globalSys = FindObjectOfType<GlobalSystem>();
    }

    void Update()
    {
        CheckKeys();
    }

    public void CheckKeys()
    {
        if (input.IsActive())
        {
            if (Input.GetKeyUp(KeyCode.F2) && input.text != "")
            {
                ExecuteCommand(input.text);
                input.text = "";
            }

            if (Input.GetKeyUp(KeyCode.F1))
            {
                inputObj.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.F1))
            {
                inputObj.SetActive(true);
            }
        }
    }

    public void ExecuteCommand(string command)
    {
        if(command.StartsWith("loadmap"))
        {
            globalSys.LoadMap(Convert.ToInt32(command.Substring(8)));
        }
        else
        if (command.StartsWith("loadfight"))
        {
            StartCoroutine(globalSys.TriggerFight(Convert.ToInt32(command.Substring(10))));
        }
        else
        if (command.StartsWith("say"))
            try
            {
                if (!globalSys.overSys.GetComponent<OverworldSystem>().uimanager.GetComponent<UIManager>().DialogueActive && !globalSys.overSys.GetComponent<OverworldSystem>().uimanager.GetComponent<UIManager>().InfoActive)
                {
                    globalSys.overSys.GetComponent<OverworldSystem>().uimanager.GetComponent<UIManager>().TextLines = new string[1];
                    globalSys.overSys.GetComponent<OverworldSystem>().uimanager.GetComponent<UIManager>().TextLines[0] = command.Substring(4);
                    globalSys.overSys.GetComponent<OverworldSystem>().uimanager.GetComponent<UIManager>().CurrentLine = 0;
                    globalSys.overSys.GetComponent<OverworldSystem>().uimanager.GetComponent<UIManager>().SetupPrintInfo();
                }
            }
            catch (Exception ex)
            {
                Debug.Log("say command can be used only in overworld!");
            }
        else
        if(command.StartsWith("save"))
        {
            if(globalSys.state == CurState.OVERWORLD)
            {
                StartCoroutine(globalSys.SaveData(Convert.ToInt32(command.Substring(5)) - 1));
                Debug.Log("saved");
            }
            else
            {
                Debug.Log("you can save only in overworld");
            }

        }
        else
        if (command.StartsWith("loadsave"))
        {
            StartCoroutine(globalSys.LoadSaveFile(Convert.ToInt32(command.Substring(9)) - 1));
            Debug.Log("loading");
        }

        else
        if (command.StartsWith("music"))
        {
            globalSys.musicPlayer.PlayMusic(Convert.ToInt32(command.Substring(6)));
        }
        else
        if(command.StartsWith("sound"))
        {
            globalSys.soundPlayer.GetComponent<SoundPlayer>().PlaySound(Convert.ToInt32(command.Substring(6)));
        }
        else
        if (command.StartsWith("garbage"))
        {
            GC.Collect();
            Debug.Log("garbage collected!");
        }
        else
        if(command.StartsWith("mainmenu"))
        {
            SceneManager.LoadScene("MainMenu");
            globalSys.camera.transform.position = new Vector3(0, 0, -10);
            globalSys.camera.orthographicSize = 5f;
            globalSys.musicPlayer.GetComponent<AudioSource>().Stop();
            globalSys.overSys.SetActive(false);
        }
        if (command.StartsWith("newgame"))
        {
            StartCoroutine(globalSys.StartNewGame());
        }
        else
        if(command.StartsWith("fadein"))
        {
            globalSys.camera.GetComponent<CameraController>().FadeIn();
        }
        else
        if (command.StartsWith("fadeout"))
        {
            globalSys.camera.GetComponent<CameraController>().FadeOut();
        }
        else
        if (command.StartsWith("givestuff"))
        {
            for(int i = 0; i < globalSys.overSys.GetComponent<OverworldSystem>().inventory.Length; i++)
            {
                globalSys.overSys.GetComponent<OverworldSystem>().inventory[0] = FindObjectOfType<DataContainer>().EMPTY;
            }

            globalSys.overSys.GetComponent<OverworldSystem>().inventory[0] = FindObjectOfType<DataContainer>().Gambeson;
            globalSys.overSys.GetComponent<OverworldSystem>().inventory[1] = FindObjectOfType<DataContainer>().BetterSword;
        }
        //else
        //if (command.StartsWith("give"))
        //{
        //    switch(command.Substring(5))
        //    {
        //        case "heal":
        //            {
        //                Debug.Log("heal coming right up");
        //                globalSys.overSys.GetComponent<OverworldSystem>().inventory[0] = Instantiate(FindObjectOfType<DataContainer>().LesserHealingPotion);
        //                break;
        //            }
        //        default:
        //            {
        //                break;
        //            }
        //    }
        //}
    }
}