using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;
    private float nextActionTime = 0f;
    public float period = 1.0f; // 1 sekundė.


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (Time.time > nextActionTime) 
        {
            nextActionTime = Time.time + period;
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score++;
    }
}
