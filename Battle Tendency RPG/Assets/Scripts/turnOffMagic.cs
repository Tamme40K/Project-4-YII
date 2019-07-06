using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class turnOffMagic : ItemManager
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            fireItem = false;
            holyItem = false;
            ChangeFireValue(false);
            ChangeHolyValue(false);
            Debug.Log(fireItem);
            Debug.Log(holyItem);
        }
    }
}