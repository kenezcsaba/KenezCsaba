
using UnityEngine;

class SecondCameraControl : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float verticalDist,horizontalDist;
    float playerX, playerY,selfX,selfY;



    void Update()
    {
        Vector2 playerPos = player.position;
        playerX = playerPos.x;
        playerY = playerPos.y;
        selfX = transform.position.x;
        selfY = transform.position.y;

        if (selfX > playerX + horizontalDist)
        {
            selfX = playerX + horizontalDist;
        }

        if (selfX < playerX - horizontalDist)
        {
            selfX = playerX - horizontalDist;
        }

        if (selfY > playerY + verticalDist)
        {
            selfY = playerY + verticalDist;
        }

        if (selfY < playerY - verticalDist)
        {
            selfY = playerY - verticalDist;
        }




        transform.position = new Vector3(selfX, selfY,transform.position.z);

        

    }
}
