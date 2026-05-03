using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 2f;
    public float force = 5f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnTime);
    }

    void SpawnEnemy()
    {
        // posisi random di sekitar spawner
        float randomX = Random.Range(-5f, 5f);
        float randomY = Random.Range(-3f, 3f);

        Vector2 spawnPos = new Vector2(randomX, randomY);

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        // kasih dorongan (lempar)
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rb.AddForce(randomDirection * force, ForceMode2D.Impulse);
        }
    }
}