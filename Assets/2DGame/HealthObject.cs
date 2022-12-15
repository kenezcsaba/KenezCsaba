using System;
using UnityEngine;
using TMPro;

class HealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;
    [SerializeField] int maxHealth = 100;

    [SerializeField] GameObject objectToTurnOnWhenDie;      //amikor kipurcan akkor ez lép majd érvénybe - game over

    [SerializeField] Color maxHealthColor;
    [SerializeField] Color zeroHealthColor;


    int currentHealth;               // osztály szintû változó

    const string healthKey = "health";                                // konstans változók értéke nem változik -- konstans 

    private void Awake()                // elõbb fut le mint a start                //HealthSave01  -- a végén áttettük startba, mivel ott megadtuk h max health-tel kezdjünk
    {
        if (PlayerPrefs.HasKey(healthKey))
        {
            currentHealth = PlayerPrefs.GetInt(healthKey);
        }
    }

    private void OnDestroy()        //     HealthSave 01          ahhoz h egy elmentett élet szintet majd egy újboli kezdésnél betölthetõ legyen
    {
        PlayerPrefs.SetInt(healthKey, currentHealth);        // health kulcsszó alá elmentjük az aktuális életszintet       bármilen platformon mûködik ezzel a playerPrefs-et de csak intet floatot és string-et tud kezelni 
    }


    private void Start()
    {
        if (PlayerPrefs.HasKey(healthKey))
        {
            currentHealth = PlayerPrefs.GetInt(healthKey);
        }

        if (currentHealth == 0)
        {
            currentHealth = maxHealth;
        }
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
        TestDeath();
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
        TestDeath();
    }


    // külön metódus when die

    void TestDeath()
    {
        if (IsDead())
        {
            objectToTurnOnWhenDie.SetActive(true);
            // objectToTurnOnWhenDie?.SetActive(true);     ha objectToTurnOnWhenDie értéke nulla vagyis nincs bekötve semmi, akkor nincs teendõje, ha van valami akkor pedig a setactive valósul meg. ez hiba kiküszöbölés
        }
    }



}
