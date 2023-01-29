using System.Collections.Generic;
using UnityEngine;

class ObjectsWithRock : MonoBehaviour
{
    List<Rock> rocks = new List<Rock>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        Rock r = collision.gameObject.GetComponent<Rock>();
        if (r!=null)
        {
            rocks.Add(r);
            Debug.Log(rocks.Count);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Rock r = collision.gameObject.GetComponent<Rock>();
        if (r!=null)
        {
            rocks.Remove(r);
            Debug.Log(rocks.Count);
        }
    }
}
