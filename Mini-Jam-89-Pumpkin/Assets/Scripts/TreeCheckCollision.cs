using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCheckCollision : MonoBehaviour
{
    public Transform player;
    public SpriteRenderer layers;

    private void FixedUpdate()
    {
        if ((transform.position.y - 4.1) > (player.transform.position.y - 1))
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            layers.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
        else 
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            layers.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
}
