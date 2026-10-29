using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class Gameplay : MonoBehaviour
{
    public float gameTime;
    Vector3 pos;
    private float spacebarStatus;
    private float moveupStatus;
    private float movedownStatus;
    private float moveleftStatus;
    private float moverightStatus;
    private float boostStatus;
    public float boostTimer;
    private Rigidbody2D rb;
    SpriteRenderer sprite;
    public float points;


    public float movementSpeed = 10;
    public float boostReset;
    private Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        gameTime = 0;
        transform.position = new Vector3(0, 0, 0);
        boostReset = movementSpeed;
    }
  
    // Update is called once per frame
    void Update()
    {
       
        gameTime += Time.deltaTime;
        // Debug.Log(gameTime);
        transform.position += new Vector3(movement.x, movement.y, 0) * movementSpeed * Time.deltaTime;
        if (boostStatus == 1 && boostTimer <= 3)
        {
            boostTimer += Time.deltaTime;
            movementSpeed *= 1.5f;
        }
       

    }

    public void OnBoost(InputValue value)
    {
        boostStatus = (value.Get<float>());
        boostTimer = 0;
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
}
