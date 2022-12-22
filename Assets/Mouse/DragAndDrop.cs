using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    [SerializeField] SpriteRenderer highlight;

    private void OnMouseEnter()                 // amikor az egér eme objektum fölé kerül
    {
        if (highlight != null)
        {
        highlight.enabled = true;
        }
    }

    private void OnMouseExit()                  // a párja , kilépéskor
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
        // mouseStartPosition = Input.mousePosition;        így túl érzékeny volt a mozgás
    }

    void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);                    // pixel és unity egységek közötti eltérésbõl adódó érzékeny mozgás
        Vector2 offsetVector = mousePosition - mouseStartPosition;
        transform.position = cardStartPosition + offsetVector; 
    }

    void OnMouseUp()
    {
        
    }
}
