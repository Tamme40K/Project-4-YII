using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSaveTest : MonoBehaviour
{
    public int level = 3;
    public int health = 40;


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        Debug.Log("Saving player location..");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
    }
    
    void Start()
    {
        InvokeRepeating("SavePlayer", 0, 120); 
    }

    //private IEnumerator SavePlayerCo()
    //{
    //    SavePlayer();
    //    Debug.Log("First saving");
    //    yield return new WaitForSeconds(10);
    //    Debug.Log("Waited for 10 seconds");
    //    SavePlayer();
    //    Debug.Log("Second saving");
    //}
}
