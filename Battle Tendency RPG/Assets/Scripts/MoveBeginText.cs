﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveBeginText : MonoBehaviour
{
    public GameObject[] popUps; //key instructies
    private int popUpIndex;
    public Transform target;
    public IntValue movebegintext;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; //locatie van player(target)
    }
    void Update()
    {

        if (movebegintext.initialValue <= 3) //verander dit als je meer pop up berichten wilt maken
        {
            for (int i = 0; i < popUps.Length; i++)
            {
                if (i == popUpIndex)
                {
                    popUps[i].SetActive(true);
                }
                else
                {
                    popUps[i].SetActive(false);
                }

            }

            if (popUpIndex == 0)
            {
                if /*(Input.GetMouseButtonDown(0))*/ (target.position != new Vector3(0f, -3f, 0.0f))
                {
                    movebegintext.initialValue = 999;
                    popUps[0].SetActive(false);

                }
            }
            //if (popUpIndex == 1)
            //{
            //    if (CrossPlatformInputManager.GetButtonDown("attack"))
            //    {
            //        popUpIndex++;
            //        //tutorialnumber.initialValue = 999; //hele hoge aantal anders bleef hij vast in loop elke keer als je in huis gaat
            //    }
            //}
            //else if (popUpIndex == 2)
            //{
            //    if (CrossPlatformInputManager.GetButtonDown("interact"))
            //    {
            //        popUpIndex++;
            //        popUps[2].SetActive(false);
            //        movebegintext.initialValue = 999; //hele hoge aantal anders bleef hij vast in loop elke keer als je in huis gaat
            //    }
            //}
        }
    }
}
