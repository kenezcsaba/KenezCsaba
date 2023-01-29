using UnityEngine;

public class FirstCollector : MonoBehaviour
{
    int collectedValue = 0;

    private void OnTriggerEnter(Collider other)
    {
        FirstCollectable collectable = other.GetComponent<FirstCollectable>();

        if (collectable != null)
        {
            collectedValue += collectable.FirstGetValue();
            Debug.Log("Collected: " + collectedValue);
            collectable.Teleport();

        }
    }
}
