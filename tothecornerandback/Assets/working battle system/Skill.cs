using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkillType
{
    ATTACK, HEAL, EFFECT, MASSATTACK, MASSHEAL, MASSEFFECT, EFFECTATTACK, EFFECTHEAL, MASSEFFECTATTACK, MASSEFFECTHEAL, MASSHEALTHBUFF, MASSATTACKBUFF, VAMPIREALL
}

public class Skill : MonoBehaviour
{
    public new string name;
    public Sprite icon;
    public SkillType type;
    public string description;
    public int grade;

    public int power;
    public int cost;
    
    //public GameObject effectPrefab;
    //public int effectPower;
    //public int effectDuration;
    //public bool effectOnCaster;

    public bool Cast(Character caster, Character target)
    {
        if (caster.currentEnergy >= cost)
        {
            caster.currentEnergy -= cost;

            switch (type)
            {
                case SkillType.ATTACK:
                    {
                        if (target.IsAlive())
                        {
                            target.TakeDamage(Calculate(caster, target));
                            return true;
                        }
                        else
                        {
                            return false;

                        }
                    }

                case SkillType.HEAL:
                    {
                        if (target.IsAlive())
                        {
                            target.Heal(Calculate(caster, caster));
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case SkillType.MASSATTACK:
                    {
                        if (target.IsAlive())
                        {
                            target.TakeDamage((int)(power * caster.might));
                            return true;
                        }
                        else
                        {
                            Debug.Log("this one is dead");
                            return false;

                        }
                    }
                case SkillType.MASSHEAL:
                    {
                        if (target.IsAlive())
                        {
                            target.Heal((int)(power * caster.might));
                            return true;
                        }
                        else
                        {
                            Debug.Log("can't heal dead ones sorry");
                            return false;
                        }
                    }
                case SkillType.MASSEFFECT:
                    {
                        if (target.IsAlive())
                        {
                            target.defence += power * caster.wisdom / 10;
                            return true;
                        }
                        else
                        {
                            Debug.Log("can't buff dead ones sorry");
                            return false;
                        }
                    }
                case SkillType.MASSEFFECTATTACK:
                    {
                        if (target.IsAlive())
                        {
                            target.TakeDamage((int)(power * caster.might));
                            target.defence -= power * caster.wisdom / 10;
                            return true;
                        }
                        else
                        {
                            Debug.Log("can't buff dead ones sorry");
                            return false;
                        }
                    }
                case SkillType.MASSATTACKBUFF:
                    {
                        if (target.IsAlive())
                        {
                            target.attack += power * caster.wisdom / 10;
                            return true;
                        }
                        else
                        {
                            Debug.Log("can't buff dead ones sorry");
                            return false;
                        }
                    }

                case SkillType.MASSHEALTHBUFF:
                    {
                        if (target.IsAlive())
                        {
                            target.health += power * caster.wisdom / 10;
                            target.currentHealth += power * caster.wisdom / 10;
                            return true;
                        }
                        else
                        {
                            Debug.Log("can't buff dead ones sorry");
                            return false;
                        }
                    }

                case SkillType.VAMPIREALL:
                    {
                        if (target.IsAlive())
                        {
                            target.health += power * caster.wisdom / 10;
                            target.currentHealth += power * caster.wisdom / 10;
                            return true;
                        }
                        else
                        {
                            Debug.Log("can't buff dead ones sorry");
                            return false;
                        }
                    }

                /*case SkillType.EFFECTATTACK:
                    {
                        if (target.IsAlive())
                        {
                            target.TakeDamage((int)(power * caster.might));
                            if (effectOnCaster)
                            {
                                Debug.Log("whooooosh on caster");
                            }
                            else
                            {
                                target.curEffects[0].effect = effectPrefab.GetComponent<Effect>();
                                target.curEffects[0].power = effectPower;
                                target.curEffects[0].timeLeft = effectDuration;
                                Debug.Log("whooooosh on target");
                            }

                            return true;
                        }
                        else
                        {
                            return false;

                        }
                    }*/

                /*case SkillType.EFFECTHEAL:
                    {
                        if (target.IsAlive())
                        {
                            target.TakeDamage((int)(power * caster.might));
                            if (effectOnCaster)
                            {
                                Debug.Log("whooooosh on caster");
                            }
                            else
                            {
                                Debug.Log("whooooosh on target");
                            }

                            return true;
                        }
                        else
                        {
                            return false;

                        }
                    }*/

                /*case SkillType.MASSEFFECTATTACK:
                    {
                        if (target.IsAlive())
                        {
                            target.TakeDamage((int)(power * caster.might));
                            //effect enemy
                            return true;
                        }
                        else
                        {
                            Debug.Log("this one is dead");
                            return false;

                        }
                    }*/

                /*case SkillType.MASSEFFECTHEAL:
                    {
                        if (target.IsAlive())
                        {
                            target.Heal((int)(power * caster.might));
                            //effect team
                            return true;
                        }
                        else
                        {
                            Debug.Log("can't heal dead ones sorry");
                            return false;
                        }
                    }*/
                default:
                    {
                        Debug.Log("skill is broken, fix it, bob the programmer");
                        return false;
                    }
            }
            return true;
        }
        else
        {
            Debug.Log("not enough energy");
            return false;
        }

    }

    //подсчёт эффекта способности
    public int Calculate(Character caster, Character target)
    {
        switch(type)
        {
            case SkillType.ATTACK:
                {
                    return (int)((1 +  caster.attack + (power * caster.might)) + caster.Weapon.power - (target.defence + target.Armor.power));
                }
            case SkillType.HEAL:
                {
                    return (int)(1 + caster.wisdom + (power * caster.might) + caster.Weapon.power / 2);
                }
            case SkillType.MASSATTACK:
                {
                    return (int)((1 + caster.attack + (power * caster.might) * 0.75) + caster.Weapon.power - (target.defence + target.Armor.power));
                }
            case SkillType.MASSHEAL:
                {
                    return (int)((1 + caster.wisdom + (power * caster.might) * 0.75) + caster.Weapon.power / 4);
                }
            default:
                {
                    Debug.Log("something went wrong with skill calculation");
                    return 0;
                }
        }
    }
}

//original copy

/* 
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkillType
{
ATTACK, HEAL, EFFECT, MASSATTACK, MASSHEAL, MASSEFFECT, EFFECTATTACK, EFFECTHEAL, MASSEFFECTATTACK, MASSEFFECTHEAL
}
public class Skill : MonoBehaviour
{
public new string name;
public Sprite icon;
public SkillType type;

public int power;
public GameObject effectPrefab;
public int effectPower;
public int effectDuration;
public bool effectOnCaster;

public bool Cast(Character caster, Character target)
{
    switch(type)
    {
        case SkillType.ATTACK:
            {
                if(target.IsAlive())
                {
                    target.TakeDamage((int)(power * caster.might));
                    return true;
                }
                else
                {
                    return false;

                }
            }

        case SkillType.HEAL:
            {
                if(target.IsAlive())
                {
                    target.Heal((int)(power * caster.might));
                    return true;
                }
                else
                {
                    return false;
                }
            }
        case SkillType.MASSATTACK:
            {
                if (target.IsAlive())
                {
                    target.TakeDamage((int)(power * caster.might));
                    return true;
                }
                else
                {
                    Debug.Log("this one is dead");
                    return false;

                }
            }
        case SkillType.MASSHEAL:
            {
                if(target.IsAlive())
                {
                    target.Heal((int)(power * caster.might));
                    return true;
                }
                else
                {
                    Debug.Log("can't heal dead ones sorry");
                    return false;
                }
            }

        case SkillType.EFFECTATTACK:
            {
                if (target.IsAlive())
                {
                    target.TakeDamage((int)(power * caster.might));
                    if(effectOnCaster)
                    {
                        Debug.Log("whooooosh on caster");
                    }
                    else
                    {
                        target.curEffects[0].effect = effectPrefab.GetComponent<Effect>();
                        target.curEffects[0].power = effectPower;
                        target.curEffects[0].timeLeft = effectDuration;
                        Debug.Log("whooooosh on target");
                    }

                    return true;
                }
                else
                {
                    return false;

                }
            }

        case SkillType.EFFECTHEAL:
            {
                if (target.IsAlive())
                {
                    target.TakeDamage((int)(power * caster.might));
                    if (effectOnCaster)
                    {
                        Debug.Log("whooooosh on caster");
                    }
                    else
                    {
                        Debug.Log("whooooosh on target");
                    }

                    return true;
                }
                else
                {
                    return false;

                }
            }

        case SkillType.MASSEFFECTATTACK:
            {
                if (target.IsAlive())
                {
                    target.TakeDamage((int)(power * caster.might));
                    //effect enemy
                    return true;
                }
                else
                {
                    Debug.Log("this one is dead");
                    return false;

                }
            }

        case SkillType.MASSEFFECTHEAL:
            {
                if (target.IsAlive())
                {
                    target.Heal((int)(power * caster.might));
                    //effect team
                    return true;
                }
                else
                {
                    Debug.Log("can't heal dead ones sorry");
                    return false;
                }
            }
        default:
            {
                Debug.Log("skill is broken, fix it, bob the programmer");
                return false;
            }
    }

}
}
 */
