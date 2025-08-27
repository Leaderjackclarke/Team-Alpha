using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector3 movePoint;
    public Collision collision;

    public LayerMask whatStopsMovement;

    // Start is called before the first frame update
    void Start()
    {
        movePoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint, moveSpeed * Time.deltaTime);
    }

    public void PushObject(Vector3 newMovePosition)
    {
        Debug.Log("Push");
        if (Vector3.Distance(transform.position, movePoint) <= .05f)
        {
            if (Mathf.Abs(newMovePosition.x) == 1f || Mathf.Abs(newMovePosition.z) == 1)
            {
                if (Physics.OverlapSphere(movePoint + newMovePosition, .2f, whatStopsMovement).Length <= 0)
                {
                    movePoint += newMovePosition;
                }
            }
        }
    }


}
    
        
 
