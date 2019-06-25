using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol_log : log
{

    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;


    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius) //als player en log positie kleiner is dan chaseradius
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger) //zorg ervoor dat hij niet in stagger animation is voor hij weer beweegt
            {

                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); //log loopt dan naar target positie (wie ben ik, waar moet ik naartoe, hoe snel)

                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                //ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true); // Maak wakker als in range is
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius) //dit laat bij gewone log de slaap animatie starten maar hier moet je verder lopen
        {
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance) //hoe ver zijn we van onze goal 
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime); //log loopt dan naar target positie (wie ben ik, waar moet ik naartoe, hoe snel)

                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
            }
            else
            {
                ChangeGoal();
            }
        }
    }

    public void ChangeGoal() //check wat huidige goal is
    {
        if (currentPoint == path.Length - 1) //einde van de path dan reset je alles
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else //anders ga je naar de volgende path
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }



}
