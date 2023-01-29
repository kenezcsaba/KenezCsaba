using System.Collections;
using UnityEngine;

class Projectile : MonoBehaviour
{

    [SerializeField] float lifeTime = 3;

    Vector2 velocity;

    // float startTime;             dec22.

    void Start()
    {
        //startTime = Time.time;    dec22.
        StartCoroutine(DestroyCoroutine());                 // dec 22.
    }

    IEnumerator DestroyCoroutine()                         // dec 22.
    {                                                           // speci�lis dolgok ezek az Ienumerator, nem egyszer t�r vissza hanem sokszor
        yield return new WaitForSeconds(lifeTime);              // a Unity nem akad meg, de ezen a komponensen meg�ll, v�r egy darabig azt�n fut tov�bb

        yield return null;      // ha a k�vetkez� frame-ig akarunk v�rni. v�rakoz�s egy frame-ig. itt nem is felt�tlen sz�ks�ges
        Destroy(gameObject);                                                                // p�ld�ul egy super mario f�le sebz�d�s amikor vibr�l a
                                                                                            // karakter akkor egy olyat coroutne-ban meg lehet csin�lni

    
    }

    public void SetVelocity(Vector2 velocity)
    {
        this.velocity = velocity;                //adott lok�lis v�ltoz�ra hivatkozna, kiv�ve ha this.-ot haszn�lunk, de �gy az oszt�lyv�ltoz�ra hivatkozunk
    }


    void Update()
    {

        transform.position += (Vector3)velocity * Time.deltaTime;       // vector kettes sebess�get hoztunk l�tre, ez�rt kell a velocity-t Vector3-s� konvert�lni


        /*
        float age = Time.time - startTime;
        if (age > lifeTime)                                   // Time.time abszolut id�
        {
            Destroy(gameObject);                                      // elpuszt�t saj�t gameObject�nket                // az eredeti objectb�l prefabot csin�ltunk �s azt k�t�tt�k be a SE-be h annak a mint�j�ra j�jjenek l�tre a l�ved�kek 
        }*/             // dec. 22.
    }

}
