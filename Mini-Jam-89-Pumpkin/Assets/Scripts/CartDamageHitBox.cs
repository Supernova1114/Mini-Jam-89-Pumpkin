using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartDamageHitBox : MonoBehaviour
{
    [SerializeField]
    private PushCartController pushCartController;
    private void OnTriggerStay2D(Collider2D collision)
    {
        pushCartController.SendMessage("HandleCollision", collision);
    }
}
