using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Text Tuto;
    public Text timer;
    bool doFirst = true;
    bool doSecond = false;
    public bool doTimer = true;
    public bool showTimer = false;
    public float timerCnt = 0;

    private void Start()
    {
        Tuto.text = "Press A/D to Rotate";
    }
    void Update()
    {
        if(doTimer)
            timerCnt += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || timerCnt > 3)
        {
            if(doFirst)
            {
                doFirst = false;
                doSecond = true;
                Tuto.text = "Press W/S to Speed Up/Down";
            }
        }
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || timerCnt > 6)
        {
            if(doSecond)
            {
                doSecond = false;
                showTimer = true;
                Tuto.text = "You must reach to goal in limited Time";
            }
        }
        if (showTimer)
        {
            timer.text = "25 / " + timerCnt.ToString();
        }
    }
}
