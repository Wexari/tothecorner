using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BriefMenu : MonoBehaviour
{
    public Text char1Name;
    public Image char1Portrait;
    public Slider char1health;
    public Slider char1energy;
    [Space (10)]
    public Text char2Name;
    public Image char2Portrait;
    public Slider char2health;
    public Slider char2energy;
    [Space(10)]
    public Text char3Name;
    public Image char3Portrait;
    public Slider char3health;
    public Slider char3energy;
    [Space(10)]
    public Text char4Name;
    public Image char4Portrait;
    public Slider char4health;
    public Slider char4energy;
    private void OnEnable()
    {
        SaveFile tmp = FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId];

        char1Name.text = tmp.PlayerParty[0].GetComponent<Character>().name;
        char1health.maxValue = tmp.PlayerParty[0].GetComponent<Character>().health;
        char1health.value = tmp.PlayerParty[0].GetComponent<Character>().currentHealth;
        char1energy.maxValue = tmp.PlayerParty[0].GetComponent<Character>().energy;
        char1energy.value = tmp.PlayerParty[0].GetComponent<Character>().currentEnergy;
        char1Portrait.sprite = tmp.PlayerParty[0].GetComponent<Character>().portrait;


        char2Name.text = tmp.PlayerParty[1].GetComponent<Character>().name;
        char2health.maxValue = tmp.PlayerParty[1].GetComponent<Character>().health;
        char2health.value = tmp.PlayerParty[1].GetComponent<Character>().currentHealth;
        char2energy.maxValue = tmp.PlayerParty[1].GetComponent<Character>().energy;
        char2energy.value = tmp.PlayerParty[1].GetComponent<Character>().currentEnergy;
        char2Portrait.sprite = tmp.PlayerParty[1].GetComponent<Character>().portrait;

        char3Name.text = tmp.PlayerParty[2].GetComponent<Character>().name;
        char3health.maxValue = tmp.PlayerParty[2].GetComponent<Character>().health;
        char3health.value = tmp.PlayerParty[2].GetComponent<Character>().currentHealth;
        char3energy.maxValue = tmp.PlayerParty[2].GetComponent<Character>().energy;
        char3energy.value = tmp.PlayerParty[2].GetComponent<Character>().currentEnergy;
        char3Portrait.sprite = tmp.PlayerParty[2].GetComponent<Character>().portrait;

        char4Name.text = tmp.PlayerParty[3].GetComponent<Character>().name;
        char4health.maxValue = tmp.PlayerParty[3].GetComponent<Character>().health;
        char4health.value = tmp.PlayerParty[3].GetComponent<Character>().currentHealth;
        char4energy.maxValue = tmp.PlayerParty[3].GetComponent<Character>().energy;
        char4energy.value = tmp.PlayerParty[3].GetComponent<Character>().currentEnergy;
        char4Portrait.sprite = tmp.PlayerParty[3].GetComponent<Character>().portrait;
    }
}
