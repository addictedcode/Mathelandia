using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cakeInteractablePrefab;

    [SerializeField]
    private ConveyorBelt conveyorBelt;
    [SerializeField]
    private NumberCandles numberCandleSpawner;
    [SerializeField]
    private Transform spawnPoint;

    public float numberSpawnInterval = 2.0f;
    private float timeSinceLastNumber = 0.0f;

    public int maxSpawn = 4;
    public int currentSpawned = 0;

    public List<int> spawnedCakes = new List<int>();

    

    // Update is called once per frame
    void Update()
    {
        timeSinceLastNumber += Time.deltaTime;

        if (timeSinceLastNumber >= numberSpawnInterval)
        {
            Debug.Log(spawnedCakes.Count);
            if (currentSpawned < maxSpawn && spawnedCakes.Count > 0)
            {
                GameObject cake = Instantiate(cakeInteractablePrefab, spawnPoint.position, Quaternion.identity);
                //conveyorBelt.spawned // get number from conveyor belt here

                cake.GetComponentInChildren<CandleSpriteHandler>().updateCandleSprites(
                                                    numberCandleSpawner.generateCandleSprites(spawnedCakes[0]));
                cake.GetComponent<Rigidbody2D>().AddForce(new Vector3(-500f, 0f));
                int x = spawnedCakes[0];
                cake.GetComponent<InteractableBehavior>().pickUpItem.GetComponent<HeldObject>().cakeInteger = x;

                cake.GetComponent<Cake>().number = x;
                timeSinceLastNumber = 0;
                currentSpawned++;
                spawnedCakes.RemoveAt(0);
            }
        }
    }

    public void Spawn(int num)
    {
        spawnedCakes.Add(num);
        
    }
}
