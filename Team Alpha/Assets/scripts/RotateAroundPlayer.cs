using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPlayer : MonoBehaviour
{
    public float degreesToRotate = 90;
    public void StartRotation()
    {
        RotateManager.instance.RotateAroundPlayerDegs(degreesToRotate);
    }
}
