using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    // Vul in de scene in welke magie vereist is: Fire/Holy
    public string MagicRequired;

    private bool MagicEffective = false;
    private string MagicUsed = "";

    void OnTriggerEnter2D(Collider2D CollisionCheck)
    {
        bool collissionCheck(string hitbox)
        {
            if (CollisionCheck.gameObject.name == hitbox)
            {
                return true;
            } else
            {
                return false;
            }
        }

        if (collissionCheck("magic_up") || collissionCheck("magic_left") || collissionCheck("magic_right") || collissionCheck("magic_down") || collissionCheck("magic_up1") || collissionCheck("magic_left2") || collissionCheck("magic_right3") || collissionCheck("magic_down4"))
        {
            MagicUsed = CollisionCheck.gameObject.GetComponent<SpriteRenderer>().sprite.name;
            if (MagicUsed == "objects_38")
            {
                MagicUsed = "Holy";
            } else if (MagicUsed == "objects_50") {
                MagicUsed = "Fire";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Controlleer of je het juiste item gebruikt voor het obstakel.
        if (MagicRequired == MagicUsed)
        {
            MagicEffective = true;
        }

        // Zet het obstakel 'uit' wanneer het juiste item wordt gebruikt om het weg te halen.
        if (MagicEffective)
        {
            this.gameObject.SetActive(false);
        }
    }
}
