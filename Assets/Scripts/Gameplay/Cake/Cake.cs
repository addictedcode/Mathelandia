using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public enum operations
    {
        Addition = 0,
        Subtraction = 1
    }

    public int number;
    private List<int> components;
    private List<operations> operationList;

    public void setNumber(int num)
    {
        number = num;
    }

    public void addComponent(int component)
    {
        components.Add(component);
    }

    public void addOperation(operations op)
    {
        operationList.Add(op);
    }

    public int getNumber()
    {
        return number;
    }
}
