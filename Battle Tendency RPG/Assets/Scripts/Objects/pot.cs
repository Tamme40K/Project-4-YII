using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : getScore
{
    private Animator anim;
    public int score_worth;
    public LootTable thisLoot;

    // Start is called before the first frame update
    void Start()
    {
	    anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    public void Smash()
    {
	    anim.SetBool("smash", true);
	    StartCoroutine(breakCo());
    }

    // een method die kijkt of er loot is. zo ja dan instantiate je de loot object op de locatie van de pot die dood is gemaakt
    private void MakeLoot()
    {
        if (thisLoot != null)
        {
            powerUp current = thisLoot.Lootpowerup();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    IEnumerator breakCo()
    {
	    yield return new WaitForSeconds(.3f);
        MakeLoot();
	    this.gameObject.SetActive(false);
	    UpdatePoints(score_worth);
	    ReadPoints();
    }
}
