using System.Linq;
using UnityEngine;
using Random = System.Random;

public class AmmoSpawner : MonoBehaviour
{
    private AmmoPickup[] pickups;

    private float spawnRate = 20.0f;
    private float initalSpawnDelay = 40.0f;
    private float nextSpawnTime;

    private Random randomNumberGenerator;

    void Awake()
    {
        nextSpawnTime = Time.time + initalSpawnDelay;
        randomNumberGenerator = new Random();
        pickups = GetComponentsInChildren<AmmoPickup>();
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnRate;
            var availablePickups = pickups
                .ToList()
                .Where(p => !p.isAmmoAvailable);

            if (availablePickups.Any())
            {
                var index = randomNumberGenerator.Next(availablePickups.Count());
                availablePickups.ElementAt(index).Activate();
            }
        }
    }
}
