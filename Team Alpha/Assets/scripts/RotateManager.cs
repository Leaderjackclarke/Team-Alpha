using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    [SerializeField] PlayerControllerSideScroller player;
    [SerializeField] Camera sideScrollCamera;

    public static RotateManager instance;

    private void Awake()
    {
        instance = this;
    }


    public void RotateAroundPlayerDegs(float degreesToRotate)
    {
        player.transform.parent = null;
        sideScrollCamera.transform.parent = null;
        //Moving to point to rotate around
        transform.position = player.transform.position;
         
        //Connection things that we want to rotate
        player.transform.parent = transform;
        sideScrollCamera.transform.parent = transform;

        //Rotate
        transform.Rotate(0, degreesToRotate,0);

    }


    public void RotateCharacterAroundPoint(Transform rotatePoint)
    {
        player.transform.parent = null;
        sideScrollCamera.transform.parent = null;
        //Moving to point to rotate around
        transform.position = rotatePoint.position;
 
        //Connection things that we want to rotate
        player.transform.parent = transform;
        sideScrollCamera.transform.parent = transform;

        //Rotate
        transform.rotation = rotatePoint.rotation;


    }




}
