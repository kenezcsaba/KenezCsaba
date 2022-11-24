using System;
using UnityEngine;
using TMPro;

class HealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;
    [SerializeField] int maxHealth = 100;
    [SerializeField] Color maxHealthColor;
    [SerializeField] Color zeroHealthColor;


    int currentHealth;               // osztály szintû változó


    private void Start()
    {
        currentHealth = maxHealth;

        UpdateText();
    }

    void UpdateText()
    {
        textComponent.text = "Health: " + currentHealth;

        float healthRate = (float)currentHealth / maxHealth;
        textComponent.color = Color.Lerp(zeroHealthColor, maxHealthColor, healthRate);
    }

    public void Kill()                          // metódust hozunk létre
    {
        currentHealth = 0;
        UpdateText();
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    public void Damage(int damage)
    {

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateText();
    }
}
