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
    private float acceleration = 0;
    [SerializeField]
    private float damage = 0;
    [SerializeField]
    private ParticleSystem pushCartParticles;

    private bool shouldHurt = false;

    // Start is called before the first frame update
    void Start()
    {
        body.bodyType = RigidbodyType2D.Static;
    }

    public void Use()
    {
        body.bodyType = RigidbodyType2D.Dynamic;
        shouldHurt = true;

        Destroy(gameObject, 10);
    }

    private void Update()
    {
        if (shouldHurt)
        {
            body.velocity = transform.right * speed;
            speed += acceleration;
        }
    }

    public void HandleCollision(Collider2D collision)
    {
        if (shouldHurt == true)
        {
            if (collision.CompareTag("Horseman"))
            {
                DamageHandler damageHandler = collision.GetComponent<DamageHandler>();
                if (damageHandler != null)
                {
                    damageHandler.Hurt(damage);

                }
            }
            

            //TBA slow horseman
            pushCartParticles.transform.parent = null;
            pushCartParticles.Play();

            Destroy(gameObject, 0);
        }
    }

}
