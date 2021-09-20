using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour
{
    [SerializeField]
    private float health = 3;
    [SerializeField]
    private float infiniteSprintTime;
    [SerializeField]
    private float invulTime;
    [SerializeField]
    private float invulFlashInterval;
    private bool isInvincible = false;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Horseman"))
        {
            if (isInvincible == false)
            {
                health--;
                if (health <= 0)
                {
                    //DIE
                    print("DEAD");
                }
                else
                {
                    isInvincible = true;
                    StartCoroutine("HandleDamage");

                }
            }
            
        }
    }

    IEnumerator HandleDamage()
    {
        StartCoroutine("VisualInvincibility");
        yield return new WaitForSeconds(invulTime);
        isInvincible = false;
    }

    IEnumerator VisualInvincibility()
    {
        while (isInvincible)
        {
            spriteRenderer.color = Color.clear;
            yield return new WaitForSeconds(invulFlashInterval);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(invulFlashInterval);

        }
    }

}
