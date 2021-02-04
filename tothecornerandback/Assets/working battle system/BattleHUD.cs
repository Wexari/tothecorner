using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Image background;
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;
    public Slider enSlider;
    public Image effect;

    public int order;

    public void SetHUD(Character charc)
    {
        nameText.text = charc.name;
        levelText.text = "LV " + charc.level;

        hpSlider.maxValue = charc.health;
        hpSlider.value = charc.currentHealth;

        enSlider.maxValue = charc.energy;
        enSlider.value = charc.currentEnergy;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

    public void OnMouseDown()
    {
        Debug.Log(order);
    }

    public void SetColor(string name)
    {
        switch(name)
        {
            case "player":
                {
                    background.material = GetComponentInParent<BattleUI>().curPlayerMaterial;
                    break;
                }
            case "enemy":
                {
                    background.material = GetComponentInParent<BattleUI>().curEnemyMaterial;
                    break;
                }
            case "selection":
                {
                    background.material = GetComponentInParent<BattleUI>().curSelectedEnemyMaterial;
                    break;
                }
            default:
                {
                    background.material = GetComponentInParent<BattleUI>().defaultMaterial;
                    break;
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

public class BattleHUD : MonoBehaviour
{
public Image background;
public Text nameText;
public Text levelText;
public Slider hpSlider;
public Image effect;

public int order;

public void SetHUD(Character charc)
{
    nameText.text = charc.name;
    levelText.text = "LV " + charc.level;
    if (charc.IsCustom)
    {
        hpSlider.maxValue = charc.health;
        hpSlider.value = charc.currentHealth;
    }
    else
    {
        hpSlider.maxValue = charc.level * 10;
        hpSlider.value = hpSlider.maxValue;
    }
}

public void SetHP(int hp)
{
    hpSlider.value = hp;
}

public void OnMouseDown()
{
    Debug.Log(order);
}

public void SetColor(string name)
{
    switch(name)
    {
        case "player":
            {
                background.material = GetComponentInParent<BattleUI>().curPlayerMaterial;
                break;
            }
        case "enemy":
            {
                background.material = GetComponentInParent<BattleUI>().curEnemyMaterial;
                break;
            }
        case "selection":
            {
                background.material = GetComponentInParent<BattleUI>().curSelectedEnemyMaterial;
                break;
            }
        default:
            {
                background.material = GetComponentInParent<BattleUI>().defaultMaterial;
                break;
            }
    }
}
}
 */
