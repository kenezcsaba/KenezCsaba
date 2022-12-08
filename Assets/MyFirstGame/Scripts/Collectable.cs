using UnityEngine;

class Collectable : MonoBehaviour
{
    //publikussá tétel elõtt:
    //[SerializeField] int value = 1;

    //minden public ParticleSystemForceField az automatikusan SerializeField lesz

    public int value = 1;
    [SerializeField] Bounds teleportBounds;             // teleportáló helyet hoztunk létre 


    public int GetValue()              // csak az értékét adja meg mindenki hozzá tud férni és le tudja kérdezni de módosítani nem
    {
        return value;
    }


    void OnDrawGizmos()
    {

        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(teleportBounds.center, teleportBounds.size);        // size az az extend duplája mármint téglatestnél ami szabályos :)

    }

    //teleport metódus

    public void Teleport()
    {

        // véletlen pont kiválasztása a ground-on (játéktérben)
        //float random = Random.Range(0, 1);              // mi közé akarom tenni, ez a két paraméter amit meg kell adni - ez az int -es verzió,  a felsõ érték ki van zárva a tartományból lásd maxExclusive
        //float random = Random.Range(0f, 1f);                // ez a float - os verzió , itt beletartozik a min és a max is

        Vector3 min = teleportBounds.min;
        Vector3 max = teleportBounds.max;

        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);
        float randomZ = Random.Range(min.z, max.z);

        Vector3 randomPoint = new Vector3(randomX, randomY, randomZ);
        transform.position = randomPoint;

    }


}
