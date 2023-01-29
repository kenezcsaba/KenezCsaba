using UnityEngine;

enum ShootingPattern { First, Sequence, Random, PingPong };                                                    // nagyon egyszer� dolog : ))))))
    //l�v�si minta t�pus     �rt�kek: lehet h mindig az els�t, sorban,random...

class Shooter : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] Transform startPoint;                    // vector2 relat�v kiindul�s az adott objektumhoz  -- a l�trehoz�s helye ez ugye
    [SerializeField] GameObject[] projectiles;                     // kell egy referencia is ez az, de h ez mi?    a l�ved�knek a protot�pusa lesz aminek a mint�j�ra fog l�trej�nni
    [SerializeField] KeyCode key = KeyCode.X;
    [SerializeField] ShootingPattern pattern;

    int index = 0;

    void Update()
    {

        // ha itt l�trehozok egy �rt�ket akkor az egy update left�sa ut�n elveszik
        
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
                i = 0;  // opcion�lis h�zi
            
            // int i = index % projectiles.Length; annak kiv�laszt�sa h  3 l�ved�k k�z�l melyiket l�jj�k ki �pp
            GameObject newProjectile = Instantiate(projectiles[i]);         //l�trehozunk egy �jat az eredeti mint�j�ra
            newProjectile.transform.position = startPoint.position;     // ennek a poz�ci�ja legyen...

            Vector2 velocity = speed * transform.right;

            Projectile p = newProjectile.GetComponent<Projectile>();
            p.SetVelocity(velocity);

            index++;
            if (index >= projectiles.Length)                                    // ez is a l�ved�kek k�z�l v�laszt ki egyet
            {
                index = 0;                                                  // sorting layer a sorting orderhez hasonl� ha v�ltoztatjuk ezt akkor tudjuk azt meghat�rozni h 2D-ben ha egy helyre esik k�t t�rgy akkor melyik takarja melyiket
                                                                                    // szimpla layer az m�s az jobb fent van a transformban
            }
        }
        
    }


    // GameObject go = new GameObject();                egy game object l�trehoz�sa �gy is magval�sulhatna

    //  anim�ci�nal animator majd l�trehozunk animation controllert azt bek�t�m a game object animator�ba a controllert majd minden m�s :D 
}
