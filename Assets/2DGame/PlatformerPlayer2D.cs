using UnityEngine;
class PlatformerPlayer2D : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] HealthObject healthObject;
    [SerializeField] float jumpVelocity;
    [SerializeField] float horizontalSpeed;
    [SerializeField] int airJumpCount;

    bool isGrounded;
    int currentAirJumpBudget;

    // bool isOnJumpPlatform;
    
    JumpMultiplier jumpPlatform;


    void OnValidate()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        healthObject = GetComponent<HealthObject>();            // automatikusan lekérdezzük
    }


    void Update()
    {

        if (healthObject != null && healthObject.IsDead())
            return;


        // jump
        if ((isGrounded || currentAirJumpBudget > 0) && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = Vector2.zero;
            Vector2 jump = Vector2.up * jumpVelocity;

            // rigidbody.AddForce(jump * rigidbody.mass, ForceMode2D.Impulse);
            // if (jumpPlatform)
            //     jump *= 2;


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




    }


    void FixedUpdate()
    {

        if (healthObject != null && healthObject.IsDead())
            return;


        // Movement

        float inputX = Input.GetAxis("Horizontal");


        Vector2 velocity = new Vector2(inputX * horizontalSpeed, rigidbody.velocity.y);
        rigidbody.velocity = velocity;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        currentAirJumpBudget = airJumpCount;
        // Debug.Log("Collide: " + collision.otherCollider.name);


        /*
        JumpMultiplier platform = collision.gameObject.GetComponent<JumpMultiplier>();                          // lekérdezem h amivel ütközök van e jump multiplier komponense , típust tudok megadni paraméterként

        if (platform != null)                                                       // int és bool nem veheti ezt fel, de string már igen, tehát "null"-able típus Transform, GameObject nullable
        {
            Debug.Log("Collided: Jump multiplier");
            isOnJumpPlatform = true;
            float mult = platform.multiplier;
        }
        */                                                     //  ez volt korábban


        jumpPlatform = collision.gameObject.GetComponent<JumpMultiplier>();


    
    }



    void OnCollisionExit2D(Collision2D collision)
    {
         
        isGrounded = false;
        // isOnJumpPlatfrom = false;      korábban
        jumpPlatform = null;
        //   Debug.Log("Exit");

    }
}
