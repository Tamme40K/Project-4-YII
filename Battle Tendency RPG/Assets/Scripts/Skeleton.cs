using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{   
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {   
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    { 
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius         //als de monster de speler ziet
        && Vector3.Distance(target.position, transform.position) > attackRadius)        //maar hem nog niet aan kan vallen
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger )   //en is niet gestaggerd
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);          //animator
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("PlayerIsNear", true);             //loop naar speler
                anim.SetBool("PlayerIsInAttackingRange",false);                        // Experimenteel 6-7-2019
                anim.SetBool("PlayerIsToTheRight",false);                               //
                anim.SetBool("PlayerIsToTheLeft",false);                                //
            }
            else if (currentState == EnemyState.attack && Vector3.Distance(target.position, transform.position) > attackRadius)
            { 
            ChangeState(EnemyState.walk);
            }
        }
        else if (Vector3.Distance(target.position,transform.position) > chaseRadius) // monster ziet de speler niet meer
        {
            anim.SetBool("PlayerIsNear",false);
            anim.SetBool("PlayerIsInAttackingRange",false);                           // Experimenteel 6-7-2019
        }
        else                                                                          // monster is in attacking range      EXPERIMENTEEL  6-7-2019
        { 
            ChangeState(EnemyState.attack);
            anim.SetBool("PlayerIsInAttackingRange",true);                            // EXPERIMENTEEL  6-7-2019
            if (target.position.x >= transform.position.x)                             //
            {                                                                         //
                //yield return new WaitForSeconds(.75f);
                //StartCoroutine(waitseconds());
                anim.SetBool("PlayerIsToTheRight",true);                              //
                //StopMovement(1);
            }                                                                         //
            else                                                                      //
            {                                                                         //
                //yield return new WaitForSeconds(.75f);
                //StartCoroutine(waitseconds());
                anim.SetBool("PlayerIsToTheLeft",true);                               //
                //StopMovement(1);
            }                                                                           //
        }                                                                              //

    }
    private void SetAnimFloat(Vector2 setVector)    //geeft beweging door aan de animator
    {
        anim.SetFloat("MoveX", setVector.x);        
        anim.SetFloat("MoveY", setVector.y);
    }


    private void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)            // mob gaat naar rechts
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)        // mob gaat naar links
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)             // mob gaat naar boven
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)       //  // mob gaat naar beneden
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    public void StopMovement(int active) {
         
         if (active == 1)
             transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
         if (active == 0)
             transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
             }


    
    private void ChangeState(EnemyState newState)
    { 
    if(currentState != newState)
    { 
        currentState = newState;
    }
    }
}
