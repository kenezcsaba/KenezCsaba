using UnityEngine;

class SecondPlayer : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] AgainHealthObject healthObject;
    [SerializeField] float speed;
    [SerializeField] bool isGrounded;
    [SerializeField] float jumpVelocity;
    [SerializeField] int maxAirJumpCount;

    int currentAirJumpBudget;
    AgainJumpMultiplier jumpPlatform;                               


    void OnValidate()
    {
        rigidbody = GetComponent<Rigidbody2D>();                    //betöltöm automatikusan a saját rigidet?       ha a "gameObject."-et elé írom?
        healthObject = GetComponent<AgainHealthObject>();           // ez nem is saját ez a healthobj, úgy értem másik szkriptben van még ha a playeré is
    }

    /*void Start()
    {
        currentAirJumpBudget = maxAirJumpCount;


    }*/

    void Update()
    {


        if ((isGrounded || currentAirJumpBudget > 0) && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = Vector2.zero;                      // ---------------------------------- ez nullázza a sebességvektort ugye? ha futok oldal irányba akkor hogyhogy stimmel?
            Vector2 jump = Vector2.up * jumpVelocity;
            // rigidbody.AddForce(Vector2.up * jumpVelocity * rigidbody.mass,ForceMode2D.Impulse);

            if (jumpPlatform != null)
            {
                jump *= jumpPlatform.multiplier;
            }

            rigidbody.AddForce(jump * rigidbody.mass, ForceMode2D.Impulse);

            if (!isGrounded)
            {
                currentAirJumpBudget--;
            }
        }



       /* bool isRightPressed = Input.GetKey(KeyCode.RightArrow);
        bool isLeftPressed = Input.GetKey(KeyCode.LeftArrow);
        //bool isUpPressed = Input.GetKey(KeyCode.UpArrow);
        //bool isDownPressed = Input.GetKey(KeyCode.DownArrow);

        //float y = isUpPressed ? (isDownPressed ? 0 : 1) : (isDownPressed ? -1 : 0);
        float x = isRightPressed ? (isLeftPressed ? 0 : 1) : (isLeftPressed ? -1 : 0);
        Vector3 direction = new Vector3(x,0,0);
        direction.Normalize();

        Vector3 velocity = direction * speed;
        transform.position += velocity * Time.deltaTime;*/

    }


    void FixedUpdate()
    {

        if (healthObject != null && healthObject.isDead())                  //------------------------------ez annyit tesz ha halottak vagyunk akkor ne is fusson a metódus tovább?
            return;

        float inputX = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(inputX * speed,rigidbody.velocity.y);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        currentAirJumpBudget = maxAirJumpCount;
        Debug.Log($"Collide: {collision.collider.name}");                           // itt        csak leolvassuk az értéket

        jumpPlatform = collision.gameObject.GetComponent<AgainJumpMultiplier>();        // és itt ugyanarra a játék objektumra hivatkozunk? egyszer collider másszor gameObject
                                                                                                        //használjuk is az értéket
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        jumpPlatform = null;
    }

}
