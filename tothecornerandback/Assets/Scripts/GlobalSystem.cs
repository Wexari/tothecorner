using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;



public enum CurState
{
    MENU, OVERWORLD, BATTLE
}

public class GlobalSystem : MonoBehaviour
{
    public CurState state = CurState.MENU;

    public new Camera camera;
    private CameraController camCon;

    public DevConsole devConsole;

    public GameObject dataContainer;
    private DataContainer data;

    public GameObject configurations;

    public MusicPlayer musicPlayer;
    public SoundPlayer soundPlayer;

    [Space(10)]
    public GameObject overSys;

    public BattleSystem battleSys;

    //для сохранения статуса перед битвами, чтобы его можно было прогрузить после
    public SaveFile tmpSave;
    
    public int SaveId; 

    public void Start()
    {
        camCon = camera.GetComponent<CameraController>();
        data = dataContainer.GetComponent<DataContainer>();

        tmpSave = data.tmpSave;

        DontDestroyOnLoad(this);
        DontDestroyOnLoad(overSys);

        DontDestroyOnLoad(camera);
        DontDestroyOnLoad(camCon);

        DontDestroyOnLoad(devConsole);

        DontDestroyOnLoad(dataContainer);
        DontDestroyOnLoad(data);


        DontDestroyOnLoad(GameObject.Find("EventSystem"));
        StartCoroutine(ForceOversys());
    }
    public void LoadMap(int id)
    {
        switch(id)
        {
            case 0:
                {
                    SceneManager.LoadScene("tutorial2");
                    StartCoroutine(SetupOverworldSystem(id));
                    overSys.SetActive(true);
                    break;
                }

            case 1:
                {
                    SceneManager.LoadScene("snowforest");
                    StartCoroutine(SetupOverworldSystem(id));
                    overSys.SetActive(true);
                    break;
                }

            case 2:
                {
                    SceneManager.LoadScene("lab");
                    StartCoroutine(SetupOverworldSystem(id));
                    overSys.SetActive(true);
                    break;
                }

            case 3:
                {
                    SceneManager.LoadScene("sandhills");
                    StartCoroutine(SetupOverworldSystem(id));
                    overSys.SetActive(true);
                    break;
                }

            case 4:
                {
                    SceneManager.LoadScene("oakforest");
                    StartCoroutine(SetupOverworldSystem(id));
                    overSys.SetActive(true);
                    break;
                }

            case 5:
                {
                    SceneManager.LoadScene("castle");
                    StartCoroutine(SetupOverworldSystem(id));
                    overSys.SetActive(true);
                    break;
                }

            case 6:
                {
                    SceneManager.LoadScene("epilogue");
                    StartCoroutine(SetupOverworldSystem(id));
                    overSys.SetActive(true);
                    break;
                }

            default:
                {
                    Debug.Log("Wrong map id");
                    break;
                }
        }

        camera.GetComponent<CameraController>().FadeIn();


    }
#warning сделай это по-человечески, и нормализуй весь код в целом а то это какаято параша

