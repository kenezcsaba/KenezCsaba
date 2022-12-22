using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    [SerializeField] SpriteRenderer highlight;

    private void OnMouseEnter()                 // amikor az eg�r eme objektum f�l� ker�l
    {
        if (highlight != null)
        {
        highlight.enabled = true;
        }
    }

    private void OnMouseExit()                  // a p�rja , kil�p�skor
    {
        if (highlight != null)
            highlight.enabled = false;
    }

    Vector2 cardStartPosition;
    Vector2 mouseStartPosition;

    void OnMouseDown()
    {
        mouseStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    // pixelben 
        cardStartPosition = transform.position;
        // mouseStartPosition = Input.mousePosition;        �gy t�l �rz�keny volt a mozg�s
    }

    void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);                    // pixel �s unity egys�gek k�z�tti elt�r�sb�l ad�d� �rz�keny mozg�s
        Vector2 offsetVector = mousePosition - mouseStartPosition;
        transform.position = cardStartPosition + offsetVector; 
    }

    void OnMouseUp()
    {
        
    }
}
