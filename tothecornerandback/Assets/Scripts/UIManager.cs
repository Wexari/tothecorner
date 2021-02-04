using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public DataContainer container;
    

    public GameObject DialogueBox;
    public Text DialogueText;
    public Animator DialogueAnimator;
    public bool DialogueActive = false;

    public GameObject InfoBox;
    public Text InfoText;
    public bool InfoActive = false;

    public bool ScriptActive = false;

    public GameObject BriefMenu;

    public GameObject FullMenu;

#warning ДЕЛАЙ ГЛОБАЛЬНУЮ ВОЗМОЖНОСТЬ ВЫБРАТЬ АСПЕКТ ПИДОРАСИНА ЕБУЧАЯ
    public GameObject ClassSelection;
    public GameObject AspectSelection;
    public GameObject WeaponSelection;

    public string[] TextLines;
    public float[] DialogueMood;
    public Vector2Int[] Functions;

    public int CurrentLine = 0;
    public int CurrentMood = 0;
    public int CurrentFunc = 0;

    public bool Executed;

    /// <summary>
    private bool gramma = false;
    private float gramma1;
    private float gramma2;
    private bool classcheck = false;
    private bool aspectcheck = false;
    private bool weaponcheck = false;
    private bool weaponaquired = false;
    /// </summary>

    void Start()
    {
        container = FindObjectOfType<DataContainer>();
    }

    void Update()
    {
        ProcessPrinting();

        ProcessInfo();
        ProcessDialogue();
        ProcessFuncs();
        FinishPrinting();
        MenuHandler();

        



    }

    public void SetupPrintInfo()
    {
        InfoActive = true;
        InfoBox.SetActive(true);
        FindObjectOfType<OverworldSystem>().Freeze = true;
        FindObjectOfType<OverworldSystem>().PlayerRigidbody.velocity = new Vector2(0, 0);
    }

    public void SetupPrintDialogue()
    {
        DialogueActive = true;
        DialogueBox.SetActive(true);
        FindObjectOfType<OverworldSystem>().Freeze = true;
        FindObjectOfType<OverworldSystem>().PlayerRigidbody.velocity = new Vector2(0, 0);
    }

    public void SetupPrintScriptDialogue()
    {
        ScriptActive = true;
        DialogueActive = true;
        DialogueBox.SetActive(true);
        FindObjectOfType<OverworldSystem>().Freeze = true;
        FindObjectOfType<OverworldSystem>().PlayerRigidbody.velocity = new Vector2(0, 0);
    }

    public void SetupPrintScriptInfo()
    {
        ScriptActive = true;
        InfoActive = true;
        InfoBox.SetActive(true);
        FindObjectOfType<OverworldSystem>().Freeze = true;
        FindObjectOfType<OverworldSystem>().PlayerRigidbody.velocity = new Vector2(0, 0);
    }

    public void ProcessPrinting()
    {
        if (DialogueActive || InfoActive)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                CurrentLine++;
                CurrentMood++;
                Executed = false;
            }
        }
    }

    public void ProcessInfo()
    {
        try
        {
            if (InfoActive)
            {
                InfoText.text = TextLines[CurrentLine];
            }
        }
        catch(Exception ex)
        {

        }

    }

    public void ProcessDialogue()
    {
        try
        { 
        if (DialogueActive)
        {
            DialogueText.text = TextLines[CurrentLine];
            DialogueAnimator.SetFloat("Mood", DialogueMood[CurrentMood]);
        }
        }
        catch(Exception ex)
        {

        }
    }

    public void FinishPrinting()
    {
        if (CurrentLine >= TextLines.Length)
        {
            if (DialogueActive)
            {
                DialogueBox.SetActive(false);
                DialogueActive = false;
                ScriptActive = false;
            }
            if (InfoActive)
            {
                InfoBox.SetActive(false);
                InfoActive = false;

                ScriptActive = false;
            }

            CurrentLine = 0;
            CurrentMood = 0;
            CurrentFunc = 0;
            FindObjectOfType<OverworldSystem>().Freeze = false;
        }
    }

    public void ProcessFuncs()
    {
        try
        {
            if (ScriptActive)
            {
                if (InfoActive || DialogueActive)
                {
                    if (CurrentLine == Functions[CurrentFunc].x)
                    {
                        if (Executed == false)
                        {

                            DialogExecute(Functions[CurrentFunc].y);
                        }
                        Executed = true;
                        CurrentFunc++;
                    }
                }

            }
        }
        catch (IndexOutOfRangeException ex)
        {

        }
    }


    //я пока ничего луче не могу придумать, если будет время - заменю на что-то адекватное
