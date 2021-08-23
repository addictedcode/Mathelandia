using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssemblerUI : MonoBehaviour
{
    public GameObject textHolder;
    public Text equation;

    public void Activate()
    {
        textHolder.SetActive(true);
    }

    public void Deactivate()
    {
        textHolder.SetActive(false);
    }

    public void UpdateEquation(List<int> integers, List<GameObject> operations)
    {
        equation.text = "";
        if (integers.Count > 0)
            equation.text += integers[0];
        else
            equation.text += "_";
        for (int i = 1; i < 3; i++)
        {
            if (i < integers.Count || i - 1 < operations.Count)
            {
                if (operations.Count > i - 1)
                {
                    if (operations[i - 1].GetComponent<HeldObject>().isPositiveFrosting)
                        equation.text += " + ";
                    else
                        equation.text += " - ";
                }
                else
                    equation.text += " _ ";

                if (integers.Count > i)
                    equation.text += integers[i];
                else
                    equation.text += "_";
            }
        }
    }
}
