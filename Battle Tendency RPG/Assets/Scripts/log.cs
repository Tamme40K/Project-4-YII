using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target; //target selecteren (locatie ervan)
    public float chaseRadius; 
    public float attackRadius;
    public Transform homePosition; //home als uit target range dan zou hij terug moeten naar home

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform; //locatie van player(target)
    }
    
    void FixedUpdate()
    {
        CheckDistance();
    }

    //vind afstand van log en target
    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius) //als player en log positie kleiner is dan chaseradius
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger) //zorg ervoor dat hij niet in stagger animation is voor hij weer beweegt
            {

                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); //log loopt dan naar target positie (wie ben ik, waar moet ik naartoe, hoe snel)

                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }
        }
    }

    //check de State van enemy als er verandering is dan verander je het naar de nieuwe state
    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
