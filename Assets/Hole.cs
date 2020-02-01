using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public bool isPlayerStanding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            isPlayerStanding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            isPlayerStanding = false;
        }
    }

    public void FillMyself()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.material.SetColor("_Color", new Color(0f, 0f, 0f, 0.5f));
    }
}
