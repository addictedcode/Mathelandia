using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public int minimumOrder = 5;
    public int maximumOrder = 100;

    public float customerSpawnInterval = 5.0f;
    private float timeSinceLastSpawn = 0.0f;
    public int maxCustomers = 5;

    private List<Customer> currentCustomers = new List<Customer>();

    public GameObject lineStart;
    public GameObject lineEnd;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= customerSpawnInterval && currentCustomers.Count < maxCustomers)
        {
            GameObject gameObject = Instantiate(prefabs[Random.Range(0,prefabs.Length)]);
            Customer customer = gameObject.GetComponent<Customer>();

            int order = Random.Range(minimumOrder, maximumOrder);
            customer.setOrder(order);

            customer.spawner = this;
            customer.transform.position = lineEnd.transform.position + new Vector3(0, -10, 0);
            customer.setDestination(Vector3.Lerp(lineStart.transform.position, lineEnd.transform.position, (float)currentCustomers.Count / (maxCustomers - 1)));
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
        for (int i = 0; i < currentCustomers.Count; i++)
        {
            currentCustomers[i].setDestination(Vector3.Lerp(lineStart.transform.position, lineEnd.transform.position, (float)i / (maxCustomers - 1)));
        }
    }

    public bool isCustomerPresent()
    {
        return currentCustomers.Count > 0;
    }
}
