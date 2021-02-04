using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullMenu_Status : MonoBehaviour
{
    public Text char1Name;
    public Image char1Portrait;
    public Text char1Title;
    public Slider char1health;
    public Slider char1energy;
    public Button char1Weapon;
    public Button char1Armor;
    [Space(10)]
    public Text char2Name;
    public Image char2Portrait;
    public Text char2Title;
    public Slider char2health;
    public Slider char2energy;
    public Button char2Weapon;
    public Button char2Armor;
    [Space(10)]
    public Text char3Name;
    public Image char3Portrait;
    public Text char3Title;
    public Slider char3health;
    public Slider char3energy;
    public Button char3Weapon;
    public Button char3Armor;
    [Space(10)]
    public Text char4Name;
    public Image char4Portrait;
    public Text char4Title;
    public Slider char4health;
    public Slider char4energy;
    public Button char4Weapon;
    public Button char4Armor;
    [Space(10)]
    public Button[] ItemSlots;
    public int SelectedItemId;
    public Button UseButton;
    public Button InfoButton;
    public Button TrashButton;

    private void OnEnable()
    {
        try
        {

        
        SaveFile tmp = FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId];

        char1Name.text = tmp.PlayerParty[0].GetComponent<Character>().name;
        char1Portrait.sprite = tmp.PlayerParty[0].GetComponent<Character>().portrait;
        char1Title.text = tmp.PlayerParty[0].GetComponent<Character>().Class.ToString() + " of " + tmp.PlayerParty[0].GetComponent<Character>().Aspect.ToString();
        char1health.maxValue = tmp.PlayerParty[0].GetComponent<Character>().health;
        char1health.value = tmp.PlayerParty[0].GetComponent<Character>().currentHealth;
        char1energy.maxValue = tmp.PlayerParty[0].GetComponent<Character>().energy;
        char1energy.value = tmp.PlayerParty[0].GetComponent<Character>().currentEnergy;
        char1Weapon.GetComponentInChildren<Text>().text = tmp.PlayerParty[0].GetComponent<Character>().Weapon.name;
        char1Armor.GetComponentInChildren<Text>().text = tmp.PlayerParty[0].GetComponent<Character>().Armor.name;

        char2Name.text = tmp.PlayerParty[1].GetComponent<Character>().name;
        char2Portrait.sprite = tmp.PlayerParty[1].GetComponent<Character>().portrait;
        char2Title.text = tmp.PlayerParty[1].GetComponent<Character>().Class.ToString() + " of " + tmp.PlayerParty[0].GetComponent<Character>().Aspect.ToString();
        char2health.maxValue = tmp.PlayerParty[1].GetComponent<Character>().health;
        char2health.value = tmp.PlayerParty[1].GetComponent<Character>().currentHealth;
        char2energy.maxValue = tmp.PlayerParty[1].GetComponent<Character>().energy;
        char2energy.value = tmp.PlayerParty[1].GetComponent<Character>().currentEnergy;
        char2Weapon.GetComponentInChildren<Text>().text = tmp.PlayerParty[1].GetComponent<Character>().Weapon.name;
        char2Armor.GetComponentInChildren<Text>().text = tmp.PlayerParty[1].GetComponent<Character>().Armor.name;

        char3Name.text = tmp.PlayerParty[2].GetComponent<Character>().name;
        char3Portrait.sprite = tmp.PlayerParty[2].GetComponent<Character>().portrait;
        char3Title.text = tmp.PlayerParty[2].GetComponent<Character>().Class.ToString() + " of " + tmp.PlayerParty[0].GetComponent<Character>().Aspect.ToString();
        char3health.maxValue = tmp.PlayerParty[2].GetComponent<Character>().health;
        char3health.value = tmp.PlayerParty[2].GetComponent<Character>().currentHealth;
        char3energy.maxValue = tmp.PlayerParty[2].GetComponent<Character>().energy;
        char3energy.value = tmp.PlayerParty[2].GetComponent<Character>().currentEnergy;
        char3Weapon.GetComponentInChildren<Text>().text = tmp.PlayerParty[2].GetComponent<Character>().Weapon.name;
        char3Armor.GetComponentInChildren<Text>().text = tmp.PlayerParty[2].GetComponent<Character>().Armor.name;

        char4Name.text = tmp.PlayerParty[3].GetComponent<Character>().name;
        char4Portrait.sprite = tmp.PlayerParty[3].GetComponent<Character>().portrait;
        char4Title.text = tmp.PlayerParty[3].GetComponent<Character>().Class.ToString() + " of " + tmp.PlayerParty[0].GetComponent<Character>().Aspect.ToString();
        char4health.maxValue = tmp.PlayerParty[3].GetComponent<Character>().health;
        char4health.value = tmp.PlayerParty[3].GetComponent<Character>().currentHealth;
        char4energy.maxValue = tmp.PlayerParty[3].GetComponent<Character>().energy;
        char4energy.value = tmp.PlayerParty[3].GetComponent<Character>().currentEnergy;
        char4Weapon.GetComponentInChildren<Text>().text = tmp.PlayerParty[3].GetComponent<Character>().Weapon.name;
        char4Armor.GetComponentInChildren<Text>().text = tmp.PlayerParty[3].GetComponent<Character>().Armor.name;

        OverworldSystem oversystmp = FindObjectOfType<OverworldSystem>();

        for (int i = 0; i < 10; i++)
        {
            ItemSlots[i].GetComponentInChildren<Text>().text = oversystmp.inventory[i].name;
        }



        SelectedItemId = 0;
#warning имплементируй прогрузку инвентаря
        }
        catch(Exception ex)
        {

        }

    }

