using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterOnSpot : MonoBehaviour
{
   
    public Transform targetLocation; 
    public float arrivalThreshold = 0.1f;
    public GameObject pressEnterText; 
    private bool hasReachedTarget = false;
  
    public GameObject LightSource;
    private bool ison = false;



    void Start()
    {
      
        if (pressEnterText != null)
        {
            pressEnterText.SetActive(false);
        }
       
        /*  if (arrivalThreshold != null)
          {
              pressEnterText.SetActive(false);
          }*/
    }


    void Update()
    {
        if (!hasReachedTarget)
        {
            MoveTowardsTarget();
        }
        else 
        if (Input.GetKeyDown(KeyCode.Return))
        {
         
            Debug.Log("achived champ");
            Toggchange();
            pressEnterText.SetActive(false); 
          
        }
      
    }
    void Toggchange ()
    {
        if (!ison)
        {
            lightOn();
        }
        else
        {
            lightOff();
        }
        void lightOff()
        {
            LightSource.SetActive(false);
            ison = false;
        }




    }
    void lightOn() {

        LightSource.SetActive(true);
        ison = true;
    }



    void MoveTowardsTarget()
    {
       

       
        if (Vector3.Distance(transform.position, targetLocation.position) < arrivalThreshold)
        {
            hasReachedTarget = true;
            if (pressEnterText != null)
            {
                pressEnterText.SetActive(true); 
            }   

            /* else 
                 hasReachedTarget = false;
             if (pressEnterText != null)
             {
                 pressEnterText.SetActive(false);
             }*/

        }
     
    }


}