using UnityEngine;

class FirstPlayerMovement : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float angularSpeed;
    [SerializeField] Animator anim;

    void Update()
    {
        bool isUpPressed = Input.GetKey(KeyCode.UpArrow);
        bool isDownPressed = Input.GetKey(KeyCode.DownArrow);
        bool isRightPressed = Input.GetKey(KeyCode.RightArrow);
        bool isLeftPressed = Input.GetKey(KeyCode.LeftArrow);

        float z = isUpPressed ? (isDownPressed ? 0 : 1) : (isDownPressed ? -1 : 0);
        float x = isRightPressed ? (isLeftPressed ? 0 : 1) : (isLeftPressed ? -1 : 0);

        Vector3 direction = new Vector3(x,0,z);
        direction.Normalize();

        Vector3 velocity = direction * speed;

        bool isMoving = velocity != Vector3.zero;
        anim.SetBool("isRunning", isMoving);

        transform.position += velocity * Time.deltaTime;

        if (direction != Vector3.zero)
        {
            //transform.rotation = Quaternion.LookRotation(direction);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion currentRotattion = transform.rotation;

            transform.rotation = Quaternion.RotateTowards(currentRotattion, targetRotation, angularSpeed * Time.deltaTime);
        }


    }



}



