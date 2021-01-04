using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthBar;
    public float CurrentHealth = 55f;
    public const float MaxHealth = 100;

    void Awake()
    {
        healthBar = GetComponent<Slider>();
    }

    void Update()
    {
        healthBar.value = CurrentHealth;
    }

    public void Heal(float Amount)
    {
        CurrentHealth += Amount;

        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        healthBar.value = CurrentHealth;
    }

    public void PlayerTakeDamage(float Amount)
    {
        CurrentHealth = CurrentHealth - Amount;
        healthBar.value = CurrentHealth;

        if(CurrentHealth <= 0)
        {
            healthBar.value = 0;
            CurrentHealth = 0;

            //codes after you die.
            Debug.Log("You died.");
        }
    }
}
