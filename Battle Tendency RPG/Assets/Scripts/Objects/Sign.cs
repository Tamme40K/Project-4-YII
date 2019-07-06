using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox; //pakt de dialogbox in unity
    public Text dialogText; //gebruikt de text object die is aangemaakt in dialogbox
    public string dialog;
    public bool playerInRange;
    public Message context;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("interact") && playerInRange)
        {
            if (dialogBox.activeInHierarchy) //is de dialogbox al active?
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
