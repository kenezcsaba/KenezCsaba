using UnityEngine;

class HomeFollower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 10;

    void Update()
    { 
    Vector3 targetPosition = target.position;
    Vector3 selfPosition = transform.position;

    transform.position = Vector3.MoveTowards(selfPosition, targetPosition, speed* Time.deltaTime);
    }


}
