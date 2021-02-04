using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleTeleporter : MonoBehaviour
{
    public Item triggerItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FindObjectOfType<OverworldSystem>().DoesPlayerHaveItem(triggerItem))
            Teleport();
    }

    public void Teleport()
    {
        FindObjectOfType<GlobalSystem>().LoadMap(6);
    }
}
