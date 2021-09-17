using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float movespeed = 6f;
    public float sprintspeed = 1f;
    Vector2 movement;

    Vector2 direction = new Vector2();

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
        rb.MovePosition(rb.position + (movespeed * sprintspeed * Time.fixedDeltaTime * movement));
    }

    private void Move() 
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.y, movement.x);

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }


        if (Input.GetKey(KeyCode.LeftShift)){
            sprintspeed = 2;
        }
        else
        {
            sprintspeed = 1;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)){
            sprintspeed = 1;
        }
    }
}
