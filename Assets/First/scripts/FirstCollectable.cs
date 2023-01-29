using UnityEngine;

public class FirstCollectable : MonoBehaviour
{

    [SerializeField] Bounds teleportBounds;
    [SerializeField] int value = 1;

    public int FirstGetValue()
    {
        return value;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(teleportBounds.center, teleportBounds.size);
    }

    public void Teleport()
    {
        Vector3 min = teleportBounds.min;
        Vector3 max = teleportBounds.max;

        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);
        float randomZ = Random.Range(min.z, max.z);

        Vector3 randomPoint = new Vector3(randomX,randomY,randomZ);
        transform.position = randomPoint;

    }

}
