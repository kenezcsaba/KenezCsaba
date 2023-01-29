using UnityEngine;

enum ShootingPattern { First, Sequence, Random, PingPong };                                                    // nagyon egyszerû dolog : ))))))
    //lövési minta típus     értékek: lehet h mindig az elsõt, sorban,random...

class Shooter : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] Transform startPoint;                    // vector2 relatív kiindulás az adott objektumhoz  -- a létrehozás helye ez ugye
    [SerializeField] GameObject[] projectiles;                     // kell egy referencia is ez az, de h ez mi?    a lövedéknek a prototípusa lesz aminek a mintájára fog létrejönni
    [SerializeField] KeyCode key = KeyCode.X;
    [SerializeField] ShootingPattern pattern;

    int index = 0;

    void Update()
    {

        // ha itt létrehozok egy értéket akkor az egy update leftása után elveszik
        
        if (Input.GetKeyDown(key))
        {

            int i;
            if (pattern == ShootingPattern.First)
            {
                i = 0;
            }
            else if (pattern == ShootingPattern.Sequence)
            {
                i = index % projectiles.Length;
            }
            else if (pattern == ShootingPattern.Random)
                i = Random.Range(0, projectiles.Length);
            else
                i = 0;  // opcionális házi
            
            // int i = index % projectiles.Length; annak kiválasztása h  3 lövedék közül melyiket lõjjük ki épp
            GameObject newProjectile = Instantiate(projectiles[i]);         //létrehozunk egy újat az eredeti mintájára
            newProjectile.transform.position = startPoint.position;     // ennek a pozíciója legyen...

            Vector2 velocity = speed * transform.right;

            Projectile p = newProjectile.GetComponent<Projectile>();
            p.SetVelocity(velocity);

            index++;
            if (index >= projectiles.Length)                                    // ez is a lövedékek közül választ ki egyet
            {
                index = 0;                                                  // sorting layer a sorting orderhez hasonló ha változtatjuk ezt akkor tudjuk azt meghatározni h 2D-ben ha egy helyre esik két tárgy akkor melyik takarja melyiket
                                                                                    // szimpla layer az más az jobb fent van a transformban
            }
        }
        
    }


    // GameObject go = new GameObject();                egy game object létrehozása így is magvalósulhatna

    //  animációnal animator majd létrehozunk animation controllert azt bekötöm a game object animatorába a controllert majd minden más :D 
}
