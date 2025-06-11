using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler2D : MonoBehaviour
{
    public float MovementSpeed = 2.0f;
    public float jumpSpeed = 4f;
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
        rb= GetComponent<Rigidbody>();
        //characterSprite = GetComponentInChildren<SpriteRenderer>();
        //anim = GetComponent<Animator>();
    }
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetButton("Jump");

        //if(Input.GetButtonDown("Fire1"))
        //{
        //    anim.SetTrigger("Attack");
        //}

        if (moveInput < 0)
            faceRight = false;
        else if (moveInput > 0 )
                faceRight = true;

       // characterSprite.flipX = faceRight;

    }

    private void FixedUpdate()
    {
        Vector2 vel = rb.velocity;
        vel.x = moveInput * MovementSpeed;
        bool onGround = GroundCheck();
       /* rb.velocity = vel*/
        if(jumpInput == true /* && onGround == true*/ ) 
        { vel.y = jumpSpeed; 
        }
        rb.velocity = vel;
    }

    bool GroundCheck()
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, groundRadiusCheck, layers);
        return hitCollider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, groundRadiusCheck);
    }

    /*void SetupLives()
    {
        for ( int i = 0; i < lives; i++ ) 
        {

            HealthBar.Instance.AddLife();
        }
    */





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
}
