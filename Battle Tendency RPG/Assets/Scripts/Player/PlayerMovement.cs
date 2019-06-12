using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public enum PlayerState //states die een player kunnen hebbben 
{
    walk,
    attack,
    interact, 
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed; //hoe snel loopt character
    private Rigidbody2D myRigidbody; //rigidBody van player
    private Vector3 change; //hoeveel veranderd de positie van de player
    private Animator animator; //de animator die je hebt gemaakt op de player
    public FloatValue currentHealth;
    public Message playerHealthSignal;
    public VectorValue startingPosition;
    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        myRigidbody = GetComponent<Rigidbody2D>(); //je pakt de rigidbody component uit Unity 
        animator = GetComponent<Animator>(); // je pakt de animator uit unity
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero; //elke frame reset je de change naar 0 want na de beweging is hij op ze orignele plek
        change.x = CrossPlatformInputManager.GetAxisRaw("Horizontal"); //Horizontal & Vertical is al iets in Unity die word hier gebruikt
        change.y = CrossPlatformInputManager.GetAxisRaw("Vertical");
        //hier kijk je of je moet attacken of lopen zodat je niet lopend kan attacken 
        if (CrossPlatformInputManager.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger) //attack button toegevoegt in project settings je attack als je niet aan attack bent of in knockback animation
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
    }

    //method voor attacking Coroutine
    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true); //set attacking op true voor Animator in unity zodat hij van state kan veranderen
        currentState = PlayerState.attack;
        yield return null; //wacht 1 frame
        animator.SetBool("attacking", false); //na 1 frame stop je met attacking state 
        yield return new WaitForSeconds(.3f); //animatie van een attack staat op dit moment op .33 seconden dus dan wacht je tot animatie voorbij is van één attack
        currentState = PlayerState.walk; //terug naar walk state
    } 

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero) //als er een change is DAN pas MoveCharacter method uitvoeren
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x); // je hebt in unity de parameters doorgegeven voor movement en hier geef je het values
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true); //je hebt in Animator een bool gemaakt als je gaat bewegen zet je moving op true zodat hij van state kan veranderen
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    //aparte method voor movecharacter zodat je makkelijk kan toevoegen aan andere inputs
    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime); //eigen positie + verandering + snelheid

    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise(); //je raised een signal dus andere objecten weten nu dat er iets gebeurt met playerhealth
        if (currentHealth.RuntimeValue > 0)
        {
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            DeathEffect();
            this.gameObject.SetActive(false); //dood
        }
    }

    private void DeathEffect()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    //Timer maken zodat de knockback stopt en niet voor altijd blijft sliden
    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
            //dit start je als je word geraakt door een enemy hier zou je HP kunnen verminderen en if hp <= 0 dood gaan
        }
    }
}
