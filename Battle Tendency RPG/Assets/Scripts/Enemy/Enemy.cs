using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum EnemyState
{
    idle, 
    walk,
    attack,
    stagger
}

public class Enemy : getScore
{
    //wat heeft elke enemy minimaal
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public GameObject deathEffect;
    public int score_worth;
    public LootTable thisLoot;

    private void Awake()
    {
        health = maxHealth.initialValue; //deze word gepakt van de scriptable object die gemaakt is
    }

    //enemey takedamage health = health - damage ALS health 0 word na de damage taken dan word gameobject false zodat er geen onzichtbare log is
    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && this.enemyName == "fallenHero")
        {
            DeathEffect();
            SceneManager.LoadScene("victoryScene");
            //DeathEffect();
            //MakeLoot();
            //this.gameObject.SetActive(false);
            ////AddPoints(score_worth);
            ////ReadScore();
            //UpdatePoints(score_worth);
            //ReadPoints();
        }
        else
        {
            if (health <= 0)
            {
                DeathEffect();
                MakeLoot();
                this.gameObject.SetActive(false);
                //AddPoints(score_worth);
                //ReadScore();
                UpdatePoints(score_worth);
                ReadPoints();
            }
        }
    }

    // een method die kijkt of er loot is. zo ja dan instantiate je de loot object op de locatie van de enemy die dood is gemaakt
    private void MakeLoot()
    {
        if (thisLoot != null)
        {
            powerUp current = thisLoot.Lootpowerup();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
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

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
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
        }
    }


}
