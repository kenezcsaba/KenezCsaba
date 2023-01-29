using UnityEngine;

class Teleport : MonoBehaviour
{
    [SerializeField] Bounds teleportArea;


    void OnMouseEnter()
    {
        TeleportUnblock();
    }


    void TeleportUnblock()
    { 

        Vector3 min = teleportArea.min;
        Vector3 max = teleportArea.max;

        float randomX = Random.Range(min.x,max.x);
        float randomY = Random.Range(min.y,max.y);
        float randomZ = Random.Range(min.z, max.z);

        transform.position = new Vector3(randomX, randomY, randomZ);
    }
}
