
using UnityEngine;

class FirstPathMover : MonoBehaviour
{

    [SerializeField] Vector3 point1, point2;
    [SerializeField] float speed;
    [SerializeField, Range(0, 1)] float startPosition;



    bool forward;

    void OnValidate()
    {
        transform.position = Vector3.Lerp(point1,point2,startPosition);   
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


}
