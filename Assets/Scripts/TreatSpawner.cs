using UnityEngine;

public class TreatSpawner : MonoBehaviour
{
    public GameObject[] treatObjects;
    public float treatCooldown;
    public float minPositionX;
    public float maxPositionX;
    public float minPositionY;
    public float maxPositionY;
    public float easyGameTime = 0;
    public float mediumGameTime;
    public float hardGameTime;
    public float totalGameTime;
    public bool treatSpawn;
    float gameTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        gameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

        

    }
    public void SpawnTreat()
    {
         
            // get random position at spawn
            Vector3 randomPosition = transform.position;
            randomPosition.y = Random.Range(minPositionY, maxPositionY);
            randomPosition.x = Random.Range(minPositionX, maxPositionX);

            // get random prefab from list
            int targetTreatIndex = Random.Range(0, treatObjects.Length);
            GameObject treatPrefab = treatObjects[targetTreatIndex];

            // spawn the enemy
            GameObject treat = Object.Instantiate(treatPrefab, randomPosition, transform.rotation);
            gameTime = 0;
        
    }
}


