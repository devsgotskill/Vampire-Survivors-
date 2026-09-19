using UnityEngine;
public class Wave : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public int currentWave;
    public int startingEnemies;
    public int enemiesIncreasePerWave;
    public float startingSpawnDelay;
    public float spawnDelayDecrease;
    public float minimumSpawnDelay;
    public float timeBetweenWaves;
    private int enemiesRemainingToSpawn;
    private float spawnTimer;
    private float waveTimer;
    private float spawnDelay;
    private bool waitingForNextWave;
    void Start()
    {
        if (currentWave <= 0)
        {
            currentWave = 1;
        }

        StartWave();
    }
    void Update()
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }
        if (enemiesRemainingToSpawn > 0)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {
                SpawnEnemy();
                spawnTimer = spawnDelay;
                enemiesRemainingToSpawn--;

                if (enemiesRemainingToSpawn <= 0)
                {
                    waitingForNextWave = true;
                    waveTimer = timeBetweenWaves;
                }
            }
        }
        else if (waitingForNextWave)
        {
            waveTimer -= Time.deltaTime;

            if (waveTimer <= 0)
            {
                currentWave++;
                StartWave();
            }
        }
    }
    void StartWave()
    {
        enemiesRemainingToSpawn = startingEnemies + (currentWave - 1) * enemiesIncreasePerWave;
        spawnDelay = startingSpawnDelay - (currentWave - 1) * spawnDelayDecrease;
        if (spawnDelay < minimumSpawnDelay)
        {
            spawnDelay = minimumSpawnDelay;
        }
        spawnTimer = 0;
        waitingForNextWave = false;
    }
    void SpawnEnemy()
    {
        GameObject enemyPrefab = enemySpawner.GetRandomEnemy(currentWave);

        if (enemyPrefab != null)
        {
            Vector3 spawnPosition = enemySpawner.GetRandomSpawnPosition();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}