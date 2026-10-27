using System.Threading;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObject;
    public float spawnCooldown = 2;
    public float gameTime = 0;
    public float minPosition;
    public float maxPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime >= spawnCooldown)
        {
            gameTime = 0;
            SpawnEnemy();
            Debug.Log("spawn enemy");
        }
    }
    void SpawnEnemy()
    {
        Vector3 randomPosition = transform.position;
        randomPosition.y = Random.Range(minPosition, maxPosition);
        Object.Instantiate (enemyObject, randomPosition, transform.rotation);
    }
}
