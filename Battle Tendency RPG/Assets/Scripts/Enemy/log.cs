using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : Enemy
{
    public Rigidbody2D myRigidbody;
    public Transform target; //target selecteren (locatie ervan)
    public float chaseRadius; 
    public float attackRadius;
    public Transform homePosition; //home als uit target range dan zou hij terug moeten naar home
    public Animator anim; //animator in Unity

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform; //locatie van player(target)
        anim.SetBool("wakeUp", true);
    }
    
    void FixedUpdate()
    {
        CheckDistance();
    }

    //vind afstand van log en target
    public virtual void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius) //als player en log positie kleiner is dan chaseradius
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger) //zorg ervoor dat hij niet in stagger animation is voor hij weer beweegt
            {

                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); //log loopt dan naar target positie (wie ben ik, waar moet ik naartoe, hoe snel)

                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true ); // Maak wakker als in range is
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius) //laat slapen als de afstand tussen log en player groter is dan de range waarin de log je volgt
        {
            anim.SetBool("wakeUp", false); //laat slapen if nog in range
        }
    }

    
    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    public void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            //hier kom je in als je naar links of rechts beweegt als log dan moet je nog kijken welke kant je precies op gaat links of rechts
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right); //als x positief word ga je naar rechts
            }else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            //hier kom je in als je naar boven of benden gaat  maar dan moet je nog kijken of het positief of negatief is. of je dus naar boven of naar beneden gaat.
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
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
