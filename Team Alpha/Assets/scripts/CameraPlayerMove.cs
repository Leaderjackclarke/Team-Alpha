using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CameraPlayerMove : MonoBehaviour
{
    public Vector2 minXAndY;
    public Vector2 maxXAndY;

    public float xMargin = 1f;
    public float yMargin = 1f;
    public float xSmooth = 4f;
    public float ySmooth = 4f;
    
    public Transform target;


   void LateUpdate()
    {
       float targetX= transform.localPosition.x;
        float targety = transform.localPosition.y;
        //if(CheckXMargin() ==true)
            targetX = Mathf.Lerp(transform.localPosition.x, target.localPosition.x, Time.deltaTime * xSmooth);

        // (CheckYMargin() == true)
            targety = Mathf.Lerp(transform.localPosition.y, target.localPosition.y, Time.deltaTime * ySmooth);
        targety = Mathf.Clamp(targety, minXAndY.y,minXAndY.y);
        //targetX = Mathf.Clamp(targetX, maxXAndY.x, maxXAndY.y);


        transform.localPosition = new Vector3(targetX,targety, transform.localPosition.z );
    }

    bool CheckXMargin()
    {
        return Mathf.Abs(transform.localPosition.x - transform.localPosition.x) > xMargin;
    }
    bool CheckYMargin()
    {
        return Mathf.Abs(transform.localPosition.y - transform.localPosition.y) > yMargin;
    }
   
}
