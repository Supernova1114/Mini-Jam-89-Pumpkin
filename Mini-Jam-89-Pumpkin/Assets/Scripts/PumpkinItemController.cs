using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinItemController : MonoBehaviour
{
    [SerializeField]
    private float damage = 0;

    //speed in which pumpkin must be above when thrown to do damage
    [SerializeField]
    private float damageSpeed = 0;

    [SerializeField]
    private ParticleSystem pumpkinParticles;
    private bool shouldHurt = false;
    [SerializeField]
    private Rigidbody2D body;
    private bool checkVelocity = false;



    //A throwable pumpkin

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shouldHurt && collision.CompareTag("Horseman"))
        {
            DamageHandler damageHandler = collision.GetComponent<DamageHandler>();
            if (damageHandler != null)
            {
                damageHandler.Hurt(damage);

                //TBA play sound and particles
            }

            pumpkinParticles.transform.parent = null;
            pumpkinParticles.Play();

            Destroy(gameObject, 0);
        }
    }

    private void Update()
    {
        
        if (checkVelocity && body.velocity.magnitude > damageSpeed)
        {
            shouldHurt = true;
        }
        else
        {
            shouldHurt = false;
            checkVelocity = false;
        }
    }



    public void setCheckVelocity(bool b)
    {
        checkVelocity = b;
    }

}
