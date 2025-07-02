using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTopDown : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Vector3 movePoint;

    public LayerMask whatStopsMovement;
    public string HorizontalInput = "Horizontal";
    public string VerticalInput = "Vertical";

    void Start()
    {
        movePoint = transform.position;
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint) <= .05f)

        {

            Vector3 newMovePosition = new Vector3(Input.GetAxisRaw(HorizontalInput), 0, Input.GetAxisRaw(VerticalInput));

            if (Mathf.Abs(newMovePosition.x) == 1f || Mathf.Abs(newMovePosition.z) == 1)
            {
                Collider[] colliding = Physics.OverlapSphere(movePoint + new Vector3(0.5f, 0.5f, 0.5f) + newMovePosition, .2f, whatStopsMovement);
               
                if (colliding.Length <= 0) //Nothing in our way. We can move
                {
                    movePoint += newMovePosition;
                }
                //else if something there.
                else 
                {
                    PushableObject pushableObject = colliding[0].GetComponent<PushableObject>();
                    if(pushableObject != null)
                    {
                        pushableObject.PushObject(newMovePosition);
                    }
                }
                //Check first item in collider to see if it is pushable.
                //If it is.
                //Give it a push

            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, movePoint);
    }

}
