using UnityEngine;

class Movement : MonoBehaviour
{

    [SerializeField] SpriteRenderer highlight;

    void OnMouseEnter()
    {
        if (highlight!= null)
        {
            highlight.enabled = true;
        }    
    }

    void OnMouseExit()
    {
        if (highlight!= null)
        {
            highlight.enabled = false;
        }    
    }

    Vector2 mouseStartPos;
    Vector2 objStartPos;

    void OnMouseDown()
    {
        mouseStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objStartPos = transform.position;
    }

    void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 offsetVec = mousePos - mouseStartPos;
        transform.position = objStartPos + offsetVec;
    }

}
