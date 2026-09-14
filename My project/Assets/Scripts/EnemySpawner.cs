using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable] 
    public class EnemyType
    {
        public GameObject enemyPrefab;
        public int minimumWave;
    }

    public EnemyType[] enemies;

    public GameObject GetRandomEnemy(int currentWave)
    {
        System.Collections.Generic.List<GameObject> availableEnemies = new System.Collections.Generic.List<GameObject>(); // Why hasnt enyone told me about lists before? Ts <-- (this shit) just better then arrays!

        foreach (EnemyType enemy in enemies) // Loop through all the enemies and check if they are available for the current wave
        {
            if (currentWave >= enemy.minimumWave) // If the current wave is greater than or equal to the minimum wave for this enemy, add it to the list. This way I can make enemies spawn whenever I want so I can do cool stuff like have a boss spawn at wave 10 or something. I can also make enemies spawn at different waves so I can have a variety of enemies spawn at different times.
            {
                availableEnemies.Add(enemy.enemyPrefab);
            }
        }
        if (availableEnemies.Count == 0)
        {
            return null;
        }

        return availableEnemies[Random.Range(0, availableEnemies.Count)];
    }

    public Vector3 GetRandomSpawnPosition()
    {
        BoxCollider box = GetComponent<BoxCollider>();

        Vector3 min = box.bounds.min;
        Vector3 max = box.bounds.max;

        float x = Random.Range(min.x, max.x);
        float y = Random.Range(min.y, max.y);

        return new Vector3(x, y, -0.01f);
    }
}