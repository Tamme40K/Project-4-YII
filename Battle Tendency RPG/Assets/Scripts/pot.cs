using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : getScore
{
				private Animator anim;
				public int score_worth;
				

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

				IEnumerator breakCo()
				{
							yield return new WaitForSeconds(.3f);
							this.gameObject.SetActive(false);
							UpdatePoints(score_worth);
							ReadPoints();
	}
}
