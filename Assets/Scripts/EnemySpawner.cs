using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemies to spawn:")]
    public GameObject enemy;
    public GameObject asteroid;
    public GameObject tank;
    public GameObject rocket;

    [Header("Spawn intervals:")]
    public float enemySpawnInterval = 3.0f;
    public float asteroidSpawnInterval = 2.0f;
    public float enemyTankSpawnInterval = 4.0f;
    public float enemyRockerSpawnInterval = 10.0f;

    private GameplayManager manager;

    public void Awake()
    {
        manager = FindObjectOfType<GameplayManager>();

        InvokeRepeating("SpawnEnemy", 0.0f, enemySpawnInterval);
        InvokeRepeating("SpawnAsteroid", 0.0f, asteroidSpawnInterval);

        if (manager.level > 1)
            InvokeRepeating("SpawnEnemyTank", 0.0f, enemyTankSpawnInterval);

        if (manager.level > 2)
            InvokeRepeating("SpawnEnemyRocket", enemyRockerSpawnInterval / 2.0f, enemyRockerSpawnInterval);
    }

    private void SpawnEnemy()
    {
        Instantiate(
            enemy, 
            new Vector3(Random.Range(-5.0f, 5.0f), transform.position.y, 0.0f), 
            Quaternion.identity, 
            transform
        );
    }

    private void SpawnAsteroid()
    {
        Instantiate(
            asteroid,
            new Vector3(Random.Range(-6.0f, 6.0f), transform.position.y, 0.0f),
            Quaternion.identity,
            transform
        );
    }

    private void SpawnEnemyTank()
    {
        Instantiate(
            tank,
            new Vector3(Random.Range(-6.0f, 6.0f), transform.position.y, 0.0f),
            Quaternion.identity,
            transform
        );
    }

    private void SpawnEnemyRocket()
    {
        Instantiate(
            rocket,
            new Vector3(Random.Range(-4.0f, 4.0f), transform.position.y, 0.0f),
            Quaternion.identity,
            transform
        );
    }
}
