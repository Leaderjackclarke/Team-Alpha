using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropener : MonoBehaviour
{
	Animator anim;
	
    // Start is called before the first frame update
    void Start()
    {
			anim = GetComponent<Animator>();
    }
	

    public void OpenDoor()
	{
		anim.SetBool("DoorOpen", true);
	}
	
	 public void CloseDoor()
	{
		anim.SetBool("DoorOpen", false);
	}
}
