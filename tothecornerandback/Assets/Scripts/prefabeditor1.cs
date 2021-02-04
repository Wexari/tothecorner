using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabeditor1 : MonoBehaviour
{
    public GameObject targetPrefab;
    // Start is called before the first frame update
    void Start()
    {
        targetPrefab.GetComponent<prefabtest1>().chocolate = "white";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