    public IEnumerator SetupOverworldSystem(int id)
    {
        yield return new WaitForSeconds(2f);
        state = CurState.OVERWORLD;
        switch (id)
        {
            case 0:
                {
                    musicPlayer.PlayMusic(1);


                    camera.orthographicSize = 1.5f;

                    camCon.borderX1 = -0.9f;
                    camCon.borderX2 = 0.9f;
                    camCon.borderY1 = -1.25f;
                    camCon.borderY2 = 1.2f;

                    overSys.GetComponent<OverworldSystem>().Actor = Instantiate(data.ActorPrefab);
                    overSys.GetComponent<OverworldSystem>().PlayerRigidbody = overSys.GetComponent<OverworldSystem>().Actor.GetComponent<Rigidbody2D>();


                    overSys.GetComponent<OverworldSystem>().PlayerSpeed = 3;
                    overSys.GetComponent<OverworldSystem>().Actor.transform.position = new Vector3(0, 0);
                    overSys.GetComponent<OverworldSystem>().Actor.transform.localScale = new Vector3(2, 2, 1);
                    camCon.followTarget = overSys.GetComponent<OverworldSystem>().Actor;

                    overSys.GetComponent<OverworldSystem>().RandEncEnabled = false;
                    overSys.GetComponent<OverworldSystem>().RandEncLevel = 0;

                    overSys.GetComponent<OverworldSystem>().currentLevel = CurLevel.TUTORIAL;
                    break;
                }
            case 1:
                {
                    musicPlayer.PlayMusic(4);


                    camera.GetComponent<Camera>().orthographicSize = 0.75f;

                    camCon.borderX1 = -4.1f;
                    camCon.borderX2 = 4f;
                    camCon.borderY1 = -1f;
                    camCon.borderY2 = 12f;


                    overSys.GetComponent<OverworldSystem>().Actor = Instantiate(data.ActorPrefab);
                    overSys.GetComponent<OverworldSystem>().PlayerSpeed = 2;
                    overSys.GetComponent<OverworldSystem>().Actor.transform.position = new Vector3(-0.16f, 10.265f);
                    overSys.GetComponent<OverworldSystem>().Actor.transform.localScale = new Vector3(1, 1, 1);



                    camCon.followTarget = overSys.GetComponent<OverworldSystem>().Actor;

                    overSys.GetComponent<OverworldSystem>().RandEncEnabled = true;
                    overSys.GetComponent<OverworldSystem>().RandEncLevel = 1;

                    overSys.GetComponent<OverworldSystem>().currentLevel = CurLevel.SNOW;

                    ForceActorComponents();
                    overSys.GetComponent<OverworldSystem>().PlayerLastMove = new Vector2(0, -1);
                    

                    break;
                }

            case 2:
                {
                    musicPlayer.PlayMusic(5);


                    camera.GetComponent<Camera>().orthographicSize = 0.75f;

                    camCon.borderX1 = -4.1f;
                    camCon.borderX2 = 4f;
                    camCon.borderY1 = -1f;
                    camCon.borderY2 = 12f;


                    overSys.GetComponent<OverworldSystem>().Actor = Instantiate(data.ActorPrefab);
                    overSys.GetComponent<OverworldSystem>().PlayerSpeed = 2;
                    overSys.GetComponent<OverworldSystem>().Actor.transform.position = new Vector3(-0.88f, 3.25f);
                    overSys.GetComponent<OverworldSystem>().Actor.transform.localScale = new Vector3(1, 1, 1);
                    camCon.followTarget = overSys.GetComponent<OverworldSystem>().Actor;

                    overSys.GetComponent<OverworldSystem>().RandEncEnabled = false;
                    overSys.GetComponent<OverworldSystem>().RandEncLevel = 0;

                    overSys.GetComponent<OverworldSystem>().currentLevel = CurLevel.LAB;

                    ForceActorComponents();
                    overSys.GetComponent<OverworldSystem>().PlayerLastMove = new Vector2(0, -1);

                    break;
                }

                /////sandhills
            case 3:
                {
                    musicPlayer.PlayMusic(6);


                    camera.GetComponent<Camera>().orthographicSize = 0.75f;

                    camCon.borderX1 = -6.75f;
                    camCon.borderX2 = -1.1f;
                    camCon.borderY1 = -9.2f;
                    camCon.borderY2 = -0.5f;


                    overSys.GetComponent<OverworldSystem>().Actor = Instantiate(data.ActorPrefab);
                    overSys.GetComponent<OverworldSystem>().PlayerSpeed = 2;
                    overSys.GetComponent<OverworldSystem>().Actor.transform.position = new Vector3(-6.475f, -1.398f, 0);
                    overSys.GetComponent<OverworldSystem>().Actor.transform.localScale = new Vector3(1, 1, 1);
                    camCon.followTarget = overSys.GetComponent<OverworldSystem>().Actor;

                    overSys.GetComponent<OverworldSystem>().RandEncEnabled = true;
                    overSys.GetComponent<OverworldSystem>().RandEncLevel = 2;

                    overSys.GetComponent<OverworldSystem>().currentLevel = CurLevel.HILLS;
                    break;
                }

                /////forest
            case 4:
                {
                    musicPlayer.PlayMusic(7);


                    camera.GetComponent<Camera>().orthographicSize = 0.75f;

                    camCon.borderX1 = -5.3f;
                    camCon.borderX2 = -2.3f;
                    camCon.borderY1 = -4.3f;
                    camCon.borderY2 = 12.1f;


                    overSys.GetComponent<OverworldSystem>().Actor = Instantiate(data.ActorPrefab);
                    overSys.GetComponent<OverworldSystem>().PlayerSpeed = 2;
                    overSys.GetComponent<OverworldSystem>().Actor.transform.position = new Vector3(-4.5f, 12f, 0);
                    overSys.GetComponent<OverworldSystem>().Actor.transform.localScale = new Vector3(1, 1, 1);
                    camCon.followTarget = overSys.GetComponent<OverworldSystem>().Actor;

                    overSys.GetComponent<OverworldSystem>().RandEncEnabled = true;
                    overSys.GetComponent<OverworldSystem>().RandEncLevel = 2;

                    overSys.GetComponent<OverworldSystem>().currentLevel = CurLevel.FOREST;
                    break;
                }

                /////castle
            case 5:
                {
                    musicPlayer.PlayMusic(8);


                    camera.GetComponent<Camera>().orthographicSize = 0.75f;

                    camCon.borderX1 = -2.4f;
                    camCon.borderX2 = 3.2f;
                    camCon.borderY1 = -9.5f;
                    camCon.borderY2 = -3.3f;


                    overSys.GetComponent<OverworldSystem>().Actor = Instantiate(data.ActorPrefab);
                    overSys.GetComponent<OverworldSystem>().PlayerSpeed = 2;
                    overSys.GetComponent<OverworldSystem>().Actor.transform.position = new Vector3(0.25f, -10f, 0);
                    overSys.GetComponent<OverworldSystem>().Actor.transform.localScale = new Vector3(1, 1, 1);
                    camCon.followTarget = overSys.GetComponent<OverworldSystem>().Actor;

                    overSys.GetComponent<OverworldSystem>().RandEncEnabled = true;
                    overSys.GetComponent<OverworldSystem>().RandEncLevel = 3;

                    overSys.GetComponent<OverworldSystem>().currentLevel = CurLevel.CASTLE;
                    break;
                }

            /////epilogue snow
            case 6:
                {
                    musicPlayer.PlayMusic(9);


                    camera.GetComponent<Camera>().orthographicSize = 0.75f;

                    camCon.borderX1 = -4.1f;
                    camCon.borderX2 = 0.2f;
                    camCon.borderY1 = -12f;
                    camCon.borderY2 = -4f;


                    overSys.GetComponent<OverworldSystem>().Actor = Instantiate(data.ActorPrefab);
                    overSys.GetComponent<OverworldSystem>().PlayerSpeed = 2;
                    overSys.GetComponent<OverworldSystem>().Actor.transform.position = new Vector3(-1.713f, -6.059f, 0);
                    overSys.GetComponent<OverworldSystem>().Actor.transform.localScale = new Vector3(1, 1, 1);
                    camCon.followTarget = overSys.GetComponent<OverworldSystem>().Actor;

                    overSys.GetComponent<OverworldSystem>().RandEncEnabled = false;
                    overSys.GetComponent<OverworldSystem>().RandEncLevel = 0;

                    overSys.GetComponent<OverworldSystem>().currentLevel = CurLevel.EPILOGUE;
                    break;
                }
            default:
                {
                    Debug.Log("но что-то кажется идёт не так");
                    break;
                }
        }
        ForceActorComponents();
    }
#warning THISSSSSSSS
#warning нет сука серьёзно какого хуя ты это скопировал дважды

