using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePoint : MonoBehaviour
{
    public void StartRotation()
    {
        RotateManager.instance.RotateCharacterAroundPoint(transform);
    }
}
