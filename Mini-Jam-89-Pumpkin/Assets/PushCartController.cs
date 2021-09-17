using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCartController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private float damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        body.velocity = transform.right * speed;
    }

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

            //TBA slow horseman
            Destroy(gameObject, 0);
        }
    }

}
