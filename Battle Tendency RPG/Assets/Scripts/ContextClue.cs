using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject contextclue;
    public bool contextActive = false;

    public void ChangeContext()
    {
        contextActive = !contextActive;
        if (contextActive)
        {
            contextclue.SetActive(true);
        }
        else
        {
            contextclue.SetActive(false);
        }
    }
}
