using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safespace : MonoBehaviour
{
    private OverworldSystem overSys;
    // Start is called before the first frame update
    void Start()
    {
        overSys = FindObjectOfType<OverworldSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //да простят меня боги за это
        if (overSys == null)
            overSys = FindObjectOfType<OverworldSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "John(Clone)")
        {
            overSys.RandEncEnabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "John(Clone)")
        {
            overSys.RandEncEnabled = true;
        }
    }
}
