using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthSaveTest : MonoBehaviour
{
    public int level = 3;
    public int health = 40;
    public string scene;
    public Scene currentScene;
    public string currentSceneName;
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
        scene = data.sceneName;

        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;

        if (currentSceneName != scene)
        {
            SceneManager.LoadScene(scene);
        }

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;

        Debug.Log(scene);
    }
    
    void Start()
    {
        //InvokeRepeating("SavePlayer", 0, 120); als dit aan is dan word gesaved GELIJK als je scene veranderd dus je load is altijd in zelfde scene
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
