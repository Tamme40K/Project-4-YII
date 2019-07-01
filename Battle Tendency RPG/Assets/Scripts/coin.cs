using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : getScore
{
    public int score_worth;


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
        Destroy(this.gameObject);
        UpdatePoints(score_worth);
        ReadPoints();
      }
    }
}