#warning вынеси это из юай менеджера блядь это же тупо
    public void DialogExecute(int id)
    {
        switch(id)
        {
            case 0:
                {
                    Debug.Log("no func here");
                    break;
                }

            case 1:
                {
                    DoAspectSelection();
                    aspectcheck = true;
                    //GameObject.Find("AspectChoose").SetActive(true);
                    break;
                }

            case 2:
                {
                    DoClassSelection();
                    classcheck = true;
                    //GameObject.Find("ClassChoose").SetActive(true);
                    break;
                }

            case 3:
                {
                    DoWeaponSelection();
                    weaponcheck = true;
                    weaponaquired = true;
                    //GameObject.Find("WeaponChoose").SetActive(true);
                    break;
                }

            case 4:
                {
                    Debug.Log("music is executed");
                    if (!gramma)
                    {
                        gramma1 = FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().time;
                        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().clip = container.musicTutorial2;
                        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().time = gramma2;
                        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().Play();
                        gramma = true;
                        break;
                    }
                    if (gramma)
                    {
                        gramma2 = FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().time;
                        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().clip = container.musicTutorial1;
                        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().time = gramma1;
                        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().Play();
                        gramma = false;
                        break;
                    }
                    break;
                }

            case 5:
                {
                    if (aspectcheck && classcheck && weaponcheck && weaponaquired)
                    {
                        //я понятия не имею почему это ТАК не работает
                        //StartCoroutine(FindObjectOfType<GlobalSystem>().TriggerFight(11));

                        //а вот ТАК - работает

                        FindObjectOfType<DevConsole>().ExecuteCommand("loadfight 11");

                        break;
                    }
                    else
                    {
                        Debug.Log("You need to choose your aspect, class, and weapon first.");
                        break;
                    }
                }

            case 6:
                {
                    Debug.Log("WEAPON aquired");
                    weaponaquired = true;
                    break;
                }

            case 7:
                {
                    Debug.Log("ASPECT  is executed again");
                    GameObject.Find("AspectChoose").SetActive(false);
                    aspectcheck = true;
                    break;
                }

            case 8:
                {
                    Debug.Log("CLASS is executed again");
                    GameObject.Find("ClassChoose").SetActive(true);
                    classcheck = true;
                    break;
                }

            case 9:
                {
                    Debug.Log("WEAPON is executed again");
                    GameObject.Find("WeaponChoose").SetActive(true);
                    weaponcheck = true;
                    break;
                }

            default:
                {
                    break;
                }
        }
    }

    public void MenuHandler()
    {
        if (!DialogueActive && !InfoActive)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (BriefMenu.activeSelf || FullMenu.activeSelf)
                {
                    FindObjectOfType<OverworldSystem>().Freeze = false;
                    BriefMenu.SetActive(false);
                    FullMenu.SetActive(false);
                }
                else
                {
                    FindObjectOfType<OverworldSystem>().Freeze = true;
                    FindObjectOfType<OverworldSystem>().PlayerRigidbody.velocity = new Vector2(0, 0);
                    BriefMenu.SetActive(true);
                }
            }

            if (Input.GetKeyUp(KeyCode.RightArrow) && BriefMenu.activeSelf)
            {
                BriefMenu.SetActive(false);
                FullMenu.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow) && FullMenu.activeSelf)
            {
                FullMenu.SetActive(false);
                BriefMenu.SetActive(true);

            }
        }
    }

    void DoClassSelection()
    {
        ClassSelection.SetActive(true);
    }

    public void SelectClass(int id)
    {
        switch(id)
        {
            case 0:
                {
                    FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId].PlayerParty[0].GetComponent<Character>().Class = CharClass.SEER;

                    break;
                }

            case 1:
                {
                    FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId].PlayerParty[0].GetComponent<Character>().Class = CharClass.KNIGHT;
                    break;
                }

            default:
                {
                    break;
                }
        }
    }

    void DoAspectSelection()
    {
        AspectSelection.SetActive(true);
    }

    public void SelectAspect(int id)
    {
        switch(id)
        {
            case 0:
                {
                    FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId].PlayerParty[0].GetComponent<Character>().Aspect = CharAspect.DOOM;
                    break;
                }
            case 1:
                {
                    FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId].PlayerParty[0].GetComponent<Character>().Aspect = CharAspect.LIFE;
                    break;
                }
            case 2:
                {
                    FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId].PlayerParty[0].GetComponent<Character>().Aspect = CharAspect.SPACE;
                    break;
                }
            case 3:
                {
                    FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId].PlayerParty[0].GetComponent<Character>().Aspect = CharAspect.VOID;
                    break;
                }
            default:
                {
                    FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId].PlayerParty[0].GetComponent<Character>().Aspect = CharAspect.DEFAULT;
                    break;
                }
        }
    }

    void DoWeaponSelection()
    {
        WeaponSelection.SetActive(true);
    }

    public void SelectWeapon(int id)
    {
        switch(id)
        {
            case 0:
                {
                    FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId].PlayerParty[0].GetComponent<Character>().WeaponType = CharWeapon.BLADEKIND;
                    break;
                }
            case 1:
                {
                    FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId].PlayerParty[0].GetComponent<Character>().WeaponType = CharWeapon.POLEARMKIND;
                    break;
                }
            case 2:
                {
                    FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId].PlayerParty[0].GetComponent<Character>().WeaponType = CharWeapon.STAFFKIND;
                    break;
                }
            case 3:
                {
                    FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId].PlayerParty[0].GetComponent<Character>().WeaponType = CharWeapon.BOWKIND;
                    break;
                }
            default:
                {
                    FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId].PlayerParty[0].GetComponent<Character>().WeaponType = CharWeapon.DEFAULT;
                    break;
                }
        }
    }
}