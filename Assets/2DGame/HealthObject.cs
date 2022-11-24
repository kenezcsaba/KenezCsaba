using System;
using UnityEngine;
using TMPro;

class HealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;
    [SerializeField] int maxHealth = 100;
    [SerializeField] Color maxHealthColor;
    [SerializeField] Color zeroHealthColor;


    int currentHealth;               // oszt�ly szint� v�ltoz�


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

    public void Kill()                          // met�dust hozunk l�tre
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
