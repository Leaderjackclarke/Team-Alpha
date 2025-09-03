using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControllerSideScroller : MonoBehaviour
{
    public float MovementSpeed = 2.0f;
    public float jumpSpeed = 1f;
   public float groundRadiusCheck = 0.3f;
    private float Direction = 0f;
    public LayerMask layers;
    bool faceRight = false;
    //SpriteRenderer characterSprite;
    //Animator anim;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    public string HorizontalInput = "Horizontal";
   public string JumpInput = "Jump";

    [SerializeField] private CharacterType characterType = CharacterType.SideScroller;

    public CharacterType CharacterType { get { return characterType; } }


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
       Direction = Input.GetAxis("Horizontal");

        if (Direction > 0f)
        {
            rb.velocity = new Vector2(Direction * MovementSpeed, rb.velocity.y);
        }
        else if (Direction < 0f)
        {
            rb.velocity = new Vector2(Direction * MovementSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        //if (jumpInput = Input.GetButton("Jump"))
        if (Input.GetButtonDown("Jump"))
        {
             rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
        }

     //jumpInput = Input.GetAxis(HorizontalInput);

     //add coyote time speak to tom.
     jumpInput = Input.GetButton(JumpInput);



     /*if (rb.velocity.y  < 0)

     if (moveInput < 0)
         faceRight = false;
     else if (moveInput > 0)
         faceRight = true;*/
        // characterSprite.flipX = faceRight;

    }

    public bool onGround;

    private void FixedUpdate()
    {
       
        Vector3 vel = rb.velocity + transform.right * moveInput * MovementSpeed * Time.deltaTime;
      
        onGround = GroundCheck();
        /* rb.velocity = vel*/
        
        if (jumpInput == true  && onGround == true )
        {
            vel.y = jumpSpeed;
        }

        //TODO make jumping more marioesk
        if(onGround== false && vel.y < 1)
        {
            vel += Vector3.down * 1.3f;
        }

        Vector3 worldVector = transform.parent.transform.TransformVector(vel);

        rb.velocity = worldVector;
    }


    bool GroundCheck()
    {
        //  RaycastHit hitInfo;
        return Physics.OverlapSphere(transform.position, groundRadiusCheck, layers).Length > 0;

        //Collider3D hitCollider = Physics2D.OverlapCircle(transform.position, groundRadiusCheck, layers);
       // return hitCollider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.localPosition, groundRadiusCheck);
    }

}

public enum CharacterType
{
    SideScroller,
    Topdown
}





 
