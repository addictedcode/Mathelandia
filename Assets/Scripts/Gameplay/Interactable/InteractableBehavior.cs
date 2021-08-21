using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pickUpItem;
    

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerController pc = other.gameObject.GetComponent<playerController>();
            pc.isInsideInteractField = true;
            pc.interactable = this;
            Debug.Log(1);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerController pc = other.gameObject.GetComponent<playerController>();
            pc.isInsideInteractField = false;
            pc.interactable = null;
        }
    }
}
