using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; //Camera has z = -10 value, gotta offset it so it follows the player (temp fix)
    public Vector3 mapMin, mapMax;
    private void FixedUpdate()
    {
        Vector3 playerPosition = player.position + offset;
        Vector3 mapBounds = new Vector3(Mathf.Clamp(playerPosition.x, mapMin.x, mapMax.x), Mathf.Clamp(playerPosition.y, mapMin.y, mapMax.y), Mathf.Clamp(playerPosition.z, mapMin.z, mapMax.z));

        transform.position = Vector3.Lerp(transform.position, mapBounds, 4*Time.fixedDeltaTime);
    }
}
