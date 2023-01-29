using System;
using TMPro;
using UnityEngine;

public class AgainHealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;
    [SerializeField] int currentHealth;
    [SerializeField] int maxHealth = 100;
    [SerializeField] Color maxHealthColor;
    [SerializeField] Color zeroHealthColor;
    [SerializeField] GameObject objectToTurnOnWhenDie;


    void Start()
    {
        currentHealth = maxHealth;
        UpdateText();
    }

    void UpdateText()
    {
        textComponent.text = "Health: " + currentHealth;
        float healthRate = (float)currentHealth / maxHealth;
        textComponent.color = Color.Lerp(zeroHealthColor,maxHealthColor,healthRate);
    }

    public void Kill()
    {
        currentHealth = 0;
        UpdateText();
        TestDeath();
    }

    public bool isDead()
    {
        return currentHealth <= 0;
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
        UpdateText();
        TestDeath();
    }


    void TestDeath()
    {
        if (isDead())
        {
            objectToTurnOnWhenDie.SetActive(true);
        }
    }
}
