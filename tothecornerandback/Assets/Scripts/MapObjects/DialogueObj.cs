using System.Collections;
using UnityEngine;

class DialogueObj : MonoBehaviour
{
    public UIManager manager;

    public string[] dialogueLines;
    public float[] dialogueMood;

    public bool mine;

    void Start()
    {
        StartCoroutine(setmanager());
    }

    private void Update()
    {
        //да простят меня боги за это
        if (manager == null)
            manager = FindObjectOfType<UIManager>();
    }

    IEnumerator setmanager()
    {
        yield return new WaitForSeconds(1f);
        manager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "John(Clone)")
        {
            if (Input.GetKeyUp(KeyCode.X) || mine)
            {
                if (!manager.DialogueActive && !manager.InfoActive)
                {
                    manager.CurrentLine = 0;
                    manager.TextLines = dialogueLines;
                    manager.DialogueMood = dialogueMood;
                    manager.SetupPrintDialogue();
                    
                    if(mine)
                    {
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}