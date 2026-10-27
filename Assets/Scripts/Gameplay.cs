using UnityEngine;
using UnityEngine.InputSystem;

public class Gameplay : MonoBehaviour
{
    public float gameTime;
    Vector3 pos;
    private float spacebarStatus;
    private float moveupStatus;
    private float movedownStatus;
    private float moveleftStatus;
    private float moverightStatus;
    private Rigidbody2D rb;
    SpriteRenderer sprite;
    public float points;


    public float movementSpeed = 10;
    private Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        gameTime = 0;
        transform.position = new Vector3(0, 0, 0);
    }
    public void OnMove(InputValue input)
    {
        movement = input.Get<Vector2>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Treat"))
        {
            points++;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        // Debug.Log(gameTime);
        transform.position += new Vector3(movement.x, movement.y, 0) * movementSpeed * Time.deltaTime;

    }

   
}
