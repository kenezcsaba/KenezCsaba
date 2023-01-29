using System.Collections.Generic;
using UnityEngine;

public class AgainCardWithStones : MonoBehaviour                                                             // egész dec 22. 
{

    List<AgainStone> stones = new List<AgainStone>();       // ezt lehetne másképp írni? pl itt egy olyan listát hoztunk létre ami üres
                                                                                // ill lehet itt egy változóhoz kötni a számlálást nem pedig osztályhoz?

    void OnTriggerEnter2D(Collider2D collision)
    {
        AgainStone s = collision.gameObject.GetComponent<AgainStone>();                                                 // amivel találkoztam,van e stone komponens rajta
        if (s != null)
        {
            stones.Add(s);                                                                                      // amikor triggerben vagyok, vagyis a két object egymásba csúszik, nem ütközik,
            Debug.Log(stones.Count);                                                                                                             // de kapok infot arról hogy egymásba mentek
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        AgainStone s = collision.gameObject.GetComponent<AgainStone>();                                                       // számoláshoz triggerhez kell h egyiken legyen rigidbody kinematicusan
                                                                                                                    // ezt a scriptet rá kell húzni a kártyára
                                                                                                                    //trigger bekapcsolni a kövek colliderében
        if (s != null)
        {
            stones.Remove(s);
            Debug.Log(stones.Count);
        }
    }


    // Bounding box ha kilép az egyik oldalon akkor a másikon visszajöjjön, ahhoz ezt érdemes használni
    // screen osztály screen.   pl képernyõ mérete / elhelyezkedése ha a kamera mozgatását akarnánk 
    // publikus git repository linkjét elküldeni 

}
