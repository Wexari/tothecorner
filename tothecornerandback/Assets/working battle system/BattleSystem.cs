using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState
{
    START, PLAYERTURN, ENEMYTURN, WON, LOST, WAITING
}

public class BattleSystem : MonoBehaviour
{
    public BattleUI UiSys;

    public GameObject[] playerPrefabs;
    public GameObject[] enemyPrefabs;

    public Transform[] playerStations;
    public Transform[] enemyStations;

    //ugh
    public bool IsCustom;
    public Character[] playerChars = new Character[4];
    public int curPlayer = 0;
    Character[] enemyChars = new Character[4];
    public int curEnemy = 0;

    public int playerSelection = 0;

    public int curTurn = 0;

    public BattleState state;

    public BattleHUD[] playerHUDs;
    public BattleHUD[] enemyHUDs;
    void Start()
    {
        StartCoroutine(Starter());
    }

    private void Update()
    {
        UiSys.CheckState(this.state);
        UpdateStatBars();
    }

    public IEnumerator Starter()
    {
        yield return new WaitForSeconds(2f);
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    public void UpdateStatBars()
    {
        try
        {

            for (int i = 0; i < 4; i++)
            {
                playerHUDs[i].hpSlider.value = playerChars[i].currentHealth;
                playerHUDs[i].enSlider.value = playerChars[i].currentEnergy;
            }

            for (int i = 0; i < 4; i++)
            {
                enemyHUDs[i].hpSlider.value = enemyChars[i].currentHealth;
                enemyHUDs[i].enSlider.value = enemyChars[i].currentEnergy;
            }
        }
        catch(Exception ex)
        {

        }


        //for(int i = 0; i < playerChars.Length; i++)
        //{
        //    if (playerChars[i].curEffects[0].timeLeft == 0)
        //        playerHUDs[i].effect = null;
        //}
    }

    IEnumerator SetupBattle()
    {

        yield return new WaitForSeconds(2f);
        GameObject playerGO;
        for (int i = 0; i < playerPrefabs.Length; i++)
        {
            playerGO = Instantiate(playerPrefabs[i], playerStations[i]);
            playerChars[i] = playerGO.GetComponent<Character>();
        }

        GameObject enemyGO;
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            enemyGO = Instantiate(enemyPrefabs[i], enemyStations[i]);
            enemyGO.transform.localRotation = Quaternion.Euler(0, 180, 0);
            enemyChars[i] = enemyGO.GetComponent<Character>();
        }

        UiSys.DialogueText.text = enemyChars[0].name + " comes to kick your ass";

        yield return new WaitForSeconds(2f);

        UiSys.playerHUD1.SetHUD(playerChars[0]);
        UiSys.playerHUD2.SetHUD(playerChars[1]);
        UiSys.playerHUD3.SetHUD(playerChars[2]);
        UiSys.playerHUD4.SetHUD(playerChars[3]);

        UiSys.enemyHUD1.SetHUD(enemyChars[0]);
        UiSys.enemyHUD2.SetHUD(enemyChars[1]);
        UiSys.enemyHUD3.SetHUD(enemyChars[2]);
        UiSys.enemyHUD4.SetHUD(enemyChars[3]);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        playerHUDs[curPlayer].SetColor("default");
        do
        {
            curPlayer++;
            if (curPlayer > 3)
                curPlayer = 0;
        }
        while (!playerChars[curPlayer].IsAlive());
        playerHUDs[curPlayer].SetColor("player");

        UiSys.DialogueText.text = "Your turn!";

        UiSys.curHealth.maxValue = playerChars[curPlayer].health;
        UiSys.curHealth.value = playerChars[curPlayer].currentHealth;
        UiSys.curEnergy.maxValue = playerChars[curPlayer].energy;
        UiSys.curEnergy.value = playerChars[curPlayer].currentEnergy;
        UiSys.curPortrait.sprite = playerChars[curPlayer].portrait;
        UiSys.curAttack.text = "" + playerChars[curPlayer].attack;
        UiSys.curDefence.text = "" + playerChars[curPlayer].defence;
        UiSys.curMight.text = "" + playerChars[curPlayer].might;
        UiSys.curSpeed.text = "" + playerChars[curPlayer].speed;
        UiSys.curName.text = playerChars[curPlayer].name;
        UiSys.curRole.text = playerChars[curPlayer].Class + " of " + playerChars[curPlayer].Aspect;

        for (int i = 0; i < 5; i++)
        {
            UiSys.skillButtons[i].image.sprite = playerChars[curPlayer].skills[i].icon;
        }

    }

