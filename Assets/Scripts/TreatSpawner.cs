using UnityEngine;

public class TreatSpawner : MonoBehaviour
{
    public GameObject[] treatObjects;
    public float spawnCooldown = 2;
    
    public float minPosition;
    public float maxPosition;
    public float minEnemySpeed;
    public float maxEnemySpeed;
    public float easyGameTime = 0;
    public float mediumGameTime;
    public float hardGameTime;
    public float totalGameTime; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        easyGameTime = 0;
        mediumGameTime = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        easyGameTime += Time.deltaTime;
        mediumGameTime += Time.deltaTime;

        if (easyGameTime >= spawnCooldown)
        {
            easyGameTime = 0;
            SpawnEnemy();
            Debug.Log("spawn enemy");
        }

        if (mediumGameTime >= spawnCooldown && totalGameTime > 15)
        {
            spawnCooldown = 1;
        }
    }
    void SpawnEnemy()
    {
        // get random position at spawn
        Vector3 randomPosition = transform.position;
        randomPosition.y = Random.Range(minPosition, maxPosition);

        // get random prefab from list
        int targetEnemyIndex = Random.Range(0, treatObjects.Length);
        GameObject enemyPrefab = treatObjects[targetEnemyIndex];

        // spawn the enemy
        GameObject enemy = Object.Instantiate(enemyPrefab, randomPosition, transform.rotation);

        float randomSpeed = Random.Range(minEnemySpeed, maxEnemySpeed);
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        enemyMovement.objectSpeed = randomSpeed;

    }
}


