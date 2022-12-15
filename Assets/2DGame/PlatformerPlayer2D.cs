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

        float inputX = Input.GetAxis("Horizontal");                                         // inputx ha valamelyik irányba megyünk


        /*
        if (inputX != 0)              //ha nem megyünk se jobbra se balra                    // ezt csináljuk a killövéshez
        {
            float direction = Mathf.Sign(inputX);       //csak  -1 vagy 1 lehet ennek az értéke 
            Vector3 scale = transform.localScale;                                                                   // itt azt csináljuk h a karakter orra arra nézzen amerre mentünk
            transform.localScale = new Vector3(direction * Mathf.Abs(scale.x), scale.y,scale.z);                    // a transformban a scale értéket kell ugye -1-szeresére állítani ha fordulást akarunk elérni
       
                    nem vált be, mert ezzel együtt maradt a player lokális jobbrája fixen egy irányban, a lövést pedig ehhez kötöttük, így nem vált be
        
        }*/

        if (inputX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (inputX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);                               // elforgatjuk a playert
        }

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
