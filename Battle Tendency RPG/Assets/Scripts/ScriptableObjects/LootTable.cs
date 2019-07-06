using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    public powerUp thisLoot; ///wat moet droppen
    public int lootChange; //hoeveel procent kans dat hij dropt?
}

[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    public Loot[] loots;

    public powerUp Lootpowerup()
    {
        //50% kans op hart als je huidige current prob < is dan 50% dan drop je als hoger is dan ga je naar volgende item en doe je het weer
        int cumulativeProb = 0;
        int currentProb = Random.Range(0, 100);
        for (int i = 0; i < loots.Length; i++)
        {
            cumulativeProb += loots[i].lootChange;
            if (currentProb <= cumulativeProb)
            {
                return loots[i].thisLoot;
            }
        }
        return null;
    }
}
