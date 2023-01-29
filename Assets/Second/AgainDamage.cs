using UnityEngine;

class AgainDamage : MonoBehaviour
{

    [SerializeField] int damage = 30;
    [SerializeField] bool instantKill = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        AgainHealthObject healthObject = collision.gameObject.GetComponent<AgainHealthObject>();

        if (healthObject != null )
        {
            if (instantKill)
            {
                healthObject.Kill();
            }

            else
            {
                healthObject.Damage(damage);
            }

        }

    }

}
