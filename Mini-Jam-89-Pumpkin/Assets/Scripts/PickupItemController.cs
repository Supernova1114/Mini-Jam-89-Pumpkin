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
    private PlayerController playerController;
    
    private GameObject currentItem;
    private SpriteRenderer spriteRenderer;

    void Update()
    {
        if (currentItem != null)
        {
            float angle = playerController.getAngle();
            if (angle > 0 && angle < 180)
            {
                spriteRenderer.sortingOrder = -1;
            }
            else
            {
                spriteRenderer.sortingOrder = 1;
            }
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
                }

            }
            else
            {
                currentItem.transform.parent = null;

                Collider2D itemCollider = currentItem.GetComponent<Collider2D>();

                itemCollider.attachedRigidbody.simulated = true;
                itemCollider.enabled = true;

                currentItem = null;


            }
        }
    }

    
}
