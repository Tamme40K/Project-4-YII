using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ItemManager : MonoBehaviour
{
    public bool fireItem;
    public bool holyItem;

    private string playerRotation = "";

    void Start()
    {
        //TO DO: Fetch item booleans from the database
        // fireItem = database.fetch(fireItem);
    }

    // Controlleer wanneer de speler een item aanraakt; wanneer ja, dan 'bezit' de speler nu dit item.
    void OnTriggerEnter2D(Collider2D CollisionCheck)
    {
        if (CollisionCheck.gameObject.name == "FireItem")
        {
            fireItem = true;
        }
        if (CollisionCheck.gameObject.name == "HolyItem")
        {
            holyItem = true;
        }
    }

    void enableHitbox(int hitbox1, int hitbox2, int hitbox3, int hitbox4, bool Enabled) {
        // Check for the player's orientation. For each collection of four sprites facing one direction, assign a different item hitbox. 
        if (playerRotation == "character_24" || playerRotation == "character_25" || playerRotation == "character_26" || playerRotation == "character_27")
        {
            // Activate the up hitbox.
            this.gameObject.transform.GetChild(hitbox1).gameObject.SetActive(Enabled);
        }
        if (playerRotation == "character_35" || playerRotation == "character_36" || playerRotation == "character_37" || playerRotation == "character_38")
        {
            // Activate the left hitbox.
            this.gameObject.transform.GetChild(hitbox2).gameObject.SetActive(Enabled);
        }
        if (playerRotation == "character_13" || playerRotation == "character_14" || playerRotation == "character_15" || playerRotation == "character_16")
        {
            // Activate the right hitbox.
            this.gameObject.transform.GetChild(hitbox3).gameObject.SetActive(Enabled);
        }
        if (playerRotation == "character_0" || playerRotation == "character_1" || playerRotation == "character_2" || playerRotation == "character_3")
        {
            // Activate the down hitbox.
            this.gameObject.transform.GetChild(hitbox4).gameObject.SetActive(Enabled);
        }
    }

    // Update is called once per frame
    // TO DO: verander de sprites van de hitboxes wanneer de button wordt geraakt
    void Update()
    {
        // Turn the hitbox off first thing in the update, to prevent it from staying on.
        enableHitbox(5, 6, 7, 8, false);
        enableHitbox(9, 10, 11, 12, false);

        // Commit the player's rotation to a string for use in enableHitbox()
        playerRotation = this.gameObject.GetComponent<SpriteRenderer>().sprite.name;

        if (CrossPlatformInputManager.GetButtonDown("firemagic") && fireItem == true)
        {
            // Check for the player's orientation. For each 90 degrees, assign a different item hitbox. Activate the hitbox.
            enableHitbox(9, 10, 11, 12, true);
        }
        if (CrossPlatformInputManager.GetButtonDown("holymagic") && holyItem == true)
        {
            // Check for the player's orientation. For each 90 degrees, assign a different item hitbox. Activate the hitbox.
            enableHitbox(5, 6, 7, 8, true);
        }
    }
}
