using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public Text DialogueText;

    public BattleHUD playerHUD1;
    public BattleHUD playerHUD2;
    public BattleHUD playerHUD3;
    public BattleHUD playerHUD4;

    public BattleHUD enemyHUD1;
    public BattleHUD enemyHUD2;
    public BattleHUD enemyHUD3;
    public BattleHUD enemyHUD4;

    public Button[] skillButtons;
    public GameObject eventSystem;

    public Material defaultMaterial;
    public Material curPlayerMaterial;
    public Material curEnemyMaterial;
    public Material curSelectedEnemyMaterial;

    public Material defaultSkillMaterial;
    public Material unavailableSkillMaterial;

    //
    public bool BORDER;
    //

    public Image curPortrait;
    public Text curName;
    public Text curRole;
    public Slider curHealth;
    public Slider curEnergy;
    public Text curAttack;
    public Text curDefence;
    public Text curMight;
    public Text curSpeed;

    public void CheckState(BattleState state)
    {
        switch (state)
        {
            case BattleState.PLAYERTURN:
                {
                    SetActiveUI(true);
                    for (int i = 0; i < skillButtons.Length; i++)
                    {
                        skillButtons[i].image.material = defaultSkillMaterial;
                    }
                    break;
                }
            default:
                {

                    SetActiveUI(false);
                    for (int i = 0; i < skillButtons.Length; i++)
                    {
                        skillButtons[i].image.material = unavailableSkillMaterial;
                    }
                    break;
                }
        }

    }

    public void SetActiveUI(bool active)
    {
        eventSystem.SetActive(active);
    }

}

//original copy

/* 
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
public Text DialogueText;

public BattleHUD playerHUD1;
public BattleHUD playerHUD2;
public BattleHUD playerHUD3;
public BattleHUD playerHUD4;

public BattleHUD enemyHUD1;
public BattleHUD enemyHUD2;
public BattleHUD enemyHUD3;
public BattleHUD enemyHUD4;

public Button[] skillButtons;
public GameObject eventSystem;

public Material defaultMaterial;
public Material curPlayerMaterial;
public Material curEnemyMaterial;
public Material curSelectedEnemyMaterial;

public Material defaultSkillMaterial;
public Material unavailableSkillMaterial;

public void CheckState(BattleState state)
{
    switch (state)
    {
        case BattleState.PLAYERTURN:
            {
                SetActiveUI(true);
                for (int i = 0; i < skillButtons.Length; i++)
                {
                    skillButtons[i].image.material = defaultSkillMaterial;
                }
                break;
            }
        default:
            {

                SetActiveUI(false);
                for (int i = 0; i < skillButtons.Length; i++)
                {
                    skillButtons[i].image.material = unavailableSkillMaterial;
                }
                break;
            }
    }

}

public void SetActiveUI(bool active)
{
    eventSystem.SetActive(active);
}

}
 */
