
using UnityEngine;

class FirstCameraControl : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float maximumDistance = 10;
    [SerializeField] float minDistanceToPlayer = 3;

    
    void Update()
    {
        Vector3 playerPos = player.position;
        float playerZ = playerPos.z;
        float selfZ = transform.position.z;

        if (selfZ > playerZ - minDistanceToPlayer)
        {
            selfZ = playerZ - minDistanceToPlayer;
        }


        if (selfZ < playerZ - maximumDistance)
        {
            selfZ = playerZ - maximumDistance;
        }

        /*else
        {
            selfZ = transform.position.z;
        }*/

        transform.position = new Vector3(player.position.x,transform.position.y, selfZ);
    }

}
