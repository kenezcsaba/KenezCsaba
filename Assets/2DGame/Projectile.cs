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
    {                                                           // speciális dolgok ezek az Ienumerator, nem egyszer tér vissza hanem sokszor
        yield return new WaitForSeconds(lifeTime);              // a Unity nem akad meg, de ezen a komponensen megáll, vár egy darabig aztán fut tovább

        yield return null;      // ha a következõ frame-ig akarunk várni. várakozás egy frame-ig. itt nem is feltétlen szükséges
        Destroy(gameObject);                                                                // például egy super mario féle sebzõdés amikor vibrál a
                                                                                            // karakter akkor egy olyat coroutne-ban meg lehet csinálni

    
    }

    public void SetVelocity(Vector2 velocity)
    {
        this.velocity = velocity;                //adott lokális változóra hivatkozna, kivéve ha this.-ot használunk, de így az osztályváltozóra hivatkozunk
    }


    void Update()
    {

        transform.position += (Vector3)velocity * Time.deltaTime;       // vector kettes sebességet hoztunk létre, ezért kell a velocity-t Vector3-sá konvertálni


        /*
        float age = Time.time - startTime;
        if (age > lifeTime)                                   // Time.time abszolut idõ
        {
            Destroy(gameObject);                                      // elpusztít saját gameObjectünket                // az eredeti objectbõl prefabot csináltunk és azt kötöttük be a SE-be h annak a mintájára jöjjenek létre a lövedékek 
        }*/             // dec. 22.
    }

}
