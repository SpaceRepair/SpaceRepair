using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeOtherScript : MonoBehaviour
{

    public Score score;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Text");
        score = text.GetComponent<Score>();

        score.AddScore(10);
    }

    // Update is called once per frame
    void Update()
    {
        score.AddScore(10);
    }
}
