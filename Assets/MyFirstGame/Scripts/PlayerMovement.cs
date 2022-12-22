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

        bool isMoving = velocity != Vector3.zero;                           // dec 22.          a k�d inform�ci�t ad �t az animator-nak
        anim.SetBool("isRunning",isMoving);                                 // dec 22.
                                                                                // Trigger ha megt�rt�nik akkor �tmegy�nk egyik �llapotb�l egy m�sikba az anim�ci�ban
                                                                                        // ha anim�ci�ba met�dush�v�st beletesz�nk akkor az �gy tud hat�st l�trehozni a j�t�kban, pl egy �t�mozdulatba a sebz�s t�nyleges mozdulat�hoz teszek egy ilyet, ami majd cs�kkenti az �letet


        transform.position += velocity * Time.deltaTime;


        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion currentRotation = transform.rotation;

            float maxStepInAngle = angularSpeed * Time.deltaTime;

            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, maxStepInAngle);
        }
        
    }

    // int nagyobb ja 64 bites v�ltozat: long
    // float 64 bit: double
    // rigidbody.velocity gravit�ci� szimul�l�sa

}
