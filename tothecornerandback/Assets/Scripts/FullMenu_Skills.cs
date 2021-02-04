using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullMenu_Skills : MonoBehaviour
{
    public Text char1Name;
    public Text char1Title;
    public Button[] char1Skills;
    [Space(10)]
    public Text char2Name;
    public Text char2Title;
    public Button[] char2Skills;
    [Space(10)]
    public Text char3Name;
    public Text char3Title;
    public Button[] char3Skills;
    [Space(10)]
    public Text char4Name;
    public Text char4Title;
    public Button[] char4Skills;
    [Space(10)]
    public Text SkillName;
    public Text SkillCost;
    public Text SkillGrade;
    public Text SkillDescription;
    [Space(10)]
    public SaveFile tmpSave;

    private void OnEnable()
    {
        tmpSave = FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId];

        for(int i = 0; i < 5; i++)
        {
            char1Skills[i].onClick.AddListener(() => ShowSkillInfo(0, i));
            //char2Skills[i].onClick.AddListener(delegate { ShowSkillInfo(1, i); });
            //char3Skills[i].onClick.AddListener(delegate { ShowSkillInfo(2, i); });
            //char4Skills[i].onClick.AddListener(delegate { ShowSkillInfo(3, i); });

            char1Skills[i].image.sprite = tmpSave.PlayerParty[0].GetComponent<Character>().skills[i].icon;
            //char2Skills[i].image.sprite = tmpSave.PlayerParty[1].GetComponent<Character>().skills[i].icon;
            //char3Skills[i].image.sprite = tmpSave.PlayerParty[2].GetComponent<Character>().skills[i].icon;
            //char4Skills[i].image.sprite = tmpSave.PlayerParty[3].GetComponent<Character>().skills[i].icon;



        }
            
    }




    public void ShowSkillInfo(int charId, int skillId)
    {
        SkillName.text = tmpSave.PlayerParty[charId].GetComponent<Character>().skills[skillId].name;
        SkillCost.text = "Cost == " + tmpSave.PlayerParty[charId].GetComponent<Character>().skills[skillId].cost.ToString();
        SkillGrade.text = "Grade == " + tmpSave.PlayerParty[charId].GetComponent<Character>().skills[skillId].grade.ToString();
        SkillDescription.text = tmpSave.PlayerParty[charId].GetComponent<Character>().skills[skillId].description;
    }
}
