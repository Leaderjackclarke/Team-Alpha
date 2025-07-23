using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnterOnSpot : MonoBehaviour
{
    public GameObject pressEnterText;

    [SerializeField] bool activated = false;

    [SerializeField] private UnityEvent spotActivate;
    [SerializeField] private UnityEvent spotDeactivated;

    [SerializeField] private CharacterType acceptedCharacterType = CharacterType.SideScroller;

    public CharacterType AcceptedCharacterType { get { return acceptedCharacterType; } }

    bool inArea = false;

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
        if (inArea == true && Input.GetKeyDown(KeyCode.Return))
        {

            Debug.Log("achived champ");
            //Toggchange();
            pressEnterText.SetActive(false);
            //ChangeScene(sceneChanger);

            //Toggle
            activated = !activated;

            if(activated == true)
            {
                spotActivate?.Invoke();
            }
            else
            {
                spotDeactivated?.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (acceptedCharacterType == CharacterType.SideScroller)
        {
            PlayerControllerSideScroller pss = other.GetComponent<PlayerControllerSideScroller>();
            if (pss != null)
            {
                inArea = true;
                pressEnterText.SetActive(true);
            }
        }
        else if(acceptedCharacterType == CharacterType.Topdown)
        {
            PlayerControllerTopDown ptd = other.GetComponent<PlayerControllerTopDown>();
            if (ptd != null)
            {
                inArea = true;
                pressEnterText.SetActive(true);
            }
        }
    }

    //TODO: Fix bugs
    private void OnTriggerExit(Collider other)
    {
        inArea = false;
        pressEnterText.SetActive(false);
    }
}

//To redistubute into smaller self contained scripts
class OldCode : MonoBehaviour
{
    public GameObject LightSource;
    private bool ison = false;
    public string sceneChanger;

    private bool hasReachedTarget = false;
    public Transform targetLocation;
    public float arrivalThreshold = 0.1f;

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
    }

    void lightOff()
    {
        LightSource.SetActive(false);
        ison = false;
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
            //if (pressEnterText != null)
            //{
            //    pressEnterText.SetActive(true); 
            //}

            /* else 
                 hasReachedTarget = false;
             if (pressEnterText != null)
             {
                 pressEnterText.SetActive(false);
             }*/
        }
     
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}