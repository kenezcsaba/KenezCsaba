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
        healthObject = GetComponent<HealthObject>();            // automatikusan lek�rdezz�k
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

        float inputX = Input.GetAxis("Horizontal");                                         // inputx ha valamelyik ir�nyba megy�nk


        /*
        if (inputX != 0)              //ha nem megy�nk se jobbra se balra                    // ezt csin�ljuk a kill�v�shez
        {
            float direction = Mathf.Sign(inputX);       //csak  -1 vagy 1 lehet ennek az �rt�ke 
            Vector3 scale = transform.localScale;                                                                   // itt azt csin�ljuk h a karakter orra arra n�zzen amerre ment�nk
            transform.localScale = new Vector3(direction * Mathf.Abs(scale.x), scale.y,scale.z);                    // a transformban a scale �rt�ket kell ugye -1-szeres�re �ll�tani ha fordul�st akarunk el�rni
       
                    nem v�lt be, mert ezzel egy�tt maradt a player lok�lis jobbr�ja fixen egy ir�nyban, a l�v�st pedig ehhez k�t�tt�k, �gy nem v�lt be
        
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
        JumpMultiplier platform = collision.gameObject.GetComponent<JumpMultiplier>();                          // lek�rdezem h amivel �tk�z�k van e jump multiplier komponense , t�pust tudok megadni param�terk�nt

        if (platform != null)                                                       // int �s bool nem veheti ezt fel, de string m�r igen, teh�t "null"-able t�pus Transform, GameObject nullable
        {
            Debug.Log("Collided: Jump multiplier");
            isOnJumpPlatform = true;
            float mult = platform.multiplier;
        }
        */                                                     //  ez volt kor�bban


        jumpPlatform = collision.gameObject.GetComponent<JumpMultiplier>();


    
    }



    void OnCollisionExit2D(Collision2D collision)
    {
         
        isGrounded = false;
        // isOnJumpPlatfrom = false;      kor�bban
        jumpPlatform = null;
        //   Debug.Log("Exit");

    }
}
