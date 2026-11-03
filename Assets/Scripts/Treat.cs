using UnityEngine;

public class Treat : MonoBehaviour
{
    public float points = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        
   
        gameObject.SetActive(false);
        points++;

    }
}
