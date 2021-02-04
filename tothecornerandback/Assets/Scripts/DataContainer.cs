using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DataContainer : MonoBehaviour
{
    public string ActorsName;
    [Space(20)]
    public AudioClip musicTutorial1;
    public AudioClip musicTutorial2;
    public AudioClip musicTutorial3;
    [Space(10)]
    public AudioClip musicSnowForest1;
    [Space(10)]
    public AudioClip musicLab1;
    [Space(10)]
    public AudioClip musicHills1;
    [Space(10)]
    public AudioClip musicForest1;
    [Space(10)]
    public AudioClip musicCastle1;
    [Space(10)]
    public AudioClip musicEpilogue1;
    [Space(10)]
    public AudioClip musicBattle1;
    [Space(10)]
    public Character[] defaultTeam;
    [Space(10)]
    public SaveFile[] saves;
    [Space(10)]
    public SaveFile tmpSave;
    [Space(10)]
    public StatSystem statSystem;
    [Space(10)]
    public GameObject OverworldSystemPrefab;
    public GameObject OverworldUIPrefab;
    public GameObject ActorPrefab;
    [Header("Creature Prefabs")]
    public GameObject Nully;
    public GameObject Imp;
    public GameObject Ogre;
    public GameObject Basylisk;
    public GameObject Lich;
    public GameObject Clubs;
    public GameObject Diamonds;
    public GameObject Hearts;
    public GameObject Spades;
    public GameObject John;
    public GameObject Dave;
    public GameObject Aradia;
    public GameObject test1;
    [Header("Skills")]
    public Skill bladekind1;
    public Skill polearmkind1;
    public Skill bowkind1;
    public Skill staffkind1;
    [Space(10)]
    public Skill knight2;
    public Skill seer2;
    [Space(10)]
    public Skill doom3;
    public Skill life3;
    public Skill space3;
    public Skill void3;
    [Space(10)]
    public Skill knightDoom4;
    public Skill knightLife4;
    public Skill knightSpace4;
    public Skill knightVoid4;
    public Skill seerDoom4;
    public Skill seerLife4;
    public Skill seerSpace4;
    public Skill seerVoid4;
    [Space(10)]
    public Skill skip;
    public Skill basicAttack;
    [Header("SFX")]
    [Space(10)]
    public AudioClip click;
    [Space(10)]
    [Header("Items")]
    public Item EMPTY;
    public Item DefaultSword;
    public Item DefaultPolearm;
    public Item DefaultStaff;
    public Item DefaultBow;
    public Item BetterSword;
    public Item BetterPolearm;
    public Item BetterStaff;
    public Item BetterBow;
    public Item Gambeson;
    public Item LesserHealingPotion;
    [Space(10)]
    [Header("Generic Strings")]
    public string[] InventoryIsFullMessage;
    [Header("PrefabsForCustomMode")]
    public GameObject Hum1;
    public GameObject Hum2;
    public GameObject Hum3;
    public GameObject Hum4;
    public GameObject Com1;
    public GameObject Com2;
    public GameObject Com3;
    public GameObject Com4;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
