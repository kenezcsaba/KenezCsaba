using System.Collections.Generic;
using UnityEngine;

public class AgainCardWithStones : MonoBehaviour                                                             // eg�sz dec 22. 
{

    List<AgainStone> stones = new List<AgainStone>();       // ezt lehetne m�sk�pp �rni? pl itt egy olyan list�t hoztunk l�tre ami �res
                                                                                // ill lehet itt egy v�ltoz�hoz k�tni a sz�ml�l�st nem pedig oszt�lyhoz?

    void OnTriggerEnter2D(Collider2D collision)
    {
        AgainStone s = collision.gameObject.GetComponent<AgainStone>();                                                 // amivel tal�lkoztam,van e stone komponens rajta
        if (s != null)
        {
            stones.Add(s);                                                                                      // amikor triggerben vagyok, vagyis a k�t object egym�sba cs�szik, nem �tk�zik,
            Debug.Log(stones.Count);                                                                                                             // de kapok infot arr�l hogy egym�sba mentek
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        AgainStone s = collision.gameObject.GetComponent<AgainStone>();                                                       // sz�mol�shoz triggerhez kell h egyiken legyen rigidbody kinematicusan
                                                                                                                    // ezt a scriptet r� kell h�zni a k�rty�ra
                                                                                                                    //trigger bekapcsolni a k�vek collider�ben
        if (s != null)
        {
            stones.Remove(s);
            Debug.Log(stones.Count);
        }
    }


    // Bounding box ha kil�p az egyik oldalon akkor a m�sikon visszaj�jj�n, ahhoz ezt �rdemes haszn�lni
    // screen oszt�ly screen.   pl k�perny� m�rete / elhelyezked�se ha a kamera mozgat�s�t akarn�nk 
    // publikus git repository linkj�t elk�ldeni 

}