    public IEnumerator LoadSaveFile(int id)
    {
        if(id == -1)
        {
            switch (data.tmpSave.currentLevel)
            {
                case CurLevel.TUTORIAL:
                    {
                        SceneManager.LoadScene("tutorial2");
                        break;
                    }
                case CurLevel.SNOW:
                    {
                        SceneManager.LoadScene("snowforest");
                        break;
                    }
                case CurLevel.LAB:
                    {
                        SceneManager.LoadScene("lab");
                        break;
                    }
                case CurLevel.HILLS:
                    {
                        SceneManager.LoadScene("sandhills");
                        break;
                    }
                case CurLevel.FOREST:
                    {
                        SceneManager.LoadScene("oakforest");
                        break;
                    }

                case CurLevel.CASTLE:
                    {
                        SceneManager.LoadScene("castle");
                        break;
                    }
                default:
                    {
                        Debug.Log("smth went wrong");
                        break;
                    }
            }
            yield return new WaitForSeconds(2f);

            overSys.SetActive(true);
            overSys.GetComponent<OverworldSystem>().Actor = Instantiate(data.ActorPrefab);

            overSys.GetComponent<OverworldSystem>().inventory = data.tmpSave.inventory;

            overSys.GetComponent<OverworldSystem>().PlayerAnimator = overSys.GetComponent<OverworldSystem>().Actor.GetComponent<Animator>();
            overSys.GetComponent<OverworldSystem>().PlayerRigidbody = overSys.GetComponent<OverworldSystem>().Actor.GetComponent<Rigidbody2D>();
            overSys.GetComponent<OverworldSystem>().PlayerCollider = overSys.GetComponent<OverworldSystem>().Actor.GetComponent<BoxCollider2D>();
            overSys.GetComponent<OverworldSystem>().PlayerLastMove = data.tmpSave.PlayerLastMove;
            overSys.GetComponent<OverworldSystem>().PlayerAnimator.SetFloat("LastMoveX", overSys.GetComponent<OverworldSystem>().PlayerLastMove.x);
            overSys.GetComponent<OverworldSystem>().PlayerAnimator.SetFloat("LastMoveY", overSys.GetComponent<OverworldSystem>().PlayerLastMove.y);
            overSys.GetComponent<OverworldSystem>().PlayerSpeed = data.tmpSave.PlayerSpeed;
            overSys.GetComponent<OverworldSystem>().Freeze = false;

            musicPlayer.audiosource.clip = data.tmpSave.curMusic;
            musicPlayer.audiosource.time = data.tmpSave.curMusicTime;
            musicPlayer.audiosource.Play();

            camera.orthographicSize = data.tmpSave.camSize;
            camera.transform.position = data.tmpSave.camPos;

            camCon.borderX1 = data.tmpSave.camBordX.x;
            camCon.borderX2 = data.tmpSave.camBordX.y;
            camCon.borderY1 = data.tmpSave.camBordY.x;
            camCon.borderY2 = data.tmpSave.camBordY.y;

            overSys.GetComponent<OverworldSystem>().Actor.transform.position = data.tmpSave.actPos;
            overSys.GetComponent<OverworldSystem>().Actor.transform.localScale = data.tmpSave.actScale;
            camCon.followTarget = overSys.GetComponent<OverworldSystem>().Actor;

            ForceActorComponents();
        }
        else
        {
            SaveId = id;
            switch (data.saves[id].currentLevel)
            {
                case CurLevel.TUTORIAL:
                    {
                        SceneManager.LoadScene("tutorial2");

                        break;
                    }
                case CurLevel.SNOW:
                    {
                        SceneManager.LoadScene("snowforest");

                        break;
                    }
                case CurLevel.LAB:
                    {
                        SceneManager.LoadScene("lab");

                        break;
                    }
                case CurLevel.HILLS:
                    {
                        SceneManager.LoadScene("sandhills");

                        break;
                    }
                case CurLevel.FOREST:
                    {
                        SceneManager.LoadScene("oakforest");

                        break;
                    }

                case CurLevel.CASTLE:
                    {
                        SceneManager.LoadScene("castle");

                        break;
                    }
                default:
                    {
                        Debug.Log("smth went wrong");
                        break;
                    }
            }
            yield return new WaitForSeconds(2f);

            overSys.SetActive(true);
            overSys.GetComponent<OverworldSystem>().Actor = Instantiate(data.ActorPrefab);

            overSys.GetComponent<OverworldSystem>().inventory = data.saves[id].inventory;

            overSys.GetComponent<OverworldSystem>().PlayerAnimator = overSys.GetComponent<OverworldSystem>().Actor.GetComponent<Animator>();
            overSys.GetComponent<OverworldSystem>().PlayerRigidbody = overSys.GetComponent<OverworldSystem>().Actor.GetComponent<Rigidbody2D>();
            overSys.GetComponent<OverworldSystem>().PlayerCollider = overSys.GetComponent<OverworldSystem>().Actor.GetComponent<BoxCollider2D>();
            overSys.GetComponent<OverworldSystem>().PlayerLastMove = data.saves[id].PlayerLastMove;
            overSys.GetComponent<OverworldSystem>().PlayerAnimator.SetFloat("LastMoveX", overSys.GetComponent<OverworldSystem>().PlayerLastMove.x);
            overSys.GetComponent<OverworldSystem>().PlayerAnimator.SetFloat("LastMoveY", overSys.GetComponent<OverworldSystem>().PlayerLastMove.y);
            overSys.GetComponent<OverworldSystem>().PlayerSpeed = data.saves[id].PlayerSpeed;
            overSys.GetComponent<OverworldSystem>().Freeze = false;

            musicPlayer.audiosource.clip = data.saves[id].curMusic;
            musicPlayer.audiosource.time = data.saves[id].curMusicTime;
            musicPlayer.audiosource.Play();

            camera.orthographicSize = data.saves[id].camSize;
            camera.transform.position = data.saves[id].camPos;

            camCon.borderX1 = data.saves[id].camBordX.x;
            camCon.borderX2 = data.saves[id].camBordX.y;
            camCon.borderY1 = data.saves[id].camBordY.x;
            camCon.borderY2 = data.saves[id].camBordY.y;

            overSys.GetComponent<OverworldSystem>().Actor.transform.position = data.saves[id].actPos;
            overSys.GetComponent<OverworldSystem>().Actor.transform.localScale = data.saves[id].actScale;
            camCon.followTarget = overSys.GetComponent<OverworldSystem>().Actor;

            ForceActorComponents();
        }



    }

#warning БЛАХ БЛАХ ХУЯЧ СОХРАНЕНИЕ ЁПТА
    public IEnumerator SaveData(int id)
    {
        yield return new WaitForSeconds(1f);

        if(id != -1)
        {
            data.saves[id].currentLevel = overSys.GetComponent<OverworldSystem>().currentLevel;
            data.saves[id].saveDate = DateTime.Now;

            data.saves[id].PlayerLastMove = overSys.GetComponent<OverworldSystem>().PlayerLastMove;
            data.saves[id].PlayerSpeed = overSys.GetComponent<OverworldSystem>().PlayerSpeed;

            data.saves[id].inventory = overSys.GetComponent<OverworldSystem>().inventory;

            data.saves[id].curMusic = musicPlayer.GetComponent<AudioSource>().clip;
            data.saves[id].curMusicTime = musicPlayer.GetComponent<AudioSource>().time;
            data.saves[id].camPos = camera.transform.position;
            data.saves[id].camSize = camera.orthographicSize;
            data.saves[id].camBordX = new Vector2(camCon.borderX1, camCon.borderX2);
            data.saves[id].camBordY = new Vector2(camCon.borderY1, camCon.borderY2);
            data.saves[id].actPos = overSys.GetComponent<OverworldSystem>().Actor.transform.position;
            data.saves[id].actScale = overSys.GetComponent<OverworldSystem>().Actor.transform.localScale;

            EditorUtility.SetDirty(data.saves[id]);
        }
        else
        {
            data.tmpSave.inventory = overSys.GetComponent<OverworldSystem>().inventory;

            data.tmpSave.currentLevel = overSys.GetComponent<OverworldSystem>().currentLevel;
            data.tmpSave.PlayerLastMove = overSys.GetComponent<OverworldSystem>().PlayerLastMove;
            data.tmpSave.PlayerSpeed = overSys.GetComponent<OverworldSystem>().PlayerSpeed;
            data.tmpSave.curMusic = musicPlayer.GetComponent<AudioSource>().clip;
            data.tmpSave.curMusicTime = musicPlayer.GetComponent<AudioSource>().time;
            data.tmpSave.camPos = camera.transform.position;
            data.tmpSave.camSize = camera.orthographicSize;
            data.tmpSave.camBordX = new Vector2(camCon.borderX1, camCon.borderX2);
            data.tmpSave.camBordY = new Vector2(camCon.borderY1, camCon.borderY2);
            data.tmpSave.actPos = overSys.GetComponent<OverworldSystem>().Actor.transform.position;
            data.tmpSave.actScale = overSys.GetComponent<OverworldSystem>().Actor.transform.localScale;

            EditorUtility.SetDirty(data.tmpSave);
        }
#warning битва всегда идёт 4 на 4, когда персов не хватает - на их место ставятся болванчики
    }


