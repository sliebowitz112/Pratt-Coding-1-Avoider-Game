using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float objectSpeed = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(objectSpeed, 0, 0) * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
