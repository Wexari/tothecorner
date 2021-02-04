using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//коденк после суток без сна аийе
public class HorrusLittleHelper : MonoBehaviour
{
    public Item Coins;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(FindObjectOfType<OverworldSystem>().DoesPlayerHaveItem(Coins))
        {
            FindObjectOfType<DevConsole>().ExecuteCommand("givestuff");
            //for(int i = 0; i < FindObjectOfType<OverworldSystem>().inventory.Length; i++)
            //{
            //    if (FindObjectOfType<OverworldSystem>().inventory[i] == Coins)
            //        FindObjectOfType<OverworldSystem>().inventory[i] = FindObjectOfType<DataContainer>().EMPTY;

            //}
            //FindObjectOfType<OverworldSystem>().inventory[FindObjectOfType<OverworldSystem>().FindEmptyInventorySlot()] = FindObjectOfType<DataContainer>().Gambeson;
            //switch(FindObjectOfType<DataContainer>().saves[FindObjectOfType<GlobalSystem>().SaveId].PlayerParty[0].GetComponent<Character>().WeaponType)
            //{
            //    case CharWeapon.BLADEKIND:
            //        {
            //            FindObjectOfType<OverworldSystem>().inventory[FindObjectOfType<OverworldSystem>().FindEmptyInventorySlot()] = FindObjectOfType<DataContainer>().BetterSword;
            //            break;
            //        }

            //    case CharWeapon.POLEARMKIND:
            //        {
            //            FindObjectOfType<OverworldSystem>().inventory[FindObjectOfType<OverworldSystem>().FindEmptyInventorySlot()] = FindObjectOfType<DataContainer>().BetterPolearm;
            //            break;
            //        }

            //    case CharWeapon.STAFFKIND:
            //        {
            //            FindObjectOfType<OverworldSystem>().inventory[FindObjectOfType<OverworldSystem>().FindEmptyInventorySlot()] = FindObjectOfType<DataContainer>().BetterStaff;
            //            break;
            //        }

            //    case CharWeapon.BOWKIND:
            //        {
            //            FindObjectOfType<OverworldSystem>().inventory[FindObjectOfType<OverworldSystem>().FindEmptyInventorySlot()] = FindObjectOfType<DataContainer>().BetterBow;
            //            break;
            //        }
            //}

        }

        gameObject.SetActive(false);
    }
}
