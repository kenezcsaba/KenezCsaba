using UnityEngine;

class HomeMover : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 point1, point2;
    [SerializeField] Color color1, color2;

    [SerializeField, Range(0, 1)] float startPosition;

    bool forward;

    void OnValidate()
    {
        transform.position = Vector3.Lerp(point1, point2, startPosition);
    }

    void Start()
    {
        forward = true;
    }

    void Update()
    {
        Vector3 target = forward ? point1 : point2;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
        {
            forward = !forward;
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.Lerp(color1,color2,startPosition);
        //Gizmos.DrawLine(point1, point2);
        Gizmos.DrawWireSphere(point1, 0f);
        Gizmos.DrawWireSphere(point2, 0f);
    }
}
