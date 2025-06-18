using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTopDown : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;
    public string HorizontalInput = "Horizontal";
    public string VerticalInput = "Vertical";

    void Start()
    {
        movePoint.parent = null;
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw(HorizontalInput)) == 1f)
            {
                if (Physics.OverlapSphere(movePoint.position + new Vector3(0.5f,0,0.5f) + new Vector3(Input.GetAxisRaw(HorizontalInput), 0f, 0f), .2f, whatStopsMovement).Length <= 0)
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw(HorizontalInput), 0f, 0f);
                }
                
            }

            if (Mathf.Abs(Input.GetAxisRaw(VerticalInput)) == 1f)
            {
                if (Physics.OverlapSphere(movePoint.position + new Vector3(0.5f, 0, 0.5f) + new Vector3(0f, 0f, Input.GetAxisRaw(VerticalInput)), .2f, whatStopsMovement).Length <= 0)
                {
                    movePoint.position += new Vector3(0f, 0f, Input.GetAxisRaw(VerticalInput));
                }

        
            }
        }

    }
}
