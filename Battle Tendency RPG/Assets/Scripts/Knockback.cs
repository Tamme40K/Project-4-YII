using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage; //hiermee geef je damage aan dingen die knockback geven (aka zwaard) hier kunnen we mee spelen met exp/level/upgrades enz

    //check of de gameobject waar ik tegen aan kom een enemy of player tag heeft in Unity
    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.gameObject.CompareTag("breakable"))
	    {
		    other.GetComponent<pot>().Smash();
	    }
	    if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null) //als er iets is om te hitten
            {
                Vector2 difference = hit.transform.position - transform.position; //vind de afstandverschil
                difference = difference.normalized * thrust; // je pakt de afstandverschil * thrust die je aangeeft
                hit.AddForce(difference, ForceMode2D.Impulse);

                if (other.gameObject.CompareTag("enemy") && other.isTrigger)
                //als enemy is zet je state in stagger en start je de knockback, 
                //&& is trigger omdat player/enemy twee colliders is waarvan eentje een trigger is. als je dit niet doet, doet hij 2x zoveel damage doordat hij 2x collider raakt
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }

                if (other.gameObject.CompareTag("Player")) //als player is dan zet je player in stagger state en start je knockback
                {
                    if (other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                    }

                }
            }
        }
    }
}
