using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Attributes
{
    public int attack;
    public int defence;
    public int wisdom;
    public int maxHealth;
    public int maxEnergy;
    public float might;
    public int speed;
    public int expRequired;
}

[System.Serializable]
public struct StatModificators
{
    public float attack;
    public float defence;
    public float wisdom;
    public float maxHealth;
    public float maxEnergy;
    public float might;
    public float speed;
}

[System.Serializable]
public class StatSystem : MonoBehaviour
{
    public int levelCap;
    public Attributes[] attributes;
    public StatModificators KnightModificators;
    public StatModificators SeerModificators;

}
