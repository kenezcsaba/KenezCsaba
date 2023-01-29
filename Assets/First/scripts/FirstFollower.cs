
using UnityEngine;

class FirstFollower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;

    void Update()
    {
        Vector3 targetPos = target.position;
        Vector3 selfPos = transform.position;
        transform.position = Vector3.MoveTowards(selfPos, targetPos, speed * Time.deltaTime);

        Vector3 direction = targetPos - selfPos;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

}
