using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle, 
    walk,
    attack,
    stagger
}


public class Enemy : MonoBehaviour
{
    //wat heeft elke enemy minimaal
    public EnemyState currentState;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    public void Knock(Rigidbody2D myRigidbody, float knockTime)
    {
        health = health - 1;
        if (health <= 0)
        {
            Debug.Log("enemy is dood");
        }
        else
        {
           StartCoroutine(KnockCo(myRigidbody, knockTime));
        }

    }

    //Timer maken zodat de knockback stopt en niet voor altijd blijft sliden
    private IEnumerator KnockCo(Rigidbody2D myRigidBody, float knockTime)
    {
        if (myRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidBody.velocity = Vector2.zero;

            //dit hieronder werkt niet want hij krijgt dan -1 hp als hij word geraakt in het algemeen niet alleen door het zwaard. 
            //health = health - 1;
            //if (health <= 0)
            //{
            //    Debug.Log("enemy dood");
            //}
            //dit word gestart als je word geraakt door een player je zou je hp kunnen verminderen en als je dood gaat als enemy SetActive(false) doen anders blijft er misschien
            //een ontzichtbare enemy collision op de map 
            //wss dit en dan een if statement om te checken of het 0 word > en die activeerd dan een death animatie + SetActive(false)
            //eventueel nog punten erbij
        }
    }
}
