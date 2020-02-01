using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private Image damageBar;
    [SerializeField] private int maxDamage = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        maxDamage = 1; // Kiek daugiausiai zalos gali spaceship gaut.
        damage = 0; // Pradzioj žaidimo laivas sveikas.
        UpdateDamage();
    }

    // Makes damage to the ship
    public void DealDamage(float amount)
    {
        damage += amount;
        UpdateDamage();
        CheckForGameOver();
    }

    public void RemoveDamage(float amount)
    {
        damage -= amount;
        UpdateDamage();
        CheckForGameOver();
    }

    private void UpdateDamage()
    {
        damageBar.fillAmount = damage;
    }

    private void CheckForGameOver()
    {
        if (damage >= maxDamage)
        {
            // TODO: end the game
        }
    }
}
