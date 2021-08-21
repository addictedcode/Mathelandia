using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    private int order;
    
    public void setOrder(int num)
    {
        order = num;
        Debug.Log(num);
    }

    public int getOrder()
    {
        return order;
    }
}
