using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMenu_MainMenu : MonoBehaviour
{
    public void GoToMainMenu()
    {
        FindObjectOfType<DevConsole>().ExecuteCommand("mainmenu");
    }
}
