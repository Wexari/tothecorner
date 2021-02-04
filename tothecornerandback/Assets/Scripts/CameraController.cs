using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 targetPosition;
    public bool isSmooth;
    public float speed;

    public float borderX1;
    public float borderX2;

    public float borderY1;
    public float borderY2;

    public GameObject Fader;
    private Animator faderAnim;

    void Start()
    {
        faderAnim = Fader.GetComponent<Animator>();
    }

    public void FadeIn()
    {
        faderAnim.Play("Fader_FadeIn");
    }

    public void FadeOut()
    {
        faderAnim.Play("Fader_FadeOut");
    }

    void Update()
    {
        if(followTarget != null)
        {
            targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
            if (isSmooth)
                transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            else if (!isSmooth)
                transform.position = new Vector3(Mathf.Clamp(targetPosition.x, borderX1, borderX2), Mathf.Clamp(targetPosition.y, borderY1, borderY2), -10);
        }
    }
}
