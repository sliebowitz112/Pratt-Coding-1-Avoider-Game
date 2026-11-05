using System.Threading;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyObjects;
    public float spawnCooldown = 2;
    
    public float minPosition;
    public float maxPosition;
    public float minEnemySpeed;
    public float maxEnemySpeed;
    public float easyGameTime;
    public float mediumGameTime;
    public float hardGameTime;
    public float totalGameTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        easyGameTime = 0;
        mediumGameTime = 0;
        hardGameTime = 0;
        totalGameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        easyGameTime += Time.deltaTime;
        mediumGameTime += Time.deltaTime;
        hardGameTime += Time.deltaTime;
        totalGameTime += Time.deltaTime;

        if (easyGameTime >= spawnCooldown)
        {
            easyGameTime = 0;
            SpawnEnemy();
            Debug.Log("spawn enemy");
        }

        if (mediumGameTime >= spawnCooldown && totalGameTime > 15)
        {
            spawnCooldown = 1;
            mediumGameTime = 0;
            SpawnEnemy();
        }

        if (hardGameTime >= spawnCooldown && hardGameTime > 20)
        {
            spawnCooldown = 0.5f;
            hardGameTime = 0;
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        // get random position at spawn
        Vector3 randomPosition = transform.position;
        randomPosition.y = Random.Range(minPosition, maxPosition);

        // get random prefab from list
        int targetEnemyIndex = Random.Range(0, enemyObjects.Length);
        GameObject enemyPrefab = enemyObjects[targetEnemyIndex];

        // spawn the enemy
        GameObject enemy = Object.Instantiate(enemyPrefab, randomPosition, transform.rotation);

        float randomSpeed = Random.Range(minEnemySpeed, maxEnemySpeed);
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        enemyMovement.objectSpeed = randomSpeed;     

    }
}