#warning СЛИШКОМ МНОГО ФАЙНДОВ, ОПТИМИЗИРУЙ
#warning ПРИ ИСПОЛЬЗОВАНИИ ОДНОРАЗОВЫХ ПРЕДМЕТОВ ПРЕФАБ ОЧИЩАЕТСЯ ИСПРАВЛЯЙ
    public void UseItem()
    {
        OverworldSystem overSys = FindObjectOfType<OverworldSystem>();
        if (overSys.inventory[SelectedItemId].type == ItemType.WEAPON)
        {
            EquipWeapon(0);
        }
        else
            if (overSys.inventory[SelectedItemId].type == ItemType.ARMOR)
        {
            EquipArmor(0);
        }
        else
        {
            overSys.inventory[SelectedItemId].Use(FindObjectOfType<DataContainer>().saves[0].PlayerParty[0].GetComponent<Character>());
            if (overSys.inventory[SelectedItemId].disposable)
            {
                TrashItem();
            }
        }
    }

    public void InfoItem()
    {
        FindObjectOfType<OverworldSystem>().inventory[SelectedItemId].PrintInfo();
    }

    public void TrashItem()
    {
        FindObjectOfType<OverworldSystem>().inventory[SelectedItemId] = FindObjectOfType<DataContainer>().EMPTY;
    }

    public void SelectItem(int id)
    {
        SelectedItemId = id;
    }

    public bool CheckForInventorySpace()
    {
        Item[] inventory = FindObjectOfType<OverworldSystem>().inventory;
        for (int i = 0; i < 10; i++)
        {
            if (inventory[i].type == ItemType.EMPTY)
                return true;
        }
        return false;
    }

    public int FindEmptyInventorySlot()
    {
        Item[] inventory = FindObjectOfType<OverworldSystem>().inventory;
        if (CheckForInventorySpace())
        {
            for (int i = 0; i < 10; i++)
            {
                if (inventory[i].type == ItemType.EMPTY)
                    return i;
            }
        }
        return -1;
    }

#warning СДЕЛАЙ ОБМУНДИРОВАНИЕ СУКАААААААААААААААААААААААААААА

#warning ЭТО ВООБЩЕ РАБОТАЕТ????????????????????
    public void PutWeaponInInventory(int CharId)
    {
        SaveFile savetmp = FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId];
        Item weapon = savetmp.PlayerParty[CharId].GetComponent<Character>().Weapon;
        savetmp.PlayerParty[CharId].GetComponent<Character>().Weapon = FindObjectOfType<DataContainer>().EMPTY;
        FindObjectOfType<OverworldSystem>().inventory[FindEmptyInventorySlot()] = weapon;
    }

    public void PutArmorInInventory(int CharId)
    {
        SaveFile savetmp = FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId];
        Item armor = savetmp.PlayerParty[CharId].GetComponent<Character>().Armor;
        savetmp.PlayerParty[CharId].GetComponent<Character>().Armor = FindObjectOfType<DataContainer>().EMPTY;
        FindObjectOfType<OverworldSystem>().inventory[FindEmptyInventorySlot()] = armor;
    }

    public void EquipWeapon(int CharId)
    {
        SaveFile savetmp = FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId];
        Item weapon = savetmp.PlayerParty[CharId].GetComponent<Character>().Weapon;
        savetmp.PlayerParty[CharId].GetComponent<Character>().Weapon = FindObjectOfType<OverworldSystem>().inventory[SelectedItemId];
        FindObjectOfType<OverworldSystem>().inventory[SelectedItemId] = weapon;
    }

    public void EquipArmor(int CharId)
    {
        SaveFile savetmp = FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId];
        Item armor = savetmp.PlayerParty[CharId].GetComponent<Character>().Armor;
        savetmp.PlayerParty[CharId].GetComponent<Character>().Armor = FindObjectOfType<OverworldSystem>().inventory[SelectedItemId];
        FindObjectOfType<OverworldSystem>().inventory[FindEmptyInventorySlot()] = armor;
    }
}