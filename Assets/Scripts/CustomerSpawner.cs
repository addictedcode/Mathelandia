using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public int minimumOrder = 5;
    public int maximumOrder = 100;

    public float customerSpawnInterval = 5.0f;
    private float timeSinceLastSpawn = 0.0f;

    public ConveyorBelt belt;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= customerSpawnInterval)
        {
            CustomerOrder customer = new CustomerOrder();
            int order = Random.Range(minimumOrder, maximumOrder);
            customer.setOrder(order);
            belt.addCustomer(customer);
            timeSinceLastSpawn -= customerSpawnInterval;
        }
    }
}
