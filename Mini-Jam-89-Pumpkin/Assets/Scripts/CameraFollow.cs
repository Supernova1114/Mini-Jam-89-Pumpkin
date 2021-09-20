using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; //Camera has z = -10 value, gotta offset it so it follows the player (temp fix)

    private void FixedUpdate()
    {
        transform.position = player.position + offset;
    }
}