using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pickUpItem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerController pc = other.gameObject.GetComponent<playerController>();
            pc.isInsideInteractField = true;
            pc.interactable = this;
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
