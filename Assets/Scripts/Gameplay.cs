using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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
    public static float boostStatus;
    public ScoreUI scoreUI;
    public TreatSpawner treatSpawner;
    private Rigidbody2D rb;
    SpriteRenderer sprite;
    public float movementSpeed = 5;
    public float boostReset;
    private Vector2 movement;
    public float boostCooldown = 3;
    public float boostTimer = 0;
    private float resetStatus;
    public static bool boostAvail;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        gameTime = 0;
        transform.position = new Vector3(0, 0, 0);
        boostReset = movementSpeed;
        boostAvail = false;
       
    }
  
    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        transform.position += new Vector3(movement.x, movement.y, 0) * movementSpeed * Time.deltaTime;
        boostTimer += Time.deltaTime;
        if (boostTimer >= boostCooldown && boostStatus == 1)
        {
           boostAvail = true;
           boostTimer = 0;
           movementSpeed += 15;
            
        }
        else if (boostTimer <= boostCooldown && movementSpeed > 5)
        {
            boostAvail = false;
            movementSpeed -= 0.5f;
        }


    }

    public void OnBoost(InputValue value)
    {
        boostStatus = (value.Get<float>());
    }

    public void OnMove(InputValue input)
    {
        movement = input.Get<Vector2>();
    }

    public void OnReset(InputValue value)
    {
        resetStatus = (value.Get<float>());
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
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
          TreatSpawner.treatSpawn = true;
        }

    }
}
