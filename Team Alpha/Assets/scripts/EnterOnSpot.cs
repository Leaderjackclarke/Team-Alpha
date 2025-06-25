using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterOnSpot : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform targetLocation; // Assign in the Inspector

    public float arrivalThreshold = 0.1f; // How close is close enough
    public GameObject pressEnterText; // Assign the UI Text element in the Inspector
    private bool hasReachedTarget = false;



    void Start()
    {
        // Ensure text object is initially hidden
        if (pressEnterText != null)
        {
            pressEnterText.SetActive(false);
        }
    }


    void Update()
    {
        if (!hasReachedTarget)
        {
            MoveTowardsTarget();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            
            // Handle the "Press Enter" action here. For example:
            Debug.Log("achived champ");
            // Add your desired action here, like loading a new scene,
            // changing game state, etc.
            pressEnterText.SetActive(false); //hide it
        }
    }


    void MoveTowardsTarget()
    {
       

        // Check if the player has reached the target location.
        if (Vector3.Distance(transform.position, targetLocation.position) < arrivalThreshold)
        {
            hasReachedTarget = true;
            if (pressEnterText != null)
            {
                pressEnterText.SetActive(true); // Show the text
            }

        }
    }


}