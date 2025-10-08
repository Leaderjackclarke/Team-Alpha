using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    [SerializeField] PlayerControllerSideScroller player;
    [SerializeField] Transform sideScrollCamera;

    public static RotateManager instance;

    Vector3 cameraStartingPoint;


    private void Awake()
    {
        instance = this;
        cameraStartingPoint = sideScrollCamera.transform.localPosition;
    }


    public void RotateAroundPlayerDegs(float degreesToRotate, Transform cameraNewPos)
    {
        player.transform.parent = null;
        sideScrollCamera.parent = null;

        sideScrollCamera.localPosition = cameraStartingPoint;


        //Moving to point to rotate around
        transform.position = player.transform.position;
         
        //Connection things that we want to rotate
        player.transform.parent = transform;
        sideScrollCamera.parent = transform;

        //Rotate
        transform.Rotate(0, degreesToRotate,0);

        if (cameraNewPos != null)
        {
            sideScrollCamera.position = cameraNewPos.position;
        }


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
