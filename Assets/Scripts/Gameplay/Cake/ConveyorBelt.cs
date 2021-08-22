using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public int digitsToSpawn = 1;

    public float numberSpawnInterval = 2.0f;
    private float timeSinceLastNumber = 0.0f;

    private int maximumSpawnedNumbers = 1;
    private List<int> spawnedNumbers = new List<int>();

    public CustomerSpawner customerSpawner;

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
                    //Debug.Log("Number " + i + ": " + spawnedNumbers[i]);
                }
            }
        }
    }

    private bool hasSolveableCustomer()
    {
        if (customerSpawner.isCustomerPresent())
        {
            for (int i = 0; i < spawnedNumbers.Count - 1; i++)
            {
                for (int j = i + 1; j < spawnedNumbers.Count; j++)
                {
                    if (spawnedNumbers[i] + spawnedNumbers[j] == customerSpawner.getFirstCustomerOrder())
                        return true;
                    else if (spawnedNumbers[i] - spawnedNumbers[j] == customerSpawner.getFirstCustomerOrder())
                        return true;
                    else if (spawnedNumbers[j] - spawnedNumbers[i] == customerSpawner.getFirstCustomerOrder())
                        return true;
                }
            }
        }
        
        return false;
    }

    private void generateNumber()
    {
        while (spawnedNumbers.Count < 2)
        {
            generateRandomNumber();
        }

        if (hasSolveableCustomer())
        {
            generateRandomNumber();
        }
        else
        {
            int rng = Random.Range(0, 3);//number of additional noise numbers
            int answer = getAnswerToRandomCustomer();
            if (answer != 0)
            {
                if (rng > 0)
                {
                    int position = Random.Range(0, 3); //position of answer with the new noise numbers
                    if (position == 2)
                    {
                        generateRandomNumber();
                        if (rng == 2)
                            generateRandomNumber();
                    }
                    else if (position == 1 && rng == 2)
                        generateRandomNumber();
                    spawnedNumbers.Add(answer);
                    if (position == 1)
                        generateRandomNumber();
                    else if (position == 0)
                    {
                        generateRandomNumber();
                        if (rng == 2)
                            generateRandomNumber();
                    }
                }
                else
                    spawnedNumbers.Add(answer);
            }
            else
            {
                generateRandomNumber();
            }
        }
    }

    private void generateRandomNumber()
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
    private int getAnswerToRandomCustomer()
    {
        int answer = 0;
        if (customerSpawner.isCustomerPresent())
        {
            for (int i = 0; i < spawnedNumbers.Count; i++)
            {
                int chosenOrder = customerSpawner.getFirstCustomerOrder();
                int chosenNumber = spawnedNumbers[i];

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
        }

        return answer;
    }
}
