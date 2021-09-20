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
    private LayerMask itemMask;
    [SerializeField]
    private LayerMask usableMask;
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentItem != null)
            {
                //try to use current item in hand
                if (currentItem.CompareTag("ThrowableItem"))
                {
                    Collider2D itemCollider = DropItem();
                    spriteRenderer.sortingOrder = -1;

                    ExplosivesController explosivesController = currentItem.GetComponent<ExplosivesController>();
                    if (explosivesController != null)
                    {
                        explosivesController.Explode();
                        currentItem.layer = 0;
                    }

                    itemCollider.attachedRigidbody.velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle)).normalized * throwVelocity;

                    PumpkinItemController pumpkinController = currentItem.GetComponent<PumpkinItemController>();
                    if (pumpkinController != null)
                    {
                        pumpkinController.setCheckVelocity(true);
                    }

                    currentItem = null;
                }

            }
            else
            {
                //print("USE");
                //try to do Use Action
                Collider2D itemCollider = Physics2D.OverlapCircle(pickupPosition.position, pickupRadius, usableMask.value);
                if (itemCollider != null)
                {
                    itemCollider.SendMessage("Use");
                }

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
                Collider2D itemCollider = Physics2D.OverlapCircle(pickupPosition.position, pickupRadius, itemMask.value);

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
