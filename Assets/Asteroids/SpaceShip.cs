using UnityEngine;

class SpaceShip : MonoBehaviour
{

    [SerializeField] float maxSpeed = 5;
    [SerializeField] float acceleration = 0.1f;
    [SerializeField] KeyCode forwardButton = KeyCode.UpArrow;

    [SerializeField] float angularSpeed = 90;

    [SerializeField] float drag = 0.3f;

    Vector3 velocity;   // nem akarjuk h update-kben elvesszen

    void FixUpdate()
    {
        bool forward = Input.GetKey(forwardButton) || Input.GetKey(KeyCode.W);

        if (forward)
        {
            Vector3 direction = transform.up;
            velocity += direction * acceleration * Time.fixedDeltaTime;                    // Time.deltaTime mal akkor kell szorozni ha valami egyenletesen változik, itt most a sebesség
        }


        float currentSpeed = velocity.magnitude;
        if (currentSpeed > maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        transform.position += velocity * Time.fixedDeltaTime;

        // forgás ------------------------------------------------------

        float rotationInput = Input.GetAxis("Horizontal");

        transform.Rotate(0, 0, -rotationInput * angularSpeed * Time.fixedDeltaTime);

        // Lassulás -----------------------------------

        velocity *= 1 - (drag * Time.fixedDeltaTime);

    }


}
