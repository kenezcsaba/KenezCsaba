using UnityEngine;

class PlayerMovement : MonoBehaviour
{

    // [SerializeField] Vector3 velocity;              // mozgas
    [SerializeField] float speed;
    [SerializeField] float angularSpeed = 180;

    private void OnValidate()
    {
        speed = 30;
    }

    //  [SerializeField] KeyCode rightButton;          +                  bool isRightPressed = Input.GetKey(rightButton) || Input.GetKey(KeyCode.D);

    void Update()
    {

        bool isRightPressed = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        bool isLeftPressed = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        bool isDownPressed = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        bool isUpPressed = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);



        float x = 0;
        if (isRightPressed)
        {
            x += 1;
        }
        if (isLeftPressed)
        {
            x -= 1;
        }

        float z = isUpPressed ? 1 :
            (isDownPressed ? -1 : 0);



        Vector3 direction = new Vector3(x, 0, z);
        direction.Normalize();

        Vector3 velocity = direction * speed;



        transform.position += velocity * Time.deltaTime;


        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion currentRotation = transform.rotation;

            float maxStepInAngle = angularSpeed * Time.deltaTime;

            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, maxStepInAngle);
        }
        
    }

}