    IEnumerator EnemyTurn()
    {

        enemyHUDs[curEnemy].SetColor("default");
        do
        {
            curEnemy++;
            if (curEnemy > 3)
                curEnemy = 0;
        }
        while (!enemyChars[curEnemy].IsAlive());


        enemyHUDs[curEnemy].SetColor("enemy");

        UiSys.DialogueText.text = enemyChars[curEnemy].name + " attacks!";

        yield return new WaitForSeconds(1f);

        playerChars[curPlayer].TakeDamage(enemyChars[curEnemy].attack);


        UiSys.DialogueText.text = enemyChars[curEnemy].name + " hit " + playerChars[curPlayer].name + " for " + (enemyChars[curEnemy].attack - playerChars[curPlayer].defence) + "!";

        yield return new WaitForSeconds(1f);

        if(AreAlliesDead())
        {
            state = BattleState.LOST;
            StartCoroutine(EndBattle());
        }
        else
        {
#warning вот это дерьмо тоже пофикси это же пиздец
            //MinusEffectTime();
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    IEnumerator EndBattle()
    {
        Debug.Log("did this even happen");
        if(state == BattleState.WON)
        {
            UiSys.DialogueText.text = "Victory!";
        }
        else if(state == BattleState.LOST)
        {
            UiSys.DialogueText.text = "You've lost.";
        }

        yield return new WaitForSeconds(2f);
        if(IsCustom == true)
        {
            Debug.Log("alright gotta go to main menu");
            FindObjectOfType<DevConsole>().ExecuteCommand("mainmenu");
        }
        else
        {
#warning сделай возврат в оверворлд после пиздилки
            Debug.Log("aaaand we're back to the show");
            FindObjectOfType<DevConsole>().ExecuteCommand("loadsave 0");
        }

    }

    public void SkillButton(int id)
    {
        StartCoroutine(UseSkill(id));
    }

    public void SetEnemySelection(int id)
    {
        enemyHUDs[playerSelection].SetColor("default");

        if (enemyChars[id].IsAlive())
        {
            playerSelection = id;
            enemyHUDs[playerSelection].SetColor("selection");
        }
        else
        {
            UiSys.DialogueText.text = "Wrong target: target is dead";
        }
    }

    public IEnumerator UseSkill(int id)
    {
        if (playerChars[curPlayer].currentEnergy >= playerChars[curPlayer].skills[id].cost)
        {
            switch (playerChars[curPlayer].skills[id].type)
            {
                case SkillType.ATTACK:
                    {
                        if (playerChars[curPlayer].skills[id].Cast(playerChars[curPlayer], enemyChars[playerSelection]))
                        {
                            UiSys.DialogueText.text = playerChars[curPlayer].name + " used " + playerChars[curPlayer].skills[id].name + " on " + enemyChars[playerSelection].name + "! " + playerChars[curPlayer].skills[id].Calculate(playerChars[curPlayer], enemyChars[playerSelection]) + " damage dealed!";


                            state = BattleState.WAITING;
                            yield return new WaitForSeconds(2f);

                        }
                        else
                        {
                            UiSys.DialogueText.text = "Wrong target.";
                        }
                        break;
                    }

                case SkillType.HEAL:
                    {
                        if (playerChars[curPlayer].skills[id].Cast(playerChars[curPlayer], playerChars[curPlayer]))
                        {
                            UiSys.DialogueText.text = playerChars[curPlayer].name + " healed himself with " + playerChars[curPlayer].skills[id].name + " for " + playerChars[curPlayer].skills[id].Calculate(playerChars[curPlayer], playerChars[curPlayer]);


                            state = BattleState.WAITING;
                            yield return new WaitForSeconds(2f);

                        }
                        else
                        {
                            UiSys.DialogueText.text = "Wrong target.";
                        }
                        break;
                    }

                case SkillType.MASSATTACK:
                    {
                        for (int i = 0; i < enemyChars.Length; i++)
                        {
                            playerChars[curPlayer].skills[id].Cast(playerChars[curPlayer], enemyChars[i]);

                        }

                        UiSys.DialogueText.text = playerChars[curPlayer].name + " used " + playerChars[curPlayer].skills[id].name + ", and dealed every enemy " + playerChars[curPlayer].skills[id].Calculate(playerChars[curPlayer], enemyChars[playerSelection]) + " damage!";

                        state = BattleState.WAITING;
                        yield return new WaitForSeconds(2f);



                        break;
                    }
                case SkillType.MASSHEAL:
                    {
                        for (int i = 0; i < playerChars.Length; i++)
                        {
                            playerChars[curPlayer].skills[id].Cast(playerChars[curPlayer], playerChars[i]);

                        }

                        UiSys.DialogueText.text = playerChars[curPlayer].name + " used " + playerChars[curPlayer].skills[id].name + ", and healed his allies for " + playerChars[curPlayer].skills[id].Calculate(playerChars[curPlayer], playerChars[curPlayer]) + "!";

                        state = BattleState.WAITING;
                        yield return new WaitForSeconds(2f);



                        break;
                    }
                /*case SkillType.EFFECTATTACK:
                    {
                        if (playerChars[curPlayer].skills[id].Cast(playerChars[curPlayer], enemyChars[playerSelection]))
                        {
                            UiSys.DialogueText.text = playerChars[curPlayer].name + " used " + playerChars[curPlayer].skills[id].name + " on " + enemyChars[playerSelection].name + "! " + playerChars[curPlayer].skills[id].power + " damage dealed!";


                            state = BattleState.WAITING;
                            yield return new WaitForSeconds(2f);

                            enemyHUDs[playerSelection].effect.sprite = playerChars[curPlayer].skills[id].effectPrefab.GetComponent<Effect>().icon;
                            UiSys.DialogueText.text = enemyChars[playerSelection].name + " suffers from " + playerChars[curPlayer].skills[id].effectPrefab.GetComponent<Effect>().name + "!";
                            yield return new WaitForSeconds(2f);


                        }
                        else
                        {
                            UiSys.DialogueText.text = "Wrong target.";
                        }
                        break;
                    }*/

                default:
                    {
                        Debug.Log("smth is wrong");
                        break;
                    }
            }

            if (AreEnemiesDead())
            {
                state = BattleState.WON;
                StartCoroutine(EndBattle());
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }

        }
        else
        {
            UiSys.DialogueText.text = "Not enough energy!";
        }

    }

    public bool AreEnemiesDead()
    {
        if (!enemyChars[0].IsAlive() && !enemyChars[1].IsAlive() && !enemyChars[2].IsAlive() && !enemyChars[3].IsAlive())
            return true;
        return false;
    }

    public bool AreAlliesDead()
    {
        if (!playerChars[0].IsAlive() && !playerChars[1].IsAlive() && !playerChars[2].IsAlive() && !playerChars[3].IsAlive())
            return true;
        return false;
    }

    /*public void MinusEffectTime()
    {
        for(int i = 0; i < playerChars.Length; i++)
        {
            for(int j = 0; j < playerChars[i].curEffects.Length; j++)
            {
                if (playerChars[i].curEffects[j].timeLeft != 0)
                playerChars[i].curEffects[j].timeLeft--;
            }
        }

        for (int i = 0; i < enemyChars.Length; i++)
        {
            for (int j = 0; j < enemyChars[i].curEffects.Length; j++)
            {
                if (enemyChars[i].curEffects[j].timeLeft != 0)
                    enemyChars[i].curEffects[j].timeLeft--;
            }
        }
    }*/
}

//original copy

/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState
{
START, PLAYERTURN, ENEMYTURN, WON, LOST, WAITING
}

public class BattleSystem : MonoBehaviour
{
public BattleUI UiSys;

public GameObject[] playerPrefabs;
public GameObject[] enemyPrefabs;

public Transform[] playerStations;
public Transform[] enemyStations;

Character[] playerChars = new Character[4];
public int curPlayer = 0;
Character[] enemyChars = new Character[4];
public int curEnemy = 0;

public int playerSelection = 0;

public int curTurn = 0;

public BattleState state;

public BattleHUD[] playerHUDs;
public BattleHUD[] enemyHUDs;
void Start()
{
    state = BattleState.START;
    StartCoroutine(SetupBattle());
}

private void Update()
{
    UiSys.CheckState(this.state);
    UpdateStatBars();
}


public void UpdateStatBars()
{
    for(int i = 0; i < 4; i++)
    {
        playerHUDs[i].hpSlider.value = playerChars[i].currentHealth;
    }

    for(int i = 0; i < 4; i++)
    {
        enemyHUDs[i].hpSlider.value = enemyChars[i].currentHealth;
    }

    for(int i = 0; i < playerChars.Length; i++)
    {
        if (playerChars[i].curEffects[0].timeLeft == 0)
            playerHUDs[i].effect = null;
    }
}

IEnumerator SetupBattle()
{
    GameObject playerGO;
    for (int i = 0; i < playerPrefabs.Length; i++)
    {
        playerGO = Instantiate(playerPrefabs[i], playerStations[i]);
        playerChars[i] = playerGO.GetComponent<Character>();
    }

    GameObject enemyGO;
    for (int i = 0; i < enemyPrefabs.Length; i++)
    {
        enemyGO = Instantiate(enemyPrefabs[i], enemyStations[i]);
        enemyChars[i] = enemyGO.GetComponent<Character>();
    }

    UiSys.DialogueText.text = enemyChars[0].name + " comes to kick your ass";

    UiSys.playerHUD1.SetHUD(playerChars[0]);
    UiSys.playerHUD2.SetHUD(playerChars[1]);
    UiSys.playerHUD3.SetHUD(playerChars[2]);
    UiSys.playerHUD4.SetHUD(playerChars[3]);

    UiSys.enemyHUD1.SetHUD(enemyChars[0]);
    UiSys.enemyHUD2.SetHUD(enemyChars[1]);
    UiSys.enemyHUD3.SetHUD(enemyChars[2]);
    UiSys.enemyHUD4.SetHUD(enemyChars[3]);

    yield return new WaitForSeconds(2f);

    state = BattleState.PLAYERTURN;
    PlayerTurn();

    #warning СЕЙЧАС У ВСЕХ НАБОР СКИЛЛОВ ОДИНАКОВ, ВОТ ЗДЕСЬ ВОТ ПОФИКСИ КОГДА СДЕЛАЕШЬ ПО-НОРМАЛЬНОМУ
    for(int i = 0; i < 5; i++)
    {
        UiSys.skillButtons[i].image.sprite = playerChars[0].skills[i].icon;
    }

}

void PlayerTurn()
{
    playerHUDs[curPlayer].SetColor("default");
    do
    {
        curPlayer++;
        if (curPlayer > 3)
            curPlayer = 0;
    }
    while (!playerChars[curPlayer].IsAlive());
    playerHUDs[curPlayer].SetColor("player");

    UiSys.DialogueText.text = "Your turn!";
}

/*IEnumerator PlayerAttack()
{
    if (enemyChars[playerSelection].IsAlive())
    {
        enemyChars[playerSelection].TakeDamage(playerChars[curPlayer].attack);

        enemyHUDs[playerSelection].SetHP(enemyChars[playerSelection].currentHealth);
        UiSys.DialogueText.text = playerChars[curPlayer].name + " hit " + enemyChars[playerSelection].name + " for " + (playerChars[curPlayer].attack - enemyChars[playerSelection].defence) + "!";

        yield return new WaitForSeconds(2f);

        if (AreEnemiesDead())
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    else
    {
        UiSys.DialogueText.text = "Wrong target: target is dead";
    }
}

IEnumerator PlayerHeal()
{
    playerChars[curPlayer].Heal(5);

    playerHUDs[curPlayer].SetHP(playerChars[curPlayer].currentHealth);
    UiSys.DialogueText.text = playerHUDs[curPlayer].name + " healed himself for 5!";

    yield return new WaitForSeconds(2f);

    state = BattleState.ENEMYTURN;
    StartCoroutine(EnemyTurn());
}

IEnumerator EnemyTurn()
{
    enemyHUDs[curEnemy].SetColor("default");
    do
    {
        curEnemy++;
        if (curEnemy > 3)
            curEnemy = 0;
    }
    while (!enemyChars[curEnemy].IsAlive());


    enemyHUDs[curEnemy].SetColor("enemy");

    UiSys.DialogueText.text = enemyChars[curEnemy].name + " attacks!";

    yield return new WaitForSeconds(1f);

    playerChars[curPlayer].TakeDamage(enemyChars[curEnemy].attack);


    UiSys.DialogueText.text = enemyChars[curEnemy].name + " hit " + playerChars[curPlayer].name + " for " + (enemyChars[curEnemy].attack - playerChars[curPlayer].defence) + "!";

    yield return new WaitForSeconds(1f);

    if (AreAlliesDead())
    {
        state = BattleState.LOST;
        EndBattle();
    }
    else
    {
    #warning вот это дерьмо тоже пофикси это же пиздец
        MinusEffectTime();
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
}

void EndBattle()
{
    if (state == BattleState.WON)
    {
        UiSys.DialogueText.text = "Victory!";
    }
    else if (state == BattleState.LOST)
    {
        UiSys.DialogueText.text = "You've lost.";
    }
}

public void OnAttackButton()
{
    if (state == BattleState.PLAYERTURN)
        StartCoroutine(PlayerAttack());
}

public void OnHealButton()
{
    if (state == BattleState.PLAYERTURN)
        StartCoroutine(PlayerHeal());
}

public void SkillButton(int id)
{
    StartCoroutine(UseSkill(id));
}

public void SetEnemySelection(int id)
{
    enemyHUDs[playerSelection].SetColor("default");

    if (enemyChars[id].IsAlive())
    {
        playerSelection = id;
        enemyHUDs[playerSelection].SetColor("selection");
    }
    else
    {
        UiSys.DialogueText.text = "Wrong target: target is dead";
    }
}

public IEnumerator UseSkill(int id)
{
    switch (playerChars[curPlayer].skills[id].type)
    {
        case SkillType.ATTACK:
            {
                if (playerChars[curPlayer].skills[id].Cast(playerChars[curPlayer], enemyChars[playerSelection]))
                {
                    UiSys.DialogueText.text = playerChars[curPlayer].name + " used " + playerChars[curPlayer].skills[id].name + " on " + enemyChars[playerSelection].name + "! " + playerChars[curPlayer].skills[id].power + " damage dealed!";


                    state = BattleState.WAITING;
                    yield return new WaitForSeconds(2f);

                    if (AreEnemiesDead())
                    {
                        state = BattleState.WON;
                        EndBattle();
                    }
                    else
                    {
                        state = BattleState.ENEMYTURN;
                        StartCoroutine(EnemyTurn());
                    }
                }
                else
                {
                    UiSys.DialogueText.text = "Wrong target.";
                }
                break;
            }

        case SkillType.HEAL:
            {
                if (playerChars[curPlayer].skills[id].Cast(playerChars[curPlayer], playerChars[curPlayer]))
                {
                    UiSys.DialogueText.text = playerChars[curPlayer].name + " healed himself with " + playerChars[curPlayer].skills[id].name + " for " + playerChars[curPlayer].skills[id].power * playerChars[curPlayer].might;


                    state = BattleState.WAITING;
                    yield return new WaitForSeconds(2f);

                    if (AreEnemiesDead())
                    {
                        state = BattleState.WON;
                        EndBattle();
                    }
                    else
                    {
                        state = BattleState.ENEMYTURN;
                        StartCoroutine(EnemyTurn());
                    }
                }
                else
                {
                    UiSys.DialogueText.text = "Wrong target.";
                }
                break;
            }

        case SkillType.MASSATTACK:
            {
                for (int i = 0; i < enemyChars.Length; i++)
                {
                    playerChars[curPlayer].skills[id].Cast(playerChars[curPlayer], enemyChars[i]);

                }

                UiSys.DialogueText.text = playerChars[curPlayer].name + " used " + playerChars[curPlayer].skills[id].name + ", and dealed every enemy " + playerChars[curPlayer].skills[id].power * playerChars[curPlayer].might + " damage!";

                state = BattleState.WAITING;
                yield return new WaitForSeconds(2f);

                if (AreEnemiesDead())
                {
                    state = BattleState.WON;
                    EndBattle();
                }
                else
                {
                    state = BattleState.ENEMYTURN;
                    StartCoroutine(EnemyTurn());
                }


                break;
            }
        case SkillType.MASSHEAL:
            {
                for (int i = 0; i < playerChars.Length; i++)
                {
                    playerChars[curPlayer].skills[id].Cast(playerChars[curPlayer], playerChars[i]);

                }

                UiSys.DialogueText.text = playerChars[curPlayer].name + " used " + playerChars[curPlayer].skills[id].name + ", and healed his allies for " + playerChars[curPlayer].skills[id].power * playerChars[curPlayer].might + "!";

                state = BattleState.WAITING;
                yield return new WaitForSeconds(2f);

                if (AreEnemiesDead())
                {
                    state = BattleState.WON;
                    EndBattle();
                }
                else
                {
                    state = BattleState.ENEMYTURN;
                    StartCoroutine(EnemyTurn());
                }


                break;
            }
        case SkillType.EFFECTATTACK:
            {
                if (playerChars[curPlayer].skills[id].Cast(playerChars[curPlayer], enemyChars[playerSelection]))
                {
                    UiSys.DialogueText.text = playerChars[curPlayer].name + " used " + playerChars[curPlayer].skills[id].name + " on " + enemyChars[playerSelection].name + "! " + playerChars[curPlayer].skills[id].power + " damage dealed!";


                    state = BattleState.WAITING;
                    yield return new WaitForSeconds(2f);

                    enemyHUDs[playerSelection].effect.sprite = playerChars[curPlayer].skills[id].effectPrefab.GetComponent<Effect>().icon;
                    UiSys.DialogueText.text = enemyChars[playerSelection].name + " suffers from " + playerChars[curPlayer].skills[id].effectPrefab.GetComponent<Effect>().name + "!";
                    yield return new WaitForSeconds(2f);

                    if (AreEnemiesDead())
                    {
                        state = BattleState.WON;
                        EndBattle();
                    }
                    else
                    {
                        state = BattleState.ENEMYTURN;
                        StartCoroutine(EnemyTurn());
                    }
                }
                else
                {
                    UiSys.DialogueText.text = "Wrong target.";
                }
                break;
            }

        default:
            {
                Debug.Log("smth is wrong");
                break;
            }
    }
    MinusEffectTime();
}

public bool AreEnemiesDead()
{
    if (!enemyChars[0].IsAlive() && !enemyChars[1].IsAlive() && !enemyChars[2].IsAlive() && !enemyChars[3].IsAlive())
        return true;
    return false;
}

public bool AreAlliesDead()
{
    if (!playerChars[0].IsAlive() && !playerChars[1].IsAlive() && !playerChars[2].IsAlive() && !playerChars[3].IsAlive())
        return true;
    return false;
}

public void MinusEffectTime()
{
    for (int i = 0; i < playerChars.Length; i++)
    {
        for (int j = 0; j < playerChars[i].curEffects.Length; j++)
        {
            if (playerChars[i].curEffects[j].timeLeft != 0)
                playerChars[i].curEffects[j].timeLeft--;
        }
    }

    for (int i = 0; i < enemyChars.Length; i++)
    {
        for (int j = 0; j < enemyChars[i].curEffects.Length; j++)
        {
            if (enemyChars[i].curEffects[j].timeLeft != 0)
                enemyChars[i].curEffects[j].timeLeft--;
        }
    }
}
}
     */
