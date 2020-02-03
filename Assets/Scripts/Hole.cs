using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public bool isPlayerStanding;

    private int CurrentHp { get; set; }

    public int MaxHp = 3;

    public bool ConsoleType = false;

    public Sprite FixedConsoleImage;
    public GameObject SecretWall;

    public bool isFilled = false;
    public bool isVisible = false;

    public float DamageAmount = 0.1f;

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

    public void DealDamage()
    {
        CurrentHp--;
        if (ConsoleType)
        {
            if (CurrentHp == 0)
            {
                GameObject.Find("DamageBar").GetComponent<Damage>().RemoveDamage(DamageAmount);
                GetComponent<SpriteRenderer>().sprite = FixedConsoleImage;
                isFilled = true;
                SecretWall.transform.localScale = new Vector3(1,30,1);
            }
        }
        else
        {
            if (CurrentHp == 0)
            {
                GameObject.Find("DamageBar").GetComponent<Damage>().RemoveDamage(DamageAmount);
                Destroy(gameObject);
                isFilled = true;

                // TODO: Atlaisvinti skylės atsiradimo vietą.
            }
            else
            {
                transform.localScale = new Vector2(transform.localScale.x * 0.8f, transform.localScale.x * 0.8f);
            }
        }
    }
}
