using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArraiesAndUnity : MonoBehaviour
{
    void OnValidate()
    {                                                                               // t�mbj�t egy adott t�pus� komponensekre, csak komponensekre 
        Rigidbody[] array1 = FindObjectsOfType<Rigidbody>();                     // var amikor nem tudom a t�pust, ut�lag m�dos�that�?    a seg�ts�gre kattintva felaj�nlotta h rigidbdy t�mb lesz
        CapsuleCollider2D capsule = FindObjectOfType<CapsuleCollider2D>();          // ez egy konkr�tat ad vissza, amit el�sz�r megtal�l azt adja vissza,
                                                                                    // hol szokt�k haszn�lni? manager sriptekn�l, mert abb�l csak egy van
            //miket tanultunk m�g:
        SpriteRenderer renderer1 = GetComponent<SpriteRenderer>();                  // 
        SpriteRenderer renderer2 = GetComponentInChildren<SpriteRenderer>();        // saj�t mag�n, plusz a child objektumokon is keres
        SpriteRenderer renderer3 = GetComponentInParent<SpriteRenderer>();          // saj�t mag�n, plusz a parent objektumokon is keres



            // t�mb�s v�ltozatok
        SpriteRenderer[] renderers1 = GetComponents<SpriteRenderer>();
        SpriteRenderer[] renderers2 = GetComponentsInChildren<SpriteRenderer>();      
        SpriteRenderer[] renderers3 = GetComponentsInParent<SpriteRenderer>();



    }
}
