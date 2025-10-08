using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerControllerTopDown topDown = other.GetComponent<PlayerControllerTopDown>();

        if(topDown != null )
        {
            MainGameManager.Instance.LoadNextLevel();
        }
    }
}
