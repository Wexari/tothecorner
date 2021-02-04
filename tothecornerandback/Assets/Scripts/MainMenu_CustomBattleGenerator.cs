using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_CustomBattleGenerator : MonoBehaviour
{
    public DataContainer data;
    public GlobalSystem globalSys;

    public InputField Hum1Name;
    public Dropdown Hum1Class;
    public Dropdown Hum1Aspect;
    public Dropdown Hum1Weapon;
    public InputField Hum1Level;

    public InputField Hum2Name;
    public Dropdown Hum2Class;
    public Dropdown Hum2Aspect;
    public Dropdown Hum2Weapon;
    public InputField Hum2Level;

    public InputField Hum3Name;
    public Dropdown Hum3Class;
    public Dropdown Hum3Aspect;
    public Dropdown Hum3Weapon;
    public InputField Hum3Level;

    public InputField Hum4Name;
    public Dropdown Hum4Class;
    public Dropdown Hum4Aspect;
    public Dropdown Hum4Weapon;
    public InputField Hum4Level;


    public InputField Comp1Name;
    public Dropdown Comp1Class;
    public Dropdown Comp1Aspect;
    public Dropdown Comp1Weapon;
    public InputField Comp1Level;

    public InputField Comp2Name;
    public Dropdown Comp2Class;
    public Dropdown Comp2Aspect;
    public Dropdown Comp2Weapon;
    public InputField Comp2Level;

    public InputField Comp3Name;
    public Dropdown Comp3Class;
    public Dropdown Comp3Aspect;
    public Dropdown Comp3Weapon;
    public InputField Comp3Level;

    public InputField Comp4Name;
    public Dropdown Comp4Class;
    public Dropdown Comp4Aspect;
    public Dropdown Comp4Weapon;
    public InputField Comp4Level;

    // Start is called before the first frame update
    void OnEnable()
    {
        data = FindObjectOfType<DataContainer>();
        globalSys = FindObjectOfType<GlobalSystem>();
        ShowCustomChars();
    }

    public void PlayCustomFight()
    {
        //и СНОВА вызов битвы напрямую не работает
        //.............
        //StartCoroutine(globalSys.TriggerFight(-1));
        FindObjectOfType<DevConsole>().ExecuteCommand("loadfight -1");
    }

    public void ShowCustomChars()
    {
        Hum1Name.text = data.Hum1.GetComponent<Character>().name;
        Hum1Class.value = (int)data.Hum1.GetComponent<Character>().Class - 1;
        Hum1Aspect.value = (int)data.Hum1.GetComponent<Character>().Aspect - 1;
        Hum1Weapon.value = (int)data.Hum1.GetComponent<Character>().WeaponType - 1;
        Hum1Level.text = "" + data.Hum1.GetComponent<Character>().level;

        Hum2Name.text = data.Hum2.GetComponent<Character>().name;
        Hum2Class.value = (int)data.Hum2.GetComponent<Character>().Class - 1;
        Hum2Aspect.value = (int)data.Hum2.GetComponent<Character>().Aspect - 1;
        Hum2Weapon.value = (int)data.Hum2.GetComponent<Character>().WeaponType - 1;
        Hum2Level.text = "" + data.Hum2.GetComponent<Character>().level;

        Hum3Name.text = data.Hum3.GetComponent<Character>().name;
        Hum3Class.value = (int)data.Hum3.GetComponent<Character>().Class - 1;
        Hum3Aspect.value = (int)data.Hum3.GetComponent<Character>().Aspect - 1;
        Hum3Weapon.value = (int)data.Hum3.GetComponent<Character>().WeaponType - 1;
        Hum3Level.text = "" + data.Hum3.GetComponent<Character>().level;

        Hum4Name.text = data.Hum4.GetComponent<Character>().name;
        Hum4Class.value = (int)data.Hum4.GetComponent<Character>().Class - 1;
        Hum4Aspect.value = (int)data.Hum4.GetComponent<Character>().Aspect - 1;
        Hum4Weapon.value = (int)data.Hum4.GetComponent<Character>().WeaponType - 1;
        Hum4Level.text = "" + data.Hum4.GetComponent<Character>().level;



        Comp1Name.text = data.Com1.GetComponent<Character>().name;
        Comp1Class.value = (int)data.Com1.GetComponent<Character>().Class - 1;
        Comp1Aspect.value = (int)data.Com1.GetComponent<Character>().Aspect - 1;
        Comp1Weapon.value = (int)data.Com1.GetComponent<Character>().WeaponType - 1;
        Comp1Level.text = "" + data.Com1.GetComponent<Character>().level;

        Comp2Name.text = data.Com2.GetComponent<Character>().name;
        Comp2Class.value = (int)data.Com2.GetComponent<Character>().Class - 1;
        Comp2Aspect.value = (int)data.Com2.GetComponent<Character>().Aspect - 1;
        Comp2Weapon.value = (int)data.Com2.GetComponent<Character>().WeaponType - 1;
        Comp2Level.text = "" + data.Com2.GetComponent<Character>().level;

        Comp3Name.text = data.Com3.GetComponent<Character>().name;
        Comp3Class.value = (int)data.Com3.GetComponent<Character>().Class - 1;
        Comp3Aspect.value = (int)data.Com3.GetComponent<Character>().Aspect - 1;
        Comp3Weapon.value = (int)data.Com3.GetComponent<Character>().WeaponType - 1;
        Comp3Level.text = "" + data.Com3.GetComponent<Character>().level;

        Comp4Name.text = data.Com4.GetComponent<Character>().name;
        Comp4Class.value = (int)data.Com4.GetComponent<Character>().Class - 1;
        Comp4Aspect.value = (int)data.Com4.GetComponent<Character>().Aspect - 1;
        Comp4Weapon.value = (int)data.Com4.GetComponent<Character>().WeaponType - 1;
        Comp4Level.text = "" + data.Com4.GetComponent<Character>().level;
    }

    public void SaveCustomChars()
    {
        data.Hum1.GetComponent<Character>().name = Hum1Name.text;
        data.Hum1.GetComponent<Character>().Class = (CharClass)Hum1Class.value + 1;
        data.Hum1.GetComponent<Character>().Aspect = (CharAspect)Hum1Aspect.value + 1;
        data.Hum1.GetComponent<Character>().WeaponType = (CharWeapon)Hum1Weapon.value + 1;
        data.Hum1.GetComponent<Character>().level = Convert.ToInt32(Hum1Level.text);
        data.Hum1.GetComponent<Character>().SetStatsByLvl();
        data.Hum1.GetComponent<Character>().GiveSkills();
        EditorUtility.SetDirty(data.Hum1.GetComponent<Character>());

        data.Hum2.GetComponent<Character>().name = Hum2Name.text;
        data.Hum2.GetComponent<Character>().Class = (CharClass)Hum2Class.value + 1;
        data.Hum2.GetComponent<Character>().Aspect = (CharAspect)Hum2Aspect.value + 1;
        data.Hum2.GetComponent<Character>().WeaponType = (CharWeapon)Hum2Weapon.value + 1;
        data.Hum2.GetComponent<Character>().level = Convert.ToInt32(Hum2Level.text);
        data.Hum2.GetComponent<Character>().SetStatsByLvl();
        data.Hum2.GetComponent<Character>().GiveSkills();
        EditorUtility.SetDirty(data.Hum2.GetComponent<Character>());

        data.Hum3.GetComponent<Character>().name = Hum3Name.text;
        data.Hum3.GetComponent<Character>().Class = (CharClass)Hum3Class.value + 1;
        data.Hum3.GetComponent<Character>().Aspect = (CharAspect)Hum3Aspect.value + 1;
        data.Hum3.GetComponent<Character>().WeaponType = (CharWeapon)Hum3Weapon.value + 1;
        data.Hum3.GetComponent<Character>().level = Convert.ToInt32(Hum3Level.text);
        data.Hum3.GetComponent<Character>().SetStatsByLvl();
        data.Hum3.GetComponent<Character>().GiveSkills();
        EditorUtility.SetDirty(data.Hum3.GetComponent<Character>());

        data.Hum4.GetComponent<Character>().name = Hum4Name.text;
        data.Hum4.GetComponent<Character>().Class = (CharClass)Hum4Class.value + 1;
        data.Hum4.GetComponent<Character>().Aspect = (CharAspect)Hum4Aspect.value + 1;
        data.Hum4.GetComponent<Character>().WeaponType = (CharWeapon)Hum4Weapon.value + 1;
        data.Hum4.GetComponent<Character>().level = Convert.ToInt32(Hum4Level.text);
        data.Hum4.GetComponent<Character>().SetStatsByLvl();
        data.Hum4.GetComponent<Character>().GiveSkills();
        EditorUtility.SetDirty(data.Hum4.GetComponent<Character>());


        data.Com1.GetComponent<Character>().name = Comp1Name.text;
        data.Com1.GetComponent<Character>().Class = (CharClass)Comp1Class.value + 1;
        data.Com1.GetComponent<Character>().Aspect = (CharAspect)Comp1Aspect.value + 1;
        data.Com1.GetComponent<Character>().WeaponType = (CharWeapon)Comp1Weapon.value + 1;
        data.Com1.GetComponent<Character>().level = Convert.ToInt32(Comp1Level.text);
        data.Com1.GetComponent<Character>().SetStatsByLvl();
        data.Com1.GetComponent<Character>().GiveSkills();
        EditorUtility.SetDirty(data.Com1.GetComponent<Character>());

        data.Com2.GetComponent<Character>().name = Comp2Name.text;
        data.Com2.GetComponent<Character>().Class = (CharClass)Comp2Class.value + 1;
        data.Com2.GetComponent<Character>().Aspect = (CharAspect)Comp2Aspect.value + 1;
        data.Com2.GetComponent<Character>().WeaponType = (CharWeapon)Comp2Weapon.value + 1;
        data.Com2.GetComponent<Character>().level = Convert.ToInt32(Comp2Level.text);
        data.Com2.GetComponent<Character>().SetStatsByLvl();
        data.Com2.GetComponent<Character>().GiveSkills();
        EditorUtility.SetDirty(data.Com2.GetComponent<Character>());

        data.Com3.GetComponent<Character>().name = Comp3Name.text;
        data.Com3.GetComponent<Character>().Class = (CharClass)Comp3Class.value + 1;
        data.Com3.GetComponent<Character>().Aspect = (CharAspect)Comp3Aspect.value + 1;
        data.Com3.GetComponent<Character>().WeaponType = (CharWeapon)Comp3Weapon.value + 1;
        data.Com3.GetComponent<Character>().level = Convert.ToInt32(Comp3Level.text);
        data.Com3.GetComponent<Character>().SetStatsByLvl();
        data.Com3.GetComponent<Character>().GiveSkills();
        EditorUtility.SetDirty(data.Com3.GetComponent<Character>());

        data.Com4.GetComponent<Character>().name = Comp4Name.text;
        data.Com4.GetComponent<Character>().Class = (CharClass)Comp4Class.value + 1;
        data.Com4.GetComponent<Character>().Aspect = (CharAspect)Comp4Aspect.value + 1;
        data.Com4.GetComponent<Character>().WeaponType = (CharWeapon)Comp4Weapon.value + 1;
        data.Com4.GetComponent<Character>().level = Convert.ToInt32(Comp4Level.text);
        data.Com4.GetComponent<Character>().SetStatsByLvl();
        data.Com4.GetComponent<Character>().GiveSkills();
        EditorUtility.SetDirty(data.Com4.GetComponent<Character>());
    }
}
