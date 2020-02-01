using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public bool isPlayerStanding;

    private int CurrentHp { get; set; }

    private int MaxHp { get; set; } = 2;

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

    public void FillMyself(GameObject scrap)
    {
        //scrap.transform.parent = transform;
        //scrap.transform.position = new Vector2(0f, 0f);
        scrap.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        var renderer = GetComponent<SpriteRenderer>();
        // NOT WORKING
        // scrap.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        // scrap.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //scrap.transform.ve
        renderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 0.5f));
    }

    public void DealDamage()
    {
        CurrentHp--;
        var scale = CurrentHp / (float)MaxHp;
        if (scale == 0)
        {
            GameObject.Find("DamageBar").GetComponent<Damage>().RemoveDamage(0.1f);
            Destroy(gameObject);
            return;
        }

        transform.localScale = new Vector2(scale, scale);
    }
}
