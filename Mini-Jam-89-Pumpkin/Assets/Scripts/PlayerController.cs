using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float movespeed = 6f;
    public float sprintspeed = 1f;
    Vector2 movement;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.isKinematic = false;
        rb.angularDrag = 0.0f;
        rb.gravityScale = 0.0f;
    }
    void Update()
    {
        Move();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * sprintspeed * Time.fixedDeltaTime);
    }
    private void Move() 
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift)){
            sprintspeed = 2;
        }else
        {
            sprintspeed = 1;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)){
            sprintspeed = 1;
        }
    }
}
