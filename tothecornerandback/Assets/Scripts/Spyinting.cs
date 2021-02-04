using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spyinting : MonoBehaviour
{
    public GameObject SpyTarget;
    public Animator animator;
    public float border_left;
    public float border_centera;
    public float border_centerb;
    public float border_right;

    public bool switcher;
    void Start()
    {
        StartCoroutine(Setup());
    }

    void Update()
    {
        try
        {
            if (SpyTarget.transform.position.x <= border_left)
            {
                animator.Play("portrait_left2");
            }
            else
              if (SpyTarget.transform.position.x >= border_left && SpyTarget.transform.position.x < border_centera)
            {
                animator.Play("portrait_left1");
            }
            else
              if (SpyTarget.transform.position.x >= border_centera && SpyTarget.transform.position.x <= border_centerb)
            {
                animator.Play("portrait_center");
            }
            else
              if (SpyTarget.transform.position.x <= border_right)
            {
                animator.Play("portrait_right1");
            }
            else
              if (SpyTarget.transform.position.x >= border_right)
            {
                animator.Play("portrait_right2");
            }
        }
        catch(Exception ex)
        {

        }

    }

    public IEnumerator Setup()
    {
        yield return new WaitForSeconds(5f);
        SpyTarget = GameObject.Find("John(Clone)");
        animator = GetComponent<Animator>();
        
    }
}
