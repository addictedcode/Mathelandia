using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private int order;
    public CustomerSpawner spawner;
    
    public void setOrder(int num)
    {
        order = num;
        Debug.Log(num);
    }

    public int getOrder()
    {
        return order;
    }

    public bool finishOrder(int cakeNum)
    {
        if (cakeNum == order)
        {
            spawner.clearCustomer(this);
            Destroy(this);
            return true;
        }
        else
            return false;
    }
}
