using UnityEngine;
 class VectorPractice : MonoBehaviour
{
    [SerializeField] Vector2 vector2Field;              // 2D vektor
    [SerializeField] Vector3 vector3Field;              // 3D vektor
    void OnValidate()
    {
        Vector2 vector2 = new Vector2(24, 2.5f);
        Vector3 vector3 = new Vector3(24, 2.5f, 5);

        Vector3 zeroVector = Vector3.zero;              // 0, 0, 0
        Vector3 upVector = Vector3.up;                  // 0, 1, 0
        Vector3 leftVector = Vector3.left;              // 0, 1, 0

            
        float v3y = vector3.y;                          // egy konkrét tengely értéke
        Debug.Log(v3y);

        vector3.z = 0;

        Vector3 vecA = new Vector3(1, 2, 5.5f);
        Vector3 vecB = new Vector3(33, 0, -2);

        Vector3 summaVec = vecA + vecB;
        Vector3 differenceVec = vecA - vecB;

        Vector3 productVec = vecA * 2;

    }
}
