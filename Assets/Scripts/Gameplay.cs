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
    public ScoreUI scoreUI;
    private Rigidbody2D rb;
    SpriteRenderer sprite;
    public float movementSpeed = 5;
    public float boostReset;
    private Vector2 movement;
    public float boostCooldown = 3;
    public float boostTimer = 0;
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
        transform.position += new Vector3(movement.x, movement.y, 0) * movementSpeed * Time.deltaTime;
        boostTimer += Time.deltaTime;
        if (boostTimer >= boostCooldown && boostStatus == 1)
        {
           boostTimer = 0;
           movementSpeed += 10;
        }



    }

    public void OnBoost(InputValue value)
    {
        boostStatus = (value.Get<float>());
      
        
        //if (boostStatus == 1 && boostTimer <= 3)
        //{
        //    boostTimer += Time.deltaTime;
        //    movementSpeed += 10;
        //}
        //else
        //{
        //    movementSpeed = 5;
        //    boostTimer = 0;
        //}
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
          other.gameObject.SetActive(false);
          scoreUI.OnTreatPickup();
        }

    }
}
