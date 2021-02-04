using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullMenu_Technical : MonoBehaviour
{

    public Slider soundSlider;
    public Slider musicSlider;

    public Text SaveName;
    public Text SaveLocation;
    public Text SaveDate;
    public int currentSave = 0;
    private void OnEnable()
    {
        SetSavePreview(0);
        
    }

    public void SetSavePreview(int id)
    {
        SaveFile tmpSave = FindObjectOfType<DataContainer>().saves[id];
        SaveName.text = tmpSave.name;
        SaveLocation.text = tmpSave.currentLevel.ToString();
        SaveDate.text = tmpSave.saveDate.ToString();
        currentSave = id;
    }

    public void ClearSave()
    {
        FindObjectOfType<DataContainer>().saves[currentSave].Clear();
        SetSavePreview(currentSave);
    }

    public void SaveGame()
    {
        FindObjectOfType<DevConsole>().ExecuteCommand("save " + FindObjectOfType<GlobalSystem>().SaveId);
        SetSavePreview(FindObjectOfType<GlobalSystem>().SaveId);
    }

    public void LoadGame()
    {
        FindObjectOfType<DevConsole>().ExecuteCommand("loadsave " + currentSave + 1);
        GameObject.Find("FullMenu").SetActive(false);
    }

    public void SetSoundVolume()
    {
        FindObjectOfType<GlobalSystem>().soundPlayer.audiosource.volume = soundSlider.value;
    }

    public void SetMusicVolume()
    {
        FindObjectOfType<GlobalSystem>().musicPlayer.audiosource.volume = musicSlider.value;
    }


}
