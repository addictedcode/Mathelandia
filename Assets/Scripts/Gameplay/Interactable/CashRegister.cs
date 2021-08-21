using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashRegister : MonoBehaviour
{
    public CustomerSpawner customerSpawner;
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
