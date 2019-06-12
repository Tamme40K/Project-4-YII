using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public bool needText; //heeft de room waar ik in ga text nodig? true or false
    public string placeName; //welke tekst moet verschijnen
    public GameObject text; //de gameobject voor text in Unity zelf
    public Text placeText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //hebben we tekst nodig? zo ja, activate textobject en text = placeName
            if (needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }

    //logic voor als if needtext true
    private IEnumerator placeNameCo()
    {
        //gameobject text staat false(uit) in Unity, je maak het active als text nodig is
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f); //wacht 4 seconden daarna text inactive maken weer
        text.SetActive(false);
    }
}
