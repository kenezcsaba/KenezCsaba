using UnityEngine;

class L2WoodSeven : MonoBehaviour
{
    [SerializeField] SpriteRenderer highlight;
    [SerializeField] bool isHit;
    float scaleY;
    float hittingY;


    void OnTriggerEnter2D(Collider2D collision)
    {
        Hit collider = collision.gameObject.GetComponent<Hit>();
        if (collider != null)
        {
            isHit = true;
            Vector2 hittingPos = collision.transform.position;
            Vector3 hittingScale = collision.transform.localScale;
            scaleY = hittingScale.y;
            hittingY = hittingPos.y;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isHit = false;
    }

    void OnMouseEnter()
    {
        if (highlight != null)
        {
            highlight.enabled = true;
        }
    }

    void OnMouseExit()
    {
        if (highlight != null)
        {
            highlight.enabled = false;
        }
    }

    Vector2 mouseStartPos;
    Vector2 selfStartPos;


    void OnMouseDown()
    {
        mouseStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selfStartPos = transform.position;
    }

    void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float selfXmin = transform.position.x - transform.localScale.x / 2;
        float selfXmax = transform.position.x + transform.localScale.x / 2;
        float selfYmin = transform.position.y - transform.localScale.y / 2;
        float selfYmax = transform.position.y + transform.localScale.y / 2;

        if (selfXmin <= mousePos.x && mousePos.x <= selfXmax && selfYmin <= mousePos.y && mousePos.y <= selfYmax)
        {

            Vector2 offsetVec = mousePos - mouseStartPos;
            Vector2 newPos = selfStartPos + offsetVec;
            float limitY, limitYMax;
            newPos.x = -7.5f;
            if (isHit)
            {
                if (newPos.y > hittingY)
                {
                    Vector3 selfScale = transform.localScale;
                    float selfScaleY = selfScale.y;
                    limitY = hittingY + scaleY / 2 + selfScaleY / 2;
                    newPos.y = Mathf.Clamp(newPos.y, limitY, 10);
                    transform.position = new Vector2(newPos.x, newPos.y);

                }

                if (newPos.y < hittingY)
                {
                    Vector3 selfScaleMax = transform.localScale;
                    float selfScaleYMax = selfScaleMax.y;
                    limitYMax = hittingY - scaleY / 2 - selfScaleYMax / 2;
                    newPos.y = Mathf.Clamp(newPos.y, -10, limitYMax);
                    transform.position = new Vector2(newPos.x, newPos.y);
                }
            }
            transform.position = new Vector2(newPos.x, newPos.y);
        }
    }
}