    public void TriggerCustomFight(Character[] playerTeam, Character[] enemyTeam, int ArenaId)
    {
        SceneManager.LoadScene("arena" + ArenaId);
        //батлсистем = файндобжект оф тайп блаблабла нутыпонел
    }

    public IEnumerator TriggerFight(int id)
    {
        overSys.SetActive(false);
        bool isCustom;

        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Arena")
        {
            isCustom = true;
        }
        else
        {
            StartCoroutine(SaveData(-1));
            isCustom = false;
        }

        yield return new WaitForSeconds(1f);

        switch (id)
        {
            //custom mode fight
            case -1:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(2f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs[0] = data.Hum1;
                    battleSys.playerPrefabs[1] = data.Hum2;
                    battleSys.playerPrefabs[2] = data.Hum3;
                    battleSys.playerPrefabs[3] = data.Hum4;

                    battleSys.enemyPrefabs[0] = data.Com1;
                    battleSys.enemyPrefabs[1] = data.Com2;
                    battleSys.enemyPrefabs[2] = data.Com3;
                    battleSys.enemyPrefabs[3] = data.Com4;

                    musicPlayer.PlayMusic(3);
                    isCustom = true;
                    break;

                }
            //fight against yourself
            case 0:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs = data.saves[SaveId].PlayerParty;

                    musicPlayer.PlayMusic(3);
                    break;
                }

            //fight against 1 imp
            case 1:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    Debug.Log("are you even doing anything after that");
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.Nully;
                    battleSys.enemyPrefabs[2] = data.Imp;
                    battleSys.enemyPrefabs[3] = data.Nully;

                    musicPlayer.PlayMusic(3);
                    break;
                }

