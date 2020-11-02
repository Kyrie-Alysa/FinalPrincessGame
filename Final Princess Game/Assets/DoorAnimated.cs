using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DoorAnimated : MonoBehaviour, IDoor
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        animator.SetBool("Open", true);
    }
    public void CloseDoor()
    {
        animator.SetBool("Open", false);
    }
    public void ToggleDoor()
    {
        throw new System.NotImplementedException();
    }
}
