using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemController : MonoBehaviour
{
    [SerializeField]
    private Transform holdPosition;
    [SerializeField]
    private Transform pickupPosition;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float pickupRadius = 0;
    [SerializeField]
    private float throwVelocity = 1;
    [SerializeField]
    private PlayerController playerController;

    
    private GameObject currentItem;
    private SpriteRenderer spriteRenderer;

    void Update()
    {
        float angle = playerController.GetAngle();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentItem != null && currentItem.CompareTag("ThrowableItem"))
            {

                Collider2D itemCollider = DropItem();
                spriteRenderer.sortingOrder = -1;

                ExplosivesController explosives = currentItem.GetComponent<ExplosivesController>();
                if (explosives != null)
                {
                    currentItem.layer = 0;
                    explosives.Explode();
                }

                itemCollider.attachedRigidbody.velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle)).normalized * throwVelocity;

                currentItem = null;
            }
        }

        if (currentItem != null)
        {
            
            if (angle > 0 && angle < 180)
            {
                spriteRenderer.sortingOrder = -1;
            }
            else
            {
                spriteRenderer.sortingOrder = 1;
            }

            currentItem.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //Pickup
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentItem == null)
            {
                //look for items
                Collider2D itemCollider = Physics2D.OverlapCircle(pickupPosition.position, pickupRadius, layerMask);

                if (itemCollider != null)
                {
                    currentItem = itemCollider.gameObject;
                    spriteRenderer = currentItem.GetComponent<SpriteRenderer>();

                    itemCollider.attachedRigidbody.simulated = false;
                    itemCollider.enabled = false;

                    itemCollider.transform.parent = holdPosition.transform;
                    itemCollider.transform.localPosition = Vector3.zero;
                    itemCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
                }

            }
            else
            {
                DropItem();
                spriteRenderer.sortingOrder = -1;
                currentItem = null;


            }
        }


        

    }

    //currentItem != null;
    private Collider2D DropItem()
    {
        currentItem.transform.parent = null;

        Collider2D itemCollider = currentItem.GetComponent<Collider2D>();

        itemCollider.attachedRigidbody.simulated = true;
        itemCollider.enabled = true;

        return itemCollider;
    }

}
