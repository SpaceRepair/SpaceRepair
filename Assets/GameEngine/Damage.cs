﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private Image damageBar;
    public float maxDamage = 1f; // Kiek daugiausiai zalos gali spaceship gaut.

    public GameObject GameOverScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        damage = 0; // Pradzioj žaidimo laivas sveikas.
        UpdateDamage();
    }

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
            GameOverScreen.SetActive(true);
            // TODO: Stop music gameObject.GetComponent<AudioSource>().Stop();
            Time.timeScale = 0.0F;
            // TODO: end the game
        }
    }
}
