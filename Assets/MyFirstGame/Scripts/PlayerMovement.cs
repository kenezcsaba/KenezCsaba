using UnityEngine;

class PlayerMovement : MonoBehaviour
{

    // [SerializeField] Vector3 velocity;              // mozgas
    [SerializeField] float speed;
    [SerializeField] float angularSpeed = 180;
    [SerializeField] Animator anim;                                     // dec 22.


    void OnValidate()
    {
        if (anim == null)
        {
            anim = GetComponentInChildren<Animator>();
        }
    
    }

   /* private void OnValidate()
    {
        speed = 30;
    }*/                     // dec 22. tettem kommentbe

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

        bool isMoving = velocity != Vector3.zero;                           // dec 22.          a kód információt ad át az animator-nak
        anim.SetBool("isRunning",isMoving);                                 // dec 22.
                                                                                // Trigger ha megtörténik akkor átmegyünk egyik állapotból egy másikba az animációban
                                                                                        // ha animációba metódushívást beleteszünk akkor az úgy tud hatást létrehozni a játékban, pl egy ütõmozdulatba a sebzés tényleges mozdulatához teszek egy ilyet, ami majd csökkenti az életet


        transform.position += velocity * Time.deltaTime;


        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion currentRotation = transform.rotation;

            float maxStepInAngle = angularSpeed * Time.deltaTime;

            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, maxStepInAngle);
        }
        
    }

    // int nagyobb ja 64 bites változat: long
    // float 64 bit: double
    // rigidbody.velocity gravitáció szimulálása

}
