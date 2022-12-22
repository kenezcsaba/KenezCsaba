using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArraiesAndUnity : MonoBehaviour
{
    void OnValidate()
    {                                                                               // tömbjét egy adott típusú komponensekre, csak komponensekre 
        Rigidbody[] array1 = FindObjectsOfType<Rigidbody>();                     // var amikor nem tudom a típust, utólag módosítható?    a segítségre kattintva felajánlotta h rigidbdy tömb lesz
        CapsuleCollider2D capsule = FindObjectOfType<CapsuleCollider2D>();          // ez egy konkrétat ad vissza, amit elõször megtalál azt adja vissza,
                                                                                    // hol szokták használni? manager sripteknél, mert abból csak egy van
            //miket tanultunk még:
        SpriteRenderer renderer1 = GetComponent<SpriteRenderer>();                  // 
        SpriteRenderer renderer2 = GetComponentInChildren<SpriteRenderer>();        // saját magán, plusz a child objektumokon is keres
        SpriteRenderer renderer3 = GetComponentInParent<SpriteRenderer>();          // saját magán, plusz a parent objektumokon is keres



            // tömbös változatok
        SpriteRenderer[] renderers1 = GetComponents<SpriteRenderer>();
        SpriteRenderer[] renderers2 = GetComponentsInChildren<SpriteRenderer>();      
        SpriteRenderer[] renderers3 = GetComponentsInParent<SpriteRenderer>();



    }
}
