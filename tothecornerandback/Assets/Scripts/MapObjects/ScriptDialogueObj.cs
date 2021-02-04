using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

//недоработано
class ScriptDialogueObj : DialogueObj
{
    //public UnityEvent[] Actions;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "John(Clone)")
        {
            if (Input.GetKeyUp(KeyCode.X))
            {
                if (!manager.DialogueActive && !manager.InfoActive)
                {
                    manager.CurrentLine = 0;
                    manager.TextLines = dialogueLines;
                    manager.DialogueMood = dialogueMood;

                    manager.SetupPrintDialogue();

                    //Actions[manager.CurrentLine].Invoke();
                }
            }
        }
    }


}