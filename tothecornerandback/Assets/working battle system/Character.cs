using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharWeapon
{
    DEFAULT,
    BLADEKIND,
    POLEARMKIND,
    BOWKIND,
    STAFFKIND
}

public enum CharClass
{
    DEFAULT,
    KNIGHT,
    SEER
}

public enum CharAspect
{
    DEFAULT,
    DOOM,
    LIFE,
    SPACE,
    VOID
}

public class Character : MonoBehaviour
{
    public bool IsCustom;
    
    public new string name;
    public Sprite portrait;

    public int level;
    public CharWeapon WeaponType;
    public CharClass Class;
    public CharAspect Aspect;

    public Item Weapon;
    public Item Armor;

    public int attack;
    public int defence;
    public int wisdom;

    public int health;
    public int currentHealth;

    public int energy;
    public int currentEnergy;

    public float might;
    public int speed;

    public Skill[] skills;
 
    //public EffectContainer[] curEffects = new EffectContainer[4];

    public bool acted;

    /*public Character()
    {
        IsCustom = true;
        this.name = "PLACEHOLDER";

        this.level = 10;
        Class = CharClass.DEFAULT;
        Aspect = CharAspect.DEFAULT;
        this.attack = 15;
        this.defence = 10;
        this.wisdom = 10;
        this.health = 50;
        this.currentHealth = 50;
        this.energy = 25;
        this.currentEnergy = 25;
        this.might = 15;
        this.speed = 10;

        skills = new Skill[skillPrefabs.Length];
        for (int i = 0; i < skillPrefabs.Length; i++)
        {
            skills[i] = skillPrefabs[i].GetComponent<Skill>();
        }

        //this.skillPrefabs = skillPrefabs;
        //this.skills = skills;
        //this.curEffects = curEffects;
        //this.acted = acted;
    }*/

    /*public Character(bool isCustom, string name, Sprite portrait, int level, CharClass @class, CharAspect aspect, int attack, int defence, int wisdom, int health, int currentHealth, int energy, int currentEnergy, float might, int speed, GameObject[] skillPrefabs, Skill[] skills, EffectContainer[] curEffects, bool acted)
    {
        IsCustom = isCustom;
        this.name = name;
        this.portrait = portrait;
        this.level = level;
        Class = @class;
        Aspect = aspect;
        this.attack = attack;
        this.defence = defence;
        this.wisdom = wisdom;
        this.health = health;
        this.currentHealth = currentHealth;
        this.energy = energy;
        this.currentEnergy = currentEnergy;
        this.might = might;
        this.speed = speed;
        this.skillPrefabs = skillPrefabs;
        this.skills = skills;
        this.curEffects = curEffects;
        this.acted = acted;
    }*/

    private void Start()
    {
        if(!IsCustom)
        {
            StatSystem statsys = FindObjectOfType<DataContainer>().statSystem;

            if(level > statsys.levelCap)
            {
                level = statsys.levelCap;
            }

            if (level == 0)
                return;

            attack = statsys.attributes[level - 1].attack;
            defence = statsys.attributes[level - 1].defence;
            wisdom = statsys.attributes[level - 1].wisdom;

            health = statsys.attributes[level - 1].maxHealth;
            currentHealth = health;

            energy = statsys.attributes[level - 1].maxEnergy;
            currentEnergy = energy;

            might = statsys.attributes[level - 1].might;
            speed = statsys.attributes[level - 1].speed;

            switch (Class)
            {
                case CharClass.DEFAULT:
                    {

                        break;
                    }
                case CharClass.KNIGHT:
                    {
                        attack = (int)(attack * statsys.KnightModificators.attack);
                        defence = (int)(defence * statsys.KnightModificators.defence);
                        wisdom = (int)(wisdom * statsys.KnightModificators.wisdom);

                        health = (int)(health * statsys.KnightModificators.maxHealth);
                        currentHealth = health;

                        energy = (int)(energy * statsys.KnightModificators.maxEnergy);
                        currentEnergy = energy;

                        might = (int)(might * statsys.KnightModificators.might);
                        speed = (int)(speed * statsys.KnightModificators.speed);
                        break;
                    }
                case CharClass.SEER:
                    {
                        attack = (int)(attack * statsys.SeerModificators.attack);
                        defence = (int)(defence * statsys.SeerModificators.defence);
                        wisdom = (int)(wisdom * statsys.SeerModificators.wisdom);

                        health = (int)(health * statsys.SeerModificators.maxHealth);
                        currentHealth = health;

                        energy = (int)(energy * statsys.SeerModificators.maxEnergy);
                        currentEnergy = energy;

                        might = (int)(might * statsys.SeerModificators.might);
                        speed = (int)(speed * statsys.SeerModificators.speed);
                        break;
                    }
            }

            GiveSkills();

            acted = false;
        }
    }

