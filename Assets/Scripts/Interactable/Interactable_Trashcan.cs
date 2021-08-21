using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Trashcan : MonoBehaviour
{
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
            other.gameObject.GetComponent<playerController>().isTrashCan = true; 
            other.gameObject.GetComponent<playerController>().isInsideInteractField = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerController>().isTrashCan = false;
            other.gameObject.GetComponent<playerController>().isInsideInteractField = false;
        }
    }
}
