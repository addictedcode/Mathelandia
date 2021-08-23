using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashRegister : MonoBehaviour
{
    public CustomerSpawner customerSpawner;
    public GameObject SpeechBubble;

    private void Update()
    {
        if (customerSpawner.isCustomerPresent() && customerSpawner.getFirstCustomer().animator.GetFloat("speed") == 0)
        {
            SpeechBubble.SetActive(true);

            SpeechBubble.GetComponentInChildren<Text>().text = customerSpawner.getFirstCustomerOrder().ToString();
        }
        else
        {
            SpeechBubble.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (customerSpawner.isCustomerPresent())
            {
                other.gameObject.GetComponent<playerController>().isCustomer = true;
                other.gameObject.GetComponent<playerController>().customerRef = customerSpawner.getFirstCustomer();
                other.gameObject.GetComponent<playerController>().isInsideInteractField = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerController>().isCustomer = false;
            other.gameObject.GetComponent<playerController>().customerRef = null;
            other.gameObject.GetComponent<playerController>().isInsideInteractField = false;
        }
    }
}
