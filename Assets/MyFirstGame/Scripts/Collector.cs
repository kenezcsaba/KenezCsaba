using UnityEngine;

class Collector : MonoBehaviour
{
    int collectedValue = 0;              // egy változó érték hogy mennyit gyûjtttünk eddig

    // collider kell ahhoz hogy két objectum, ösze tudjon érni

    // triggerre állítjuk a collidereket (ill elég csak az egyiket) ütközés nem lesz csak kapunk egy üzenetet h összeértek, legaláb az egyik objektumon kell lennie rigidbodynak és Is Kinematic -ot be kell pipálni

    void OnTriggerEnter(Collider other)             // unity életciklus metódus akkor hívja meg a unity amikor belépünk egy triggerbe amikoir 2 trigger találkozik
    {
        // meg kell néznünk hogy van e a másik tárgyon collectable komponense

        // Collectable collectable = other.gameObject.GetComponent<Collectable>(); ennek az egyszerûbb változata:
        Collectable collectable = other.GetComponent<Collectable>();        // ha nincs collectable komponense akkor NULL értéket ad 

        if (collectable != null )
        {

            collectedValue += collectable.GetValue();       // növeljük az eddig összegyûjtött pontokat

            Debug.Log("Collected: " + collectedValue);      // majd kiírjuk
            collectable.Teleport();
        }


    }

}
