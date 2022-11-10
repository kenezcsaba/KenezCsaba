using UnityEngine;
class Follower : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] Transform target;

    void Update()
    {
        Vector3 targetPosition = target.position;
        Vector3 selfPosition = transform.position;

        float stepDistance = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(selfPosition, targetPosition, stepDistance);

        Vector3 direction = targetPosition - selfPosition;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

    }


    /*
     
        void Update()
    {
        Vector3 targetPosition = target.position;
        Vector3 selfPosition = transform.position;

        Vector3 direction = targetPosition - selfPosition;
        float distance = direction.magnitude;
        // distance = Vector3.Distance(targetPosition, selfPosition);

        direction.Normalize();

        float stepDistance = speed * Time.deltaTime;
        if (stepDistance > distance)
        {
            stepDistance = distance;
        }

        transform.position += direction * stepDistance;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

    }

    */


}