    public void SetStatsByLvl()
    {
        StatSystem statsys = FindObjectOfType<DataContainer>().statSystem;

        if (level > statsys.levelCap)
        {
            level = statsys.levelCap;
        }

        if (level == 0)
            return;

        attack = statsys.attributes[level - 1].attack;
        defence = statsys.attributes[level - 1].defence;
        wisdom = statsys.attributes[level - 1].wisdom;

        health = statsys.attributes[level - 1].maxHealth;
        currentHealth = health;

        energy = statsys.attributes[level - 1].maxEnergy;
        currentEnergy = energy;

        might = statsys.attributes[level - 1].might;
        speed = statsys.attributes[level - 1].speed;

        switch (Class)
        {
            case CharClass.DEFAULT:
                {

                    break;
                }
            case CharClass.KNIGHT:
                {
                    attack = (int)(attack * statsys.KnightModificators.attack);
                    defence = (int)(defence * statsys.KnightModificators.defence);
                    wisdom = (int)(wisdom * statsys.KnightModificators.wisdom);

                    health = (int)(health * statsys.KnightModificators.maxHealth);
                    currentHealth = health;

                    energy = (int)(energy * statsys.KnightModificators.maxEnergy);
                    currentEnergy = energy;

                    might = (int)(might * statsys.KnightModificators.might);
                    speed = (int)(speed * statsys.KnightModificators.speed);
                    break;
                }
            case CharClass.SEER:
                {
                    attack = (int)(attack * statsys.SeerModificators.attack);
                    defence = (int)(defence * statsys.SeerModificators.defence);
                    wisdom = (int)(wisdom * statsys.SeerModificators.wisdom);

                    health = (int)(health * statsys.SeerModificators.maxHealth);
                    currentHealth = health;

                    energy = (int)(energy * statsys.SeerModificators.maxEnergy);
                    currentEnergy = energy;

                    might = (int)(might * statsys.SeerModificators.might);
                    speed = (int)(speed * statsys.SeerModificators.speed);
                    break;
                }
        }
        acted = false;
    }

    public void GiveSkills()
    {
        DataContainer data = FindObjectOfType<DataContainer>();
        switch(WeaponType)
        {
            case CharWeapon.DEFAULT:
                {
                    skills[0] = data.basicAttack;
                    break;
                }

            case CharWeapon.BLADEKIND:
                {
                    skills[0] = data.bladekind1;
                    break;
                }

            case CharWeapon.POLEARMKIND:
                {
                    skills[0] = data.polearmkind1;
                    break;
                }

            case CharWeapon.STAFFKIND:
                {
                    skills[0] = data.staffkind1;
                    break;
                }

            case CharWeapon.BOWKIND:
                {
                    skills[0] = data.bowkind1;
                    break;
                }
        }

        if(level >= 5)
            switch (Class)
            {
                case CharClass.DEFAULT:
                    {
                        skills[1] = data.knight2;
                        break;
                    }

                case CharClass.KNIGHT:
                    {
                        skills[1] = data.knight2;
                        break;
                    }

                case CharClass.SEER:
                    {
                        skills[1] = data.seer2;
                        break;
                    }
            }

        if(level >= 10)
            switch (Aspect)
            {
                case CharAspect.DEFAULT:
                    {
                        skills[2] = data.seer2;
                        break;
                    }

                case CharAspect.DOOM:
                    {
                        skills[2] = data.doom3;
                        break;
                    }

                case CharAspect.LIFE:
                    {
                        skills[2] = data.life3;
                        break;
                    }

                case CharAspect.SPACE:
                    {
                        skills[2] = data.space3;
                        break;
                    }

                case CharAspect.VOID:
                    {
                        skills[2] = data.void3;
                        break;
                    }
            }

        if(level >= 15)
            switch(Class)
            {
                case CharClass.DEFAULT:
                    {
                        switch(Aspect)
                        {
                            case CharAspect.DEFAULT:
                                {
                                    skills[3] = data.knightDoom4;
                                    break;
                                }

                            default:
                                {
                                    Debug.Log("you can't combine default class or aspect with anything else!");
                                    break;
                                }
                        }
                        break;
                    }

                case CharClass.KNIGHT:
                    {
                        switch (Aspect)
                        {
                            case CharAspect.DEFAULT:
                                {
                                    Debug.Log("you can't combine default class or aspect with anything else!");
                                    break;
                                }

                            case CharAspect.DOOM:
                                {
                                    skills[3] = data.knightDoom4;
                                    break;
                                }

                            case CharAspect.LIFE:
                                {
                                    skills[3] = data.knightLife4;
                                    break;
                                }

                            case CharAspect.SPACE:
                                {
                                    skills[3] = data.knightSpace4;
                                    break;
                                }

                            case CharAspect.VOID:
                                {
                                    skills[3] = data.knightVoid4;
                                    break;
                                }
                        }
                        break;
                    }

                case CharClass.SEER:
                    {
                        switch (Aspect)
                        {
                            case CharAspect.DEFAULT:
                                {
                                    Debug.Log("you can't combine default class or aspect with anything else!");
                                    break;
                                }

                            case CharAspect.DOOM:
                                {
                                    skills[3] = data.seerDoom4;
                                    break;
                                }

                            case CharAspect.LIFE:
                                {
                                    skills[3] = data.seerLife4;
                                    break;
                                }

                            case CharAspect.SPACE:
                                {
                                    skills[3] = data.seerSpace4;
                                    break;
                                }

                            case CharAspect.VOID:
                                {
                                    skills[3] = data.seerVoid4;
                                    break;
                                }
                        }
                        break;
                    }
            }
    }

