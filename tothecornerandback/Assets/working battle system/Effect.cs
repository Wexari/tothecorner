using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    PlusAttack, PlusDefence, PlusMaxHealth, PlusMaxEnergy, PlusMight, PlusSpeed, MinusAttack, MinusDefence, MinusMaxHealth, MinusMaxEnergy, MinusMight, MinusSpeed, PureDamage, Stun, Regeneration
}

public class Effect : MonoBehaviour
{
    public new string name;
    public Sprite icon;

    public EffectType type;
}

#warning почему бы не сделать так чтобы эффекты сами отрабатывались в виде функции у себя самого в зависимости от своего типа

//original copy

/* 
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
PlusAttack, PlusDefence, PlusMaxHealth, PlusMaxEnergy, PlusMight, PlusSpeed, MinusAttack, MinusDefence, MinusMaxHealth, MinusMaxEnergy, MinusMight, MinusSpeed, PureDamage, Stun, Regeneration
}

public class Effect : MonoBehaviour
{
public new string name;
public Sprite icon;

public EffectType type;
}
 */
