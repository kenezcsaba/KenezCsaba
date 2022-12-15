using System;
using UnityEngine;
using TMPro;

class HealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;
    [SerializeField] int maxHealth = 100;

    [SerializeField] GameObject objectToTurnOnWhenDie;      //amikor kipurcan akkor ez l�p majd �rv�nybe - game over

    [SerializeField] Color maxHealthColor;
    [SerializeField] Color zeroHealthColor;


    int currentHealth;               // oszt�ly szint� v�ltoz�

    const string healthKey = "health";                                // konstans v�ltoz�k �rt�ke nem v�ltozik -- konstans 

    private void Awake()                // el�bb fut le mint a start                //HealthSave01  -- a v�g�n �ttett�k startba, mivel ott megadtuk h max health-tel kezdj�nk
    {
        if (PlayerPrefs.HasKey(healthKey))
        {
            currentHealth = PlayerPrefs.GetInt(healthKey);
        }
    }

    private void OnDestroy()        //     HealthSave 01          ahhoz h egy elmentett �let szintet majd egy �jboli kezd�sn�l bet�lthet� legyen
    {
        PlayerPrefs.SetInt(healthKey, currentHealth);        // health kulcssz� al� elmentj�k az aktu�lis �letszintet       b�rmilen platformon m�k�dik ezzel a playerPrefs-et de csak intet floatot �s string-et tud kezelni 
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

    public void Kill()                          // met�dust hozunk l�tre
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


    // k�l�n met�dus when die

    void TestDeath()
    {
        if (IsDead())
        {
            objectToTurnOnWhenDie.SetActive(true);
            // objectToTurnOnWhenDie?.SetActive(true);     ha objectToTurnOnWhenDie �rt�ke nulla vagyis nincs bek�tve semmi, akkor nincs teend�je, ha van valami akkor pedig a setactive val�sul meg. ez hiba kik�sz�b�l�s
        }
    }



}