    public void Update()
    {
        
    }

    /*
    public bool UseSkill(int id, Character target)
    {
        if(!target.IsAlive())
        {
            Debug.Log("fail");
            return false;
        }
        else
        {
            switch (skills[id].type)
            {
                case SkillType.ATTACK:
                    {


                    }

                        break;
                    
                case SkillType.HEAL:
                    {

                        break;
                    }

                default:
                    {
                        Debug.Log("smth is wrong");
                        break;
                    }
            }

            //target.TakeDamage(skills[id].power);
            return true;
        }
    }*/

    public void TakeDamage(int dmg)
    {
        int tmp = dmg - defence;
        if (tmp <= 0)
            return;
        currentHealth -= (dmg - defence);
    }

    public void DealDamage(Character target)
    {

    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if(currentHealth > health)
        {
            currentHealth = health;
        }
    }

    public bool IsAlive()
    {
        if (currentHealth <= 0)
            return false;
        return true;
    }
}


//original copy

/* 
  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharClass
{
DEFAULT,
KNIGHT,
SEER
}

public enum CharAspect
{
DEFAULT,
DOOM,
LIFE,
SPACE,
VOID
}

public class Character : MonoBehaviour
{
public bool IsCustom;

public new string name;

public int level;
public CharClass Class;
public CharAspect Aspect;

public int attack;
public int defence;

public int health;
public int currentHealth;

public int energy;
public int currentEnergy;

public float might;
public int speed;

public GameObject[] skillPrefabs;
public Skill[] skills;

public EffectContainer[] curEffects = new EffectContainer[4];

public bool acted;



private void Start()
{
    if(!IsCustom)
    {
        attack = level * 5;
        defence = level * (int)2.5;

        health = level * 10;
        currentHealth = health;

        energy = level * 5;
        currentEnergy = energy;

        might = 1 + (level * 0.1f);
        speed = level / 2;

        switch (Class)
        {
            case CharClass.DEFAULT:
                {


                    break;
                }
            case CharClass.KNIGHT:
                {
                    attack *= (int)1.25;
                    defence *= (int)1.25;

                    health *= (int)1.25;
                    currentHealth = health;

                    energy *= 1;
                    currentEnergy = energy;

                    might *= (int)1.1;
                    speed *= (int)1.25;

                    break;
                }
            case CharClass.SEER:
                {
                    attack *= (int)1;
                    defence *= (int)1;

                    health *= (int)1;
                    currentHealth = health;

                    energy *= (int)1.5;
                    currentEnergy = energy;

                    might *= (int)1.25;
                    speed *= (int)1;

                    break;
                }
        }

        acted = false;
    }

    skills = new Skill[skillPrefabs.Length];
    for (int i = 0; i < skillPrefabs.Length; i++)
    {
        skills[i] = skillPrefabs[i].GetComponent<Skill>();
    }
}

public void Update()
{

}

/*
public bool UseSkill(int id, Character target)
{
    if(!target.IsAlive())
    {
        Debug.Log("fail");
        return false;
    }
    else
    {
        switch (skills[id].type)
        {
            case SkillType.ATTACK:
                {


                }

                    break;

            case SkillType.HEAL:
                {

                    break;
                }

            default:
                {
                    Debug.Log("smth is wrong");
                    break;
                }
        }

        //target.TakeDamage(skills[id].power);
        return true;
    }
}

public void TakeDamage(int dmg)
{
    int tmp = dmg - defence;
    if (tmp <= 0)
        return;
    currentHealth -= (dmg - defence);
}

public void DealDamage(Character target)
{

}

public void Heal(int amount)
{
    currentHealth += amount;
    if (currentHealth > health)
    {
        currentHealth = health;
    }
}

public bool IsAlive()
{
    if (currentHealth <= 0)
        return false;
    return true;
}
}
     */