using UnityEngine;

public class EndBG : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Gameplay.gameOver == false)
        {
            gameObject.SetActive(false);
        }
        if (Gameplay.gameOver == true)
        {
            gameObject.SetActive(true);
        }
    }


}
