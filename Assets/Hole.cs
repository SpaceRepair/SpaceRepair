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

    public void FillMyself(GameObject scrap)
    {
        scrap.transform.parent = transform;
        //scrap.transform.position = new Vector2(0f, 0f);
        var renderer = GetComponent<SpriteRenderer>();
        // NOT WORKING
        // scrap.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        // scrap.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //scrap.transform.ve
        renderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 0.5f));
    }
}
