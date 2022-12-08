using UnityEngine;

class ClickExplosion : MonoBehaviour
{
    [SerializeField] Transform aimingPoint;

    [SerializeField] float maxExplosionForce;
    [SerializeField] float explosionRange;
    [SerializeField] float upwardsModifier;

    void Update()
    {
        Vector3 clickPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(clickPosition);


        bool isHit = Physics.Raycast(ray, out RaycastHit hitInfo);    // eltaláltunk e valamit

        if (isHit)
        {
            // Debug.Log($"HIT: {hitInfo.collider.name}");
            aimingPoint.position = hitInfo.point;
        }
        else
        
        {
            aimingPoint.position = Vector3.up * 1000;
        }

        bool click = Input.GetMouseButtonDown(0);                               // egér 0 bal gomb    1 jobb gomb

        if (isHit && click)
        {
            Debug.Log("exp: " + hitInfo.point);


            Rigidbody[] rbs = FindObjectsOfType<Rigidbody>();                      // megkeres valamit amibõl egy van -  Object - Objects mindent

            for (int i = 0; i < rbs.Length; i++)
            {
                Rigidbody rb = rbs[i];

                rb.AddExplosionForce(maxExplosionForce,hitInfo.point,explosionRange);
            }

            aimingPoint.GetComponent<ParticleSystem>().Play();


        }

    }

}
