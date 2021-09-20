using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float movespeed = 6f;
    [SerializeField]
    private float sprintspeed = 1f;
    private float sprint = 1f;
    private Vector2 movement;

    private float angle;

    [SerializeField]
    private GameObject placeRotator;
    [SerializeField]
    private GameObject placePosition;
    

    [SerializeField]
    private Animator animator;
    private bool isSprinting = false;
    private int lastDirection = 0;

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
        rb.MovePosition(rb.position + (movespeed * sprint * Time.fixedDeltaTime * movement));
    }

    private void Move() 
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

       

        if (movement != Vector2.zero)
        {
            angle = Mathf.Rad2Deg * Mathf.Atan2(movement.y, movement.x);

            placeRotator.transform.rotation = Quaternion.Euler(0, 0, angle);
        }


        if (Input.GetKey(KeyCode.LeftShift)){
            if (StaminaController.instance.CheckStamina() == 0)
            {
                sprint = 1;
                isSprinting = false;
            }
            else 
            {
                sprint = sprintspeed;
                isSprinting = true;
                StaminaController.instance.SprintCost(1);
            }    
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)){
            //reset
            sprint = 1;
            isSprinting = false;
        }

        animator.SetBool("isSprinting", isSprinting);
        animator.SetInteger("movementX", (int)movement.x);
        animator.SetInteger("movementY", (int)movement.y);
        
        
        
    }

    public float getAngle()
    {
        return angle;
    }

}
