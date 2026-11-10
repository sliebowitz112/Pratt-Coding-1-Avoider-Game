using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class LevelUI : MonoBehaviour
{
    public float totalGameTime;
    private TMP_Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.text = $"Time: {totalGameTime}";
    }

    // Update is called once per frame
    void Update()
    {
        totalGameTime += Time.deltaTime;
        text.text = $"Time: {totalGameTime}";
    }
}
