using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurLevel
{
    TUTORIAL, SNOW, LAB, HILLS, FOREST, CASTLE, MENU, EPILOGUE
}

public class OverworldSystem : MonoBehaviour
{
    public GameObject uimanager;
    private UIManager manager;

    public GameObject Actor;
    public Item[] inventory = new Item[10];

    //public DialogueManager DialogManager;

    public CurLevel currentLevel;

    //technical
    private bool PlayerMoving;
    public bool PlayerActing;
    public Animator PlayerAnimator;
    public Rigidbody2D PlayerRigidbody;
    public BoxCollider2D PlayerCollider;
    public Vector2 PlayerLastMove;
    //settings
    public float PlayerSpeed;
    public bool Freeze;
    public int RandEncLevel;
    public bool RandEncEnabled;
    public System.Random RandomEncounterGenerator = new System.Random();

    void Start()
    {
        Setup();

    }

    void Setup()
    {
        try
        {

        
        manager = FindObjectOfType<UIManager>();

        PlayerRigidbody = Actor.GetComponent<Rigidbody2D>();
        PlayerAnimator = Actor.GetComponent<Animator>();
        PlayerCollider = Actor.GetComponent<BoxCollider2D>();
        }
        catch(Exception ex)
        {

        }
    }

    void DoRandomEncounters()
    {
        if(RandEncEnabled && RandEncLevel > 0)
        {
            if (PlayerMoving)
            {
                if(RandomEncounterGenerator.Next(0, 1000) <= 2)
                {
                    int fight;
                    switch(RandEncLevel)
                    {
                        //easy(imps), medium (imps, ogres, basylisks), hard(ogres, basylisks)
                        case 1:
                            {
                                fight = new System.Random().Next(1, 3);
                                break;
                            }
                        case 2:
                            {
                                fight = new System.Random().Next(4, 7);
                                break;
                            }
                        case 3:
                            {
                                fight = new System.Random().Next(8, 10);
                                break;
                            }
                        default:
                            {
                                fight = new System.Random().Next(1, 3);
                                break;
                            }
                    }
                    Debug.Log(fight + " is rolled");
                    //я не могу до сих пор понять почему вызов битвы таким образом не работает, а через консоль - работает
                    //неужто дело в том что обьект уничтожается после смены сцены?
                    //скорее всего да
                    //но сейчас половина первого ночи двадцать первого июня, уж простите
                    //StartCoroutine(FindObjectOfType<GlobalSystem>().TriggerFight(fight));
                    //FindObjectOfType<DevConsole>().ExecuteCommand("loadfight " + fight);
                }
            }
        }

    }

    void Update()
    {
        if (Freeze == false)
        {
            PlayerMovement();
            DoRandomEncounters();
            //InteractionCheck();
        }
    }

    public void PlayerMovement()
    {
        try
        {

        
        PlayerMoving = false;
        PlayerActing = false;
        if (Input.GetAxisRaw("Horizontal") > 0.1 || Input.GetAxisRaw("Horizontal") < -0.1)
        {
            PlayerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * PlayerSpeed, PlayerRigidbody.velocity.y);
            PlayerMoving = true;
            PlayerLastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0.1 || Input.GetAxisRaw("Vertical") < -0.1)
        {
            PlayerRigidbody.velocity = new Vector2(PlayerRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * PlayerSpeed);
            PlayerMoving = true;
            PlayerLastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            PlayerRigidbody.velocity = new Vector2(0f, PlayerRigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            PlayerRigidbody.velocity = new Vector2(PlayerRigidbody.velocity.x, 0f);
        }

        PlayerAnimator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        PlayerAnimator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        PlayerAnimator.SetBool("PlayerMoving", PlayerMoving);
        PlayerAnimator.SetFloat("LastMoveX", PlayerLastMove.x);
        PlayerAnimator.SetFloat("LastMoveY", PlayerLastMove.y);

        //action check
        if (Input.GetKey(KeyCode.Z))
        {
            PlayerActing = true;
        }
            //PlayerAnimator.SetBool("IsActing", PlayerActing);
        }
        catch(Exception ex)
        {

        }

    }

    public bool DoesPlayerHaveItem(Item item)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
                return true;
        }

        return false;
    }

    public void Say(string [] Text)
    {
        if (!manager.DialogueActive && !manager.InfoActive)
        {
            manager.CurrentLine = 0;
            manager.TextLines = Text;
            manager.SetupPrintInfo();
        }
    }

    public void MoveChar()
    {

    }

    public void MovePlayer(Vector2 Position, Vector2 Direction)
    {

    }

    public void Teleport(Vector2 Position, Vector2 Direction)
    {
        Actor.transform.position = Position;
        PlayerLastMove = Direction;
    }

    public void TeleportChar(GameObject obj, Vector2 Position)
    {
        obj.transform.position = Position;
    }

    public bool CheckForInventorySpace()
    {
        for (int i = 0; i < 10; i++)
        {
            if (inventory[i].type == ItemType.EMPTY)
                return true;
        }
        return false;
    }

    public int FindEmptyInventorySlot()
    {
        if (CheckForInventorySpace())
        {
            for (int i = 0; i < 10; i++)
            {
                if (inventory[i].type == ItemType.EMPTY)
                    return i;
            }
        }
        return -1;
    }
}