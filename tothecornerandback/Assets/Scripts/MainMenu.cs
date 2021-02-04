using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class MainMenu : MonoBehaviour
{
    [Space(15)]
    public GameObject Configurations;
    [Space(15)]
    public Slider SoundSlider;
    public Slider MusicSlider;
    public GameObject LanguageComBox;
    public GameObject DevConsCheck;
    [Space(15)]
    public int SaveSelection = 0;

    


    void Start()
    {
        SoundSlider.onValueChanged.AddListener(delegate { FindObjectOfType<GlobalSystem>().soundPlayer.SetVolume(GetSoundVolumeFromSlider()); });
        MusicSlider.onValueChanged.AddListener(delegate { FindObjectOfType<GlobalSystem>().musicPlayer.SetVolume(GetMusicVolumeFromSlider()); });


        DevConsCheck.GetComponent<Toggle>().isOn = Configurations.GetComponent<Configurations>().DevCons;




        List<Button> buttons = Resources.FindObjectsOfTypeAll<Button>().ToList();

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].onClick.AddListener(delegate { FindObjectOfType<SoundPlayer>().PlaySound(1); });
        }

    }

    private float GetMusicVolumeFromSlider()
    {
        return MusicSlider.value / 100;
    }

    private float GetSoundVolumeFromSlider()
    {
        return SoundSlider.value / 100;
    }



    void Update()
    {
        //Configurations.GetComponent<Configurations>().SoundVolume = SoundSlider.GetComponent<Slider>().value;
        //Configurations.GetComponent<Configurations>().MusicVolume = MusicSlider.GetComponent<Slider>().value;
        Configurations.GetComponent<Configurations>().DevCons = DevConsCheck.GetComponent<Toggle>().isOn;
    }

    public void GetSaveShortInfo(int id)
    {
        GameObject.Find("T_Name").GetComponent<Text>().text = FindObjectOfType<DataContainer>().saves[id].name;
        GameObject.Find("T_Location").GetComponent<Text>().text = FindObjectOfType<DataContainer>().saves[id].currentLevel.ToString();
        GameObject.Find("T_Date").GetComponent<Text>().text = FindObjectOfType<DataContainer>().saves[id].saveDate.ToString();
        SaveSelection = id;
    }

    public void ClearSave()
    {
        FindObjectOfType<DataContainer>().saves[SaveSelection].Clear();
    }

    public void ParseSaveFile(string xmlData)
    {

    }


    public void NewGame()
    {
        //FindObjectOfType<GlobalSystem>().LoadMap(1);
        //FindObjectOfType<GlobalSystem>().StartNewGame();
        FindObjectOfType<DevConsole>().ExecuteCommand("newgame");
    }

    public void Tutorial()
    {
        FindObjectOfType<GlobalSystem>().LoadMap(0);
    }

    public void LoadSelectedSave()
    {
        //вот тут то же самое
        //по какой-то причине это ТАК не работает
        //StartCoroutine(FindObjectOfType<GlobalSystem>().LoadSaveFile(SaveSelection));

        //но так - работает
        FindObjectOfType<DevConsole>().ExecuteCommand("loadsave " + (SaveSelection + 1));
    }
}