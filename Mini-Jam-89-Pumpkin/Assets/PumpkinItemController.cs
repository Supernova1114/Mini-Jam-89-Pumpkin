using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinItemController : MonoBehaviour
{
    [SerializeField]
    private float damage = 0;

    //A throwable pumpkin

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Horseman"))
        {
            DamageHandler damageHandler = collision.GetComponent<DamageHandler>();
            if (damageHandler != null)
            {
                damageHandler.Hurt(damage);

                //TBA play sound and particles
            }

            Destroy(gameObject, 0);
        }
    }
}
