using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ItemObj : MonoBehaviour
{
    public UIManager manager;

    public string[] infoLines;
    public Item item;
    public bool dispencer;

    void Start()
    {
        StartCoroutine(setmanager());
    }



    IEnumerator setmanager()
    {
        yield return new WaitForSeconds(3f);
        manager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        //да простят меня боги за это
        if (manager == null)
            manager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "John(Clone)")
        {
            if (Input.GetKeyUp(KeyCode.X))
            {
                if (!manager.DialogueActive && !manager.InfoActive)
                {
                    if (FindObjectOfType<OverworldSystem>().FindEmptyInventorySlot() != -1)
                    {
                        manager.TextLines = infoLines;
                        manager.CurrentLine = 0;
                        manager.SetupPrintInfo();
                        FindObjectOfType<OverworldSystem>().inventory[FindObjectOfType<OverworldSystem>().FindEmptyInventorySlot()] = item;
                        
                        if(dispencer == false)
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        manager.TextLines = FindObjectOfType<DataContainer>().InventoryIsFullMessage;
                        manager.CurrentLine = 0;
                        manager.SetupPrintInfo();
                    }

                }
            }
        }
    }
}
