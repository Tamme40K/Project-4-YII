using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;
    public IntValue tutorialnumber;

    void Awake()
    {
        if (fadeInPanel != null) // als het een fadein heeft
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;//wat en waar
            Destroy(panel, 1); //destory na 1 seconde
        }
    }

    //als object word getriggerd door een object met de tag player dan load je een nieuwe scene !other.isTrigger is om dubbele trigger te voorkomen (zie room transition bugfix)
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            StartCoroutine(FadeCo());
            tutorialnumber.initialValue = 999; //zodat je niet meer in de loop komt van de tutorial
            //SceneManager.LoadScene(sceneToLoad);
        }
    }

    public IEnumerator FadeCo()
    {
        if (fadeOutPanel != null)
        {  
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
