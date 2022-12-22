using System.Collections.Generic;
using UnityEngine;

public class CardWithStones : MonoBehaviour                                                             // egész dec 22. 
{

    List<Stone> stones = new List<Stone>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        Stone s = collision.gameObject.GetComponent<Stone>();                                                 // amivel találkoztam,van e stone komponens rajta
        if (s != null)
        {
            stones.Add(s);                                                                                      // amikor triggerben vagyok, vagyis a két object egymásba csúszik, nem ütközik,
            Debug.Log(stones.Count);                                                                                                             // de kapok infot arról hogy egymásba mentek
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Stone s = collision.gameObject.GetComponent<Stone>();                                                       // számoláshoz triggerhez kell h egyiken legyen rigidbody kinematicusan
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
