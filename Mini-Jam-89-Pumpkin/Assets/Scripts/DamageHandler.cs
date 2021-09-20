using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField]
    private float initialHealth = 0;
    private float currentHealth = 0;

    private bool isDead = false;

    void Start()
    {
        currentHealth = initialHealth;
    }

    void Update()
    {
        
    }

    public void Hurt(float damage)
    {
        if (isDead == false)
        {
            print("Ouch");
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                isDead = true;
                print("Ded");
            }
        }
        
    }

}
