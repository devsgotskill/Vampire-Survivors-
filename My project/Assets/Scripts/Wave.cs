using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public int currentWave;
    public int startingEnemies; // Number of enemies in the first wave
    public int enemiesIncreasePerWave; // Number of enemies to add for every new wave
    public float startingSpawnDelay; // In the first wave, how long to wait between spawning enemies
    public float spawnDelayDecrease;
    // How much to decrease the spawn delay. So the game gets harder as the waves go on. For example, if this is 0.1, then the second wave will spawn enemies every 0.9 seconds, the third wave every 0.8 seconds.
    public float minimumSpawnDelay; // The minimum spawn delay. So if the spawn delay decrease is 0.1 then the game wont spawn enemies faster than every 0.1 seconds.
    public float timeBetweenWaves;
    private int enemiesRemainingToSpawn;
    void Start()
    {
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        enemiesRemainingToSpawn = startingEnemies + (currentWave - 1) * enemiesIncreasePerWave;
        float spawnDelay = startingSpawnDelay - (currentWave - 1) * spawnDelayDecrease;
        if (spawnDelay < minimumSpawnDelay)
        {
            spawnDelay = minimumSpawnDelay;
        }
        for (int i = 0; i < enemiesRemainingToSpawn; i++)
        {
            GameObject enemyPrefab = enemySpawner.GetRandomEnemy(currentWave);
            if (enemyPrefab != null)
            {
                Vector3 spawnPosition = enemySpawner.GetRandomSpawnPosition();
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnDelay);
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        currentWave++;
        StartCoroutine(StartWave());
    }
}