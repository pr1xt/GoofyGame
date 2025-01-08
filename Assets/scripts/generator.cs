using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval; // Time between spawns
    public float spawnZPosition; // Z pos
    public float spawnXRange = 4; // Random X pos
    public float intervalDecreaseRate = 0.01f; // How much to decrease the interval each time
    public float minimumSpawnInterval = 0.4f; // The minimum interval allowed

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
{
    float randomX = Random.Range(-spawnXRange, spawnXRange);
    Vector3 spawnPosition = new Vector3(randomX, 1, spawnZPosition);
    Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

    CancelInvoke("SpawnEnemy");

    spawnInterval = Mathf.Max(spawnInterval - intervalDecreaseRate, minimumSpawnInterval);

    // Restart InvokeRepeating with the new interval
    InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
}

}
