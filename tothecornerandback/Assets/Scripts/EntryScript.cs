using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EntryScript : MonoBehaviour
{

    void Start()
    {
        DontDestroyOnLoad(this);
        
        StartCoroutine(DoEntry());
    }

    public IEnumerator DoEntry()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
}
