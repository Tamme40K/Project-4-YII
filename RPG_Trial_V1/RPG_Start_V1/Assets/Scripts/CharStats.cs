using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{

    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseEXP = 1000;


    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int[] mpLvlBonus;

    public int strength;
    public int defence;

    public int wpnPwr;
    public int armrPwr;

    public string equippedWpn;
    public string equippedArmr;

    public Sprite charIamge;



    // Start is called before the first frame update
    void Start()
    {
        //Sets the maxmum amount of levels, and sets the amount of exp needed per level
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        //Auto-level up by pressing k repeatedly (500 exp is added)
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddExp(500);
        }
    }


    public void AddExp(int expToAdd)
    {
        //command to add the 500 exp
        currentEXP += expToAdd;

        if (playerLevel < maxLevel)
        {

            if (currentEXP > expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];

                playerLevel++;

                //determine whether to add str or defbased on odd or even 
                if (playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defence++;
                }
                //adding a bit of HP to the base after each lvl up
                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;

                maxMP = maxMP + mpLvlBonus[playerLevel];
                currentMP = maxMP;
            }
        }
        if(playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }
}
