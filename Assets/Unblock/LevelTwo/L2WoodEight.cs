using UnityEngine;

class L2WoodEight : MonoBehaviour
{
    [SerializeField] SpriteRenderer highlight;
    [SerializeField] bool isHit;
    float scaleX;
    float hittingX;


    void OnTriggerEnter2D(Collider2D collision)
    {
        Hit collider = collision.gameObject.GetComponent<Hit>();
        if (collider != null)
        {
            isHit = true;
            Vector2 hittingPos = collision.transform.position;
            Vector3 hittingScale = collision.transform.localScale;
            scaleX = hittingScale.x;
            hittingX = hittingPos.x;
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
            float limitX, limitXMax;
            newPos.y = 12.5f;
            if (isHit)
            {
                if (newPos.x > hittingX)
                {
                    Vector3 selfScale = transform.localScale;
                    float selfScaleX = selfScale.x;
                    limitX = hittingX + scaleX / 2 + selfScaleX / 2;
                    newPos.x = Mathf.Clamp(newPos.x, limitX, 10);
                    transform.position = new Vector2(newPos.x, newPos.y);

                }

                if (newPos.x < hittingX)
                {
                    Vector3 selfScaleMax = transform.localScale;
                    float selfScaleXMax = selfScaleMax.x;
                    limitXMax = hittingX - scaleX / 2 - selfScaleXMax / 2;
                    newPos.x = Mathf.Clamp(newPos.x, -10, limitXMax);
                    transform.position = new Vector2(newPos.x, newPos.y);
                }
            }
            transform.position = new Vector2(newPos.x, newPos.y);
        }
    }
}
