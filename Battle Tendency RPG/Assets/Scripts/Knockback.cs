using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    //check of de gameobject waar ik tegen aan kom een enemy of player tag heeft in Unity
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null) //als er iets is om te hitten
            {
                Vector2 difference = hit.transform.position - transform.position; //vind de afstandverschil
                difference = difference.normalized * thrust; // je pakt de afstandverschil * thrust die je aangeeft
                hit.AddForce(difference, ForceMode2D.Impulse);

                if (other.gameObject.CompareTag("enemy")) //als enemy is zet je state in stagger en start je de knockback
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime);
                }

                if (other.gameObject.CompareTag("Player")) //als player is dan zet je player in stagger state en start je knockback
                {
                    hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    other.GetComponent<PlayerMovement>().Knock(knockTime); 
                }
            }
        }
    }
}