            //fight against 2 imps
            case 2:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.Imp;
                    battleSys.enemyPrefabs[2] = data.Imp;
                    battleSys.enemyPrefabs[3] = data.Nully;

                    musicPlayer.PlayMusic(3);
                    break;
                }

            //fight against 4 imps
            case 3:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Imp;
                    battleSys.enemyPrefabs[1] = data.Imp;
                    battleSys.enemyPrefabs[2] = data.Imp;
                    battleSys.enemyPrefabs[3] = data.Imp;

                    musicPlayer.PlayMusic(3);
                    break;
                }

            //fight against 1 ogre
            case 4:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.Nully;
                    battleSys.enemyPrefabs[2] = data.Ogre;
                    battleSys.enemyPrefabs[3] = data.Nully;

                    musicPlayer.PlayMusic(3);
                    break;
                }
            //fight against 1 ogre and 2 imps
            case 5:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.Imp;
                    battleSys.enemyPrefabs[2] = data.Ogre;
                    battleSys.enemyPrefabs[3] = data.Imp;

                    musicPlayer.PlayMusic(3);
                    break;
                }

            //fight against 2 ogres
            case 6:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.Ogre;
                    battleSys.enemyPrefabs[2] = data.Ogre;
                    battleSys.enemyPrefabs[3] = data.Nully;

                    musicPlayer.PlayMusic(3);
                    break;
                }

            //fight against 1 basylisk
            case 7:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.Nully;
                    battleSys.enemyPrefabs[2] = data.Basylisk;
                    battleSys.enemyPrefabs[3] = data.Nully;

                    musicPlayer.PlayMusic(3);
                    break;
                }

            //fight against 1 ogre, 1 basylisk, and 1 imp
            case 8:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.Ogre;
                    battleSys.enemyPrefabs[2] = data.Basylisk;
                    battleSys.enemyPrefabs[3] = data.Imp;

                    musicPlayer.PlayMusic(3);
                    break;
                }

            //fight against 1 lich
            case 9:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.Nully;
                    battleSys.enemyPrefabs[2] = data.Lich;
                    battleSys.enemyPrefabs[3] = data.Nully;

                    musicPlayer.PlayMusic(3);
                    break;
                }
            //fight against 2 ogres and 1 lich
            case 10:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.Ogre;
                    battleSys.enemyPrefabs[2] = data.Lich;
                    battleSys.enemyPrefabs[3] = data.Ogre;

                    musicPlayer.PlayMusic(3);
                    break;
                }
            //fight against dave
            case 11:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.Dave;
                    battleSys.enemyPrefabs[2] = data.Nully;
                    battleSys.enemyPrefabs[3] = data.Nully;


                    musicPlayer.PlayMusic(3);


                    isCustom = true;

                    break;
                }
            //fight against test1
            case 12:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.test1;
                    battleSys.enemyPrefabs[2] = data.Nully;
                    battleSys.enemyPrefabs[3] = data.Nully;

                    musicPlayer.PlayMusic(3);
                    break;
                }

            //fight against spades
            case 13:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.Nully;
                    battleSys.enemyPrefabs[2] = data.Spades;
                    battleSys.enemyPrefabs[3] = data.Nully;

                    musicPlayer.PlayMusic(3);
                    break;
                }

            //fight against hearts
            case 14:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.Hearts;
                    battleSys.enemyPrefabs[2] = data.Nully;
                    battleSys.enemyPrefabs[3] = data.Nully;

                    musicPlayer.PlayMusic(3);
                    break;
                }

            //fight against clubs
            case 15:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.Clubs;
                    battleSys.enemyPrefabs[2] = data.Nully;
                    battleSys.enemyPrefabs[3] = data.Nully;

                    musicPlayer.PlayMusic(3);
                    break;
                }

            //fight against diamonds
            case 16:
                {
                    SceneManager.LoadScene("Arena");
                    yield return new WaitForSeconds(1f);
                    battleSys = FindObjectOfType<BattleSystem>();

                    battleSys.playerPrefabs = data.saves[SaveId].PlayerParty;

                    battleSys.enemyPrefabs[0] = data.Nully;
                    battleSys.enemyPrefabs[1] = data.Diamonds;
                    battleSys.enemyPrefabs[2] = data.Nully;
                    battleSys.enemyPrefabs[3] = data.Nully;

                    musicPlayer.PlayMusic(3);
                    break;
                }
        }
        battleSys.IsCustom = isCustom;
    }

    public IEnumerator StartNewGame()
    {
        SaveId = 0;
        LoadMap(1);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SaveData(0));
        data.saves[0].PlayerParty[0] = data.John;

        for (int i = 1; i < 4; i++)
        {
            data.saves[0].PlayerParty[i] = data.Nully;
        }
        data.saves[0].currentLevel = CurLevel.SNOW;

    }

    //public void SetClass(int ClassId, int CharId)
    //{
    //    data.saves[SaveId].PlayerParty[CharId].GetComponent<Character>().Class = (CharClass)ClassId;
    //}

    //public void SetAspect(int AspectId, int CharId)
    //{
    //    data.saves[SaveId].PlayerParty[CharId].GetComponent<Character>().Aspect = (CharAspect)AspectId;
    //}

    //public void SetSpecibus(int SpecibusId, int CharId)
    //{
    //    PlayerData.GetComponent<SaveFile>().PlayerParty[CharId].Specibus = (CharSpecibus)SpecibusId;

    //}



    /////////////////////////К О С Т Ы Л И///////////////////////

    public void ForceActorComponents()
    {
        overSys.GetComponent<OverworldSystem>().PlayerAnimator = GameObject.Find("John(Clone)").GetComponent<Animator>();
        overSys.GetComponent<OverworldSystem>().PlayerRigidbody = GameObject.Find("John(Clone)").GetComponent<Rigidbody2D>();
        overSys.GetComponent<OverworldSystem>().PlayerCollider = GameObject.Find("John(Clone)").GetComponent<BoxCollider2D>();
        camCon.followTarget = GameObject.Find("John(Clone)");
    }

    public IEnumerator ForceOversys()
    {
        overSys.SetActive(true);
        yield return new WaitForSeconds(1f);
        overSys.SetActive(false);
    }
}