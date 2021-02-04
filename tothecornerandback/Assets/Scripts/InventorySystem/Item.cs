using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    EMPTY, BASIC, QUEST, WEAPON, ARMOR, CONSUMABLE
}

public class Item : MonoBehaviour
{
    public new string name;
    public ItemType type;
    public int subType;
    public string description;
    public int power;
    public bool disposable;

    public void Use(Character caster)
    {
        DevConsole devtmp = FindObjectOfType<DevConsole>();
        switch(type)
        {
            case ItemType.EMPTY:
                {
                    break;
                }

            case ItemType.BASIC:
                {
                    switch(subType)
                    {
                        //обломки экскалибура
                        case 0:
                            {
                                devtmp.ExecuteCommand("say Вы выбросили металоллом в мусорку, туда куда ему и место.");
                                break;
                            }
                        default:
                            {
                                devtmp.ExecuteCommand("say " + description);
                                break;
                            }
                    }
                    
                    break;
                }

            case ItemType.QUEST:
                {
                    switch (subType)
                    {
                        //мешочек с деньгами
                        case 0:
                            {
                                devtmp.ExecuteCommand("say Раскрыв мешочек, вы насчитали в нём сотню ромбовидных монеток. Интересно, сколько это будет в нашей валюте?");
                                break;
                            }

                        //чаша
                        case 1:
                            {
                                devtmp.ExecuteCommand("say Чаша как чаша. Ничего с ней пока что не сделаешь.");
                                break;
                            }

                        //концентратор частиц
                        case 2:
                            {
                                devtmp.ExecuteCommand("say Нужно как можно скорее отнести эту сферу к кругу во внутреннем дворе!");
                                break;
                            }

                        default:
                            {
                                devtmp.ExecuteCommand("say " + description);
                                break;
                            }
                    }

                    break;
                }

            case ItemType.WEAPON:
                {

                    break;
                }

            case ItemType.ARMOR:
                {

                    break;
                }

            case ItemType.CONSUMABLE:
                {
                    switch(subType)
                    {
                        //healing yourself
                        case 0:
                            {
                                caster.currentHealth += power;
                                devtmp.ExecuteCommand("say " + caster.name + " использовал " + name + ": " + power + " здоровья восстановлено!");
                                break;
                            }
                            //healing your energy
                        case 1:
                            {
                                caster.currentEnergy += power;
                                devtmp.ExecuteCommand("say " + caster.name + " использовал " + name + ": " + power + " энергии восстановлено!");
                                break;
                            }
                    }
                    break;
                }
        }


    }

    public void PrintInfo()
    {
        DevConsole devtmp = FindObjectOfType<DevConsole>();
        switch (type)
        {
            case ItemType.EMPTY:
                {
                    break;
                }

            case ItemType.BASIC:
                {
                    devtmp.ExecuteCommand("say " + name + "\n \n" + description);
                    break;
                }

            case ItemType.QUEST:
                {
                    devtmp.ExecuteCommand("say " + name + "\n \n" + description);
                    break;
                }

            case ItemType.WEAPON:
                {
                    CharWeapon weapontype;
                    switch(subType)
                    {
                        case 0:
                            {
                                weapontype = CharWeapon.DEFAULT;
                                break;
                            }
                        case 1:
                            {
                                weapontype = CharWeapon.BLADEKIND;
                                break;
                            }
                        case 2:
                            {
                                weapontype = CharWeapon.POLEARMKIND;
                                break;
                            }
                        case 3:
                            {
                                weapontype = CharWeapon.STAFFKIND;
                                break;
                            }
                        case 4:
                            {
                                weapontype = CharWeapon.BOWKIND;
                                break;
                            }
                        default:
                            {
                                weapontype = CharWeapon.DEFAULT;
                                break;
                            }
                    }

                    devtmp.ExecuteCommand("say " + name + "\n\nType: " + weapontype +"\n \nБонус к атаке: " + power + "\n \n" + description);
                    break;
                }

            case ItemType.ARMOR:
                {
                    devtmp.ExecuteCommand("say " + name + "\n \nБонус к защите: " + power + "\n \n" + description);
                    break;
                }

            case ItemType.CONSUMABLE:
                {
                    switch (subType)
                    {
                        //healing yourself
                        case 0:
                            {
                                devtmp.ExecuteCommand("say " + name + "\n \nИспользовать: восстановить " + power + " очков здоровья. \n \n" + description);
                                break;
                            }
                    }
                    break;
                }
        }
    }

    /*
    public void Trash()
    {
        Item empty = FindObjectOfType<DataContainer>().EMPTY;

        this.name = empty.name;
        this.type = empty.type;
        this.subType = empty.subType;
        this.description = empty.description;
        this.power = empty.power;
        this.disposable = empty.disposable;
    }*/
}