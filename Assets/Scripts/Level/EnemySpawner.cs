using System.Linq;
using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemiesContainer;

    private Transform[] spawnPoints;

    private float spawnRate = 5.0f;
    private float nextSpawnTime;
    private int enemiesSpawned;

    private Random randomNumberGenerator;

    void Awake()
    {
        nextSpawnTime = Time.time + spawnRate;
        randomNumberGenerator = new Random();
        spawnPoints = transform
            .Cast<Transform>()
            .ToArray();
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnRate;

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        // Pick a random spawn point
        var index = randomNumberGenerator.Next(spawnPoints.Length);
        var spawnPoint = spawnPoints[index].transform;

        // Spawn an enemy and group in enemy container
        var newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, enemiesContainer);
        var movementNode = spawnPoint.GetComponent<MovementNode>().PickRandomNextNode();
        newEnemy.GetComponent<EnemyMovement>().SetMovementNode(movementNode);

        newEnemy.name = "Enemy " + ++enemiesSpawned;
    }
}
