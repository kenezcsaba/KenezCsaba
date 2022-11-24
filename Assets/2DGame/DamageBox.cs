using UnityEngine;

class DamageBox : MonoBehaviour
{

    [SerializeField] int damage = 10;
    [SerializeField] bool instantKill = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthObject healthObject = collision.gameObject.GetComponent<HealthObject>();              //típust adtunk be paraméternek             ez egy lokáslis változó
        if (healthObject != null)
        {
            if (instantKill)
            {
                healthObject.Kill();
            }
            else
            {
                healthObject.Damage(damage);                // ez egy metódus amit meg kell csinálnunk
            }

        }

        // Debug.Log("DEATH!!");
        // Destroy(collision.gameObject);
    }                                                                                               //    IDÁIG LÉTEZIK A LOKÁLIS VÁLTOZÓ




}
