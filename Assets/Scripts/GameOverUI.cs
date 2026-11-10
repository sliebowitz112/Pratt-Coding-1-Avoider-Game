using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private TMP_Text timer;
    public float boostTimer;
    //private float timers = 0f;
    private float totalTime = 0f;
    private TMP_Text dead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gameplay.gameOver == false)
        {
            totalTime += Time.deltaTime;
        }
       
        if (Gameplay.gameOver == true)
        {
            timer.fontSize = 30;
            timer.text = $"GAME OVER MAN! " +
                $"              You lasted:  {totalTime.ToString("F1")} " +
                $"seconds! press 'r' to restart";
        }

    }
}
