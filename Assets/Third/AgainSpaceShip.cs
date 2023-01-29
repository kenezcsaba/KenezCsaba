using UnityEngine;

class AgainSpaceShip : MonoBehaviour
{

    [SerializeField] float maxSpeed = 5;
    [SerializeField] float acceleration = 0.1f;
    [SerializeField] KeyCode forwardButton = KeyCode.UpArrow;
    [SerializeField] float currentSpeed;

    [SerializeField] float angularSpeed = 90;

    [SerializeField] float drag = 0.3f;

    Vector3 velocity;


    void FixedUpdate()
    {
        bool forward = Input.GetKey(forwardButton) || Input.GetKey(KeyCode.W);

        if (forward)
        {
            Vector3 direction = transform.up;                                        //k�dban hogyan rot�lok egy ir�nyt? egy viszony�t� �rt�khez k�pest, mondjuk itt a transform.up-hoz
            velocity += direction * acceleration * Time.fixedDeltaTime;              // van jelent�s�ge annak hogy mekkora lesz a sebess�g �rt�ke ha egy m�sodpercig nyomom az el�r�t, mik�zben a gyorsul�s egyre van �ll�tva? fizik�ban a = v / t
        }


        currentSpeed = velocity.magnitude;
        if (currentSpeed > maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        transform.position += velocity * Time.fixedDeltaTime;

        float rotationInput = Input.GetAxis("Horizontal");

        transform.Rotate(0, 0, -rotationInput * angularSpeed * Time.fixedDeltaTime);

        velocity *= 1 - (drag * Time.fixedDeltaTime);

    }
}
