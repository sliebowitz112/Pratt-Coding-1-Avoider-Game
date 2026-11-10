using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class LevelUI : MonoBehaviour
{
    private TMP_Text boost;
    public float totalGameTime;
    private TMP_Text timer;
    public float boostTimer;
    private float timers = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boostTimer = 0;
        timers = 3;
        timer = GetComponent<TMP_Text>();
       // timer.text = $"Time: {totalGameTime}";
        boost = GetComponent<TMP_Text>();
        boost.text = $"Boost Timer: {boostTimer}";

    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (boostTimer <= 3)
        {
            timers -= Time.deltaTime;
            boost.text = $"Boost Timer: {timers.ToString("F1")}";
            boostTimer += Time.deltaTime;
        }

        else if (boostTimer >= 3)
        {
            boost.text = $"BOOST AVAILABLE";

            if (Gameplay.boostStatus == 1)
            {
                boostTimer = 0;
                timers = 3;
            }
        }
       
        totalGameTime += Time.deltaTime;
       // timer.text = $"Time: {totalGameTime}";
    }
}
