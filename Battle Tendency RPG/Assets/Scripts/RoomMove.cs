using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange; //hoeveel moet camera veranderen bij trigger
    public Vector3 playerChange; //hoeveel moet player veranderen bij trigger
    private CameraMovement cam; //cameramovement script
    public bool needText; //heeft de room waar ik in ga text nodig? true or false
    public string placeName; //welke tekst moet verschijnen
    public GameObject text; //de gameobject voor text in Unity zelf
    public Text placeText;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Je pakt de cam en gebruikt de min/max van cameramovement op de min/maxposition aan te passen (de boundaries)..
            //..als je de trigger raakt
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange; //je verplaats je player ook na de trigger anders sta je op 'oude' map

            //hebben we tekst nodig? zo ja, activate textobject en text = placeName
            if (needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }

    //logic voor als if needtext true
    private IEnumerator placeNameCo()
    {
        //gameobject text staat false(uit) in Unity, je maak het active als text nodig is
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f); //wacht 4 seconden daarna text inactive maken weer
        text.SetActive(false);
    }
}
