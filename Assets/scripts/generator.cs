using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval; // Time between spawns
    public float spawnZPosition; // Z pos
    public float spawnXRange; // Random X pos

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-spawnXRange, spawnXRange);
        Vector3 spawnPosition = new Vector3(randomX, 1, spawnZPosition);

        // Instantiate the enemy at the spawn position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
