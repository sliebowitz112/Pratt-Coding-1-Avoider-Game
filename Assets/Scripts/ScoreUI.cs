using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private int score;
    private TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        text = GetComponent<TMP_Text>();
        text.text = $"Score: {score}";
    }

    // Update is called once per frame
    void Update()
    {
        if (Gameplay.gameOver == true)
        {
            text.text = $" ";
            text.fontSize = 70;
        }

        
    }

    public void OnTreatPickup()
    {
        score++;
        text.text = $"Score: {score}";
    }
}
