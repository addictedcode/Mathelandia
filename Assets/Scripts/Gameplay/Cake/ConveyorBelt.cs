using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public int digitsToSpawn = 1;

    public float numberSpawnInterval = 2.0f;
    private float timeSinceLastNumber = 0.0f;

    private int maximumSpawnedNumbers = 8;
    private List<int> spawnedNumbers = new List<int>();

    private List<CustomerOrder> customerOrders = new List<CustomerOrder>();

    // Update is called once per frame
    void Update()
    {
        timeSinceLastNumber += Time.deltaTime;

        if (spawnedNumbers.Count < maximumSpawnedNumbers)
        {
            if (timeSinceLastNumber >= numberSpawnInterval)
            {
                generateNumber();
                timeSinceLastNumber -= numberSpawnInterval;
                for (int i = 0; i < spawnedNumbers.Count; i++)
                {
                    Debug.Log("Number " + i + ": " + spawnedNumbers[i]);
                }
            }
        }
    }

    private bool hasSolveableCustomer()
    {
        for (int i = 0; i < spawnedNumbers.Count - 1; i++)
        {
            for (int j = i + 1; j < spawnedNumbers.Count; j++)
            {
                for (int k = 0; k < customerOrders.Count; k++)
                {
                    if (spawnedNumbers[i] + spawnedNumbers[j] == customerOrders[k].getOrder())
                        return true;
                    else if (spawnedNumbers[i] - spawnedNumbers[j] == customerOrders[k].getOrder())
                        return true;
                    else if (spawnedNumbers[j] - spawnedNumbers[i] == customerOrders[k].getOrder())
                        return true;
                }
            }
        }
        return false;
    }

    private void generateNumber()
    {
        while (spawnedNumbers.Count < 3)
        {
            int sign = Random.Range(0, 2);
            if (sign == 0)//plus
            {
                int newNumber;
                if (digitsToSpawn == 1)
                {
                    newNumber = Random.Range(1, 10);
                }
                else
                    newNumber = Random.Range((int)Mathf.Pow(10, digitsToSpawn - 1), (int)Mathf.Pow(10, digitsToSpawn));
                spawnedNumbers.Add(newNumber);
            }
            else
            {
                int newNumber;
                if (digitsToSpawn == 1)
                {
                    newNumber = -Random.Range(1, 10);
                }
                else
                    newNumber = -Random.Range((int)Mathf.Pow(10, digitsToSpawn - 1), (int)Mathf.Pow(10, digitsToSpawn));
                spawnedNumbers.Add(newNumber);
            }
        }

        if (hasSolveableCustomer())
        {
            int sign = Random.Range(0, 2);
            if (sign == 0)//plus
            {
                int newNumber;
                if (digitsToSpawn == 1)
                {
                    newNumber = Random.Range(1, 10);
                }
                else
                    newNumber = Random.Range((int)Mathf.Pow(10, digitsToSpawn - 1), (int)Mathf.Pow(10, digitsToSpawn));
                spawnedNumbers.Add(newNumber);
            }
            else
            {
                int newNumber;
                if (digitsToSpawn == 1)
                {
                    newNumber = -Random.Range(1, 10);
                }
                else
                    newNumber = -Random.Range((int)Mathf.Pow(10, digitsToSpawn - 1), (int)Mathf.Pow(10, digitsToSpawn));
                spawnedNumbers.Add(newNumber);
            }
        }
        else
        {
            int answer = getAnswerToRandomCustomer();
            if (answer != 0)
                spawnedNumbers.Add(answer);
            else
            {
                int sign = Random.Range(0, 2);
                if (sign == 0)//plus
                {
                    int newNumber;
                    if (digitsToSpawn == 1)
                    {
                        newNumber = Random.Range(1, 10);
                    }
                    else
                        newNumber = Random.Range((int)Mathf.Pow(10, digitsToSpawn - 1), (int)Mathf.Pow(10, digitsToSpawn));
                    spawnedNumbers.Add(newNumber);
                }
                else
                {
                    int newNumber;
                    if (digitsToSpawn == 1)
                    {
                        newNumber = -Random.Range(1, 10);
                    }
                    else
                        newNumber = -Random.Range((int)Mathf.Pow(10, digitsToSpawn - 1), (int)Mathf.Pow(10, digitsToSpawn));
                    spawnedNumbers.Add(newNumber);
                }
            }
        }
    }

    private int getAnswerToRandomCustomer()
    {
        int answer = 0;

        for (int i = 0; i < customerOrders.Count; i++)
        {
            int chosenOrder = customerOrders[i].getOrder();
            int chosenNumber = spawnedNumbers[Random.Range(0, spawnedNumbers.Count)];

            int sign = Random.Range(0, 2);
            if (sign == 0)//plus
            {
                if (chosenNumber < chosenOrder)
                {
                    int trialAnswer = chosenOrder - chosenNumber;
                    if (digitsToSpawn == 1)
                    {
                        if (trialAnswer < 10 && trialAnswer >= 1)
                        {
                            answer = trialAnswer;
                            break;
                        }
                    }
                    else
                    {
                        if (trialAnswer < Mathf.Pow(10, digitsToSpawn) && trialAnswer >= Mathf.Pow(10, digitsToSpawn - 1))
                        {
                            answer = trialAnswer;
                            break;
                        }
                    }
                }
                else
                {
                    int trialAnswer = chosenOrder - chosenNumber;
                    if (digitsToSpawn == 1)
                    {
                        if (trialAnswer > -10 && trialAnswer <= -1)
                        {
                            answer = trialAnswer;
                            break;
                        }
                    }
                    else
                    {
                        if (trialAnswer > -Mathf.Pow(10, digitsToSpawn) && trialAnswer <= -Mathf.Pow(10, digitsToSpawn - 1))
                        {
                            answer = trialAnswer;
                            break;
                        }
                    }
                }
                sign = 1;
            }
            if (sign == 1)
            {
                int trialAnswer = chosenOrder + chosenNumber;
                if (digitsToSpawn == 1)
                {
                    if (trialAnswer < 10 && trialAnswer >= 1)
                    {
                        answer = trialAnswer;
                        break;
                    }
                    else if (trialAnswer > -10 && trialAnswer <= -1)
                    {
                        answer = trialAnswer;
                        break;
                    }
                }
                else
                {
                    if (trialAnswer < Mathf.Pow(10, digitsToSpawn) && trialAnswer >= Mathf.Pow(10, digitsToSpawn - 1))
                    {
                        answer = trialAnswer;
                        break;
                    }
                    else if (trialAnswer > -Mathf.Pow(10, digitsToSpawn) && trialAnswer <= -Mathf.Pow(10, digitsToSpawn - 1))
                    {
                        answer = trialAnswer;
                        break;
                    }
                }
                trialAnswer = chosenNumber - chosenOrder;
                if (digitsToSpawn == 1)
                {
                    if (trialAnswer < 10 && trialAnswer >= 1)
                    {
                        answer = trialAnswer;
                        break;
                    }
                    else if (trialAnswer > -10 && trialAnswer <= -1)
                    {
                        answer = trialAnswer;
                        break;
                    }
                }
                else
                {
                    if (trialAnswer < Mathf.Pow(10, digitsToSpawn) && trialAnswer >= Mathf.Pow(10, digitsToSpawn - 1))
                    {
                        answer = trialAnswer;
                        break;
                    }
                    else if (trialAnswer > -Mathf.Pow(10, digitsToSpawn) && trialAnswer <= -Mathf.Pow(10, digitsToSpawn - 1))
                    {
                        answer = trialAnswer;
                        break;
                    }
                }
            }
        }

        return answer;
    }

    public void addCustomer(CustomerOrder order)
    {
        customerOrders.Add(order);
    }
}
