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
        this.velocity = velocity;                //adott lok�lis v�ltoz�ra hivatkozna, kiv�ve ha this.-ot haszn�lunk
    }

    void Update()
    {

        transform.position += (Vector3)velocity * Time.deltaTime;       // vector kettes sebess�get hoztunk l�tre, ez�rt kell a velocity-t Vector3-s� konvert�lni

        float age = Time.time - startTime;
        if (age > lifeTime)                                   // Time.time abszolut id�
        {
            Destroy(gameObject);                                      // elpuszt�t saj�t gameObject�nket                // az eredeti objectb�l prefabot csin�ltunk �s azt k�t�tt�k be a SE-be h annak a mint�j�ra j�jjenek l�tre a l�ved�kek 
        }
    }

}
