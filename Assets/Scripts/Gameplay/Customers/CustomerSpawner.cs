using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int minimumOrder = 5;
    public int maximumOrder = 100;

    public float customerSpawnInterval = 5.0f;
    private float timeSinceLastSpawn = 0.0f;

    private List<Customer> currentCustomers = new List<Customer>();

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= customerSpawnInterval)
        {
            GameObject gameObject = Instantiate(prefab);
            Customer customer = gameObject.GetComponent<Customer>();
            int order = Random.Range(minimumOrder, maximumOrder);
            customer.setOrder(order);
            customer.spawner = this;
            currentCustomers.Add(customer);
            timeSinceLastSpawn -= customerSpawnInterval;
        }
    }

    public int getFirstCustomerOrder()
    {
        return currentCustomers[0].getOrder();
    }
    
    public Customer getFirstCustomer()
    {
        return currentCustomers[0];
    }

    public void clearCustomer(Customer customer)
    {
        currentCustomers.Remove(customer);
    }

    public bool isCustomerPresent()
    {
        return currentCustomers.Count > 0;
    }
}
