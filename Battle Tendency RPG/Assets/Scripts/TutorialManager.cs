using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps; //key instructies
    private int popUpIndex;
    public Transform target;
    public IntValue tutorialnumber;

    void Update()
    {
        target = GameObject.FindWithTag("Player").transform; //locatie van player(target)

        if (tutorialnumber.initialValue <= 2) //verander dit als je meer pop up berichten wilt maken
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
                if /*(Input.GetMouseButtonDown(0))*/ (target.position != new Vector3(-6.6f, 1.0f, 0.0f))
                {
                    popUpIndex++;
                    tutorialnumber.initialValue++;
                }
            }
            else if (popUpIndex == 1)
            {
                if (CrossPlatformInputManager.GetButtonDown("attack"))
                {
                    popUpIndex++;
                    popUps[1].SetActive(false);
                    tutorialnumber.initialValue = 999; //hele hoge aantal anders bleef hij vast in loop elke keer als je in huis gaat
                }
            }
        }
    }
}


