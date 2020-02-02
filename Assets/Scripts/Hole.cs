using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public bool isPlayerStanding;

    private int CurrentHp { get; set; }

    private int MaxHp { get; set; } = 2;

    public bool ConsoleType = false;

    public Sprite FixedConsoleImage;
    public GameObject SecretWall;

    public bool isFilled = false;
    public bool isVisible = false;

    void Start()
    {
        CurrentHp = MaxHp;
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
    void OnBecameVisible()
    {
        isVisible = true;
    }
    
    void OnBecameInvisible()
    {
        isVisible = false;
    }

    public void FillMyself(GameObject scrap)
    {
        //scrap.transform.parent = transform;
        //scrap.transform.position = new Vector2(0f, 0f);
        var renderer = GetComponent<SpriteRenderer>();
        // NOT WORKING
        // scrap.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        // scrap.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //scrap.transform.ve
        if (!ConsoleType)
        {
            renderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 0.5f));
            scrap.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    public void DealDamage()
    {
        CurrentHp--;
        if (ConsoleType)
        {
            if (CurrentHp == 0)
            {
                GameObject.Find("DamageBar").GetComponent<Damage>().RemoveDamage(0.1f);
                GetComponent<SpriteRenderer>().sprite = FixedConsoleImage;
                isFilled = true;
                SecretWall.transform.localScale = new Vector3(1,30,1);
            }
        }
        else
        {
            var scale = CurrentHp / (float)MaxHp;
            if (scale == 0)
            {
                GameObject.Find("DamageBar").GetComponent<Damage>().RemoveDamage(0.1f);
                Destroy(gameObject);
                isFilled = true;
            }
            else
            {
                transform.localScale = new Vector2(scale, scale);
            }
        }
    }
}
