using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapController : MonoBehaviour
{
    [SerializeField]
    private float damage = 0;

    private bool triggered = false;

    //A bear trap you can place down and lure the Horseman into it. Can only be used one (?)

    /*void Start()
    {
        
    }

    void Update()
    {
        
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Should hurt player too?
        if (triggered == false && collision.CompareTag("Horseman"))
        {
            triggered = true;

            DamageHandler damageHandler = collision.GetComponent<DamageHandler>();
            if (damageHandler != null)
            {
                //TBA slow down
                damageHandler.Hurt(damage);

                //play particles and sound and go to closed animation frame
            }

            //Should let player reset bear trap?
            Destroy(gameObject, 10);

        }
    }

}
