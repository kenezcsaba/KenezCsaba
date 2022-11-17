using UnityEngine;

class PlatformerCameraControl : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float maxVerticalDistance; 

    private void Update()
    {
        Vector3 playerPos = player.position;

        float y = transform.position.y;

        if (y < playerPos.y - maxVerticalDistance)
        {
            y = playerPos.y - maxVerticalDistance;
        }

        if (y > playerPos.y + maxVerticalDistance)
        {
            y = player.position.y + maxVerticalDistance;
        }

        transform.position = new Vector3(playerPos.x,y,transform.position.z);

    }
}
