using UnityEngine;

class HomeRotate : MonoBehaviour
{
    [SerializeField] float angularSpeed;

    void Update()
    {

        float angle = angularSpeed * Time.deltaTime;
        transform.Rotate(Vector3.back, angle);
        transform.Rotate(Vector3.left, angle);
        transform.Rotate(Vector3.up, angle);


    }

}
