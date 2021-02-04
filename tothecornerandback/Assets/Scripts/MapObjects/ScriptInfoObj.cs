using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

class ScriptInfoObj : InfoObj
{
    //x - где, у - что
    public Vector2Int[] functions;

    void Start()
    {
        StartCoroutine(setmanager());
    }

    IEnumerator setmanager()
    {
        yield return new WaitForSeconds(2f);
        manager = FindObjectOfType<UIManager>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "John(Clone)")
        {
            if (Input.GetKeyUp(KeyCode.X) || mine)
            {
                if (!manager.DialogueActive && !manager.InfoActive && !manager.ScriptActive)
                {
                    manager.TextLines = infoLines;
                    manager.CurrentLine = 0;
                    manager.Functions = functions;
                    manager.SetupPrintScriptInfo();
                    if (mine)
                        gameObject.SetActive(false);
                }

            }
        }

    }
}