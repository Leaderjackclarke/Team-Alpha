using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public Collision collision;

    public LayerMask whatStopsMovement;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }

    public void PushObject(Vector3 newMovePosition)
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(newMovePosition.x) == 1f || Mathf.Abs(newMovePosition.z) == 1)
            {
                if (Physics.OverlapSphere(movePoint.position + newMovePosition, .2f, whatStopsMovement).Length <= 0)
                {
                    movePoint.position += newMovePosition;
                }
            }
        }
    }
}
    
        
 
