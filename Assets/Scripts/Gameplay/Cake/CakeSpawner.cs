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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastNumber += Time.deltaTime;

        if (timeSinceLastNumber >= numberSpawnInterval)
        {
            if(currentSpawned < maxSpawn)
            {
                GameObject cake = Instantiate(cakeInteractablePrefab, spawnPoint.position, Quaternion.identity);
                //conveyorBelt.spawned // get number from conveyor belt here
                cake.GetComponentInChildren<CandleSpriteHandler>().updateCandleSprites(
                                                    numberCandleSpawner.generateCandleSprites(-123));
                cake.GetComponent<Rigidbody2D>().AddForce(new Vector3(-500f, 0f));
                cake.GetComponent<InteractableBehavior>().pickUpItem.GetComponent<HeldObject>().cakeInteger = -123;
                timeSinceLastNumber -= numberSpawnInterval;
                currentSpawned++;
            }
        }
    }
}
