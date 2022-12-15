using UnityEngine;

class Projectile : MonoBehaviour
{

    [SerializeField] float lifeTime = 3;

    Vector2 velocity;

    float startTime;

    void Start()
    {
        startTime = Time.time;    
    }

    public void SetVelocity(Vector2 velocity)
    {
        this.velocity = velocity;                //adott lokális változóra hivatkozna, kivéve ha this.-ot használunk
    }

    void Update()
    {

        transform.position += (Vector3)velocity * Time.deltaTime;       // vector kettes sebességet hoztunk létre, ezért kell a velocity-t Vector3-sá konvertálni

        float age = Time.time - startTime;
        if (age > lifeTime)                                   // Time.time abszolut idõ
        {
            Destroy(gameObject);                                      // elpusztít saját gameObjectünket                // az eredeti objectbõl prefabot csináltunk és azt kötöttük be a SE-be h annak a mintájára jöjjenek létre a lövedékek 
        }
    }

}
