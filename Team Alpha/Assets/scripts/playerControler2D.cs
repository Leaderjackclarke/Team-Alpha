using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler2D : MonoBehaviour
{
   

   
    public float MovementSpeed = 2.0f;
    public float jumpSpeed = 1f;
    public float groundRadiusCheck = 0.3f;
    public LayerMask layers;
    bool faceRight = false;
    //SpriteRenderer characterSprite;
    //Animator anim;

    Rigidbody rb;
    float moveInput;
    bool jumpInput = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //characterSprite = GetComponentInChildren<SpriteRenderer>();
        //anim = GetComponent<Animator>();
    }
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");


        //add coyote time speak to tom.
        jumpInput = Input.GetButton("Jump");

        if (rb.velocity.y < 0)
      

        if (moveInput < 0)
            faceRight = false;
        else if (moveInput > 0)
            faceRight = true;



        // characterSprite.flipX = faceRight;

    }
    public bool onGround;
    private void FixedUpdate()
    {
        Vector2 vel = rb.velocity;
        vel.x = moveInput * MovementSpeed;
        onGround = GroundCheck();
        /* rb.velocity = vel*/
        

        if (jumpInput == true  && onGround == true )
        {
            vel.y = jumpSpeed;
        }
        rb.velocity = vel;
    }

    bool GroundCheck()
    {
        RaycastHit hitInfo;


        return Physics.OverlapSphere(transform.position, groundRadiusCheck, layers).Length > 0;

        //Collider3D hitCollider = Physics2D.OverlapCircle(transform.position, groundRadiusCheck, layers);
        //return hitCollider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, groundRadiusCheck);
    }

}





 
