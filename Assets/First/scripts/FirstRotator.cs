
using UnityEngine;

class FirstRotator : MonoBehaviour
{

    [SerializeField] float angularSpeed;
    [SerializeField] Space rotationSpace;

    void Update()
    {
        float angle = angularSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up,angle,rotationSpace);
    }

}
