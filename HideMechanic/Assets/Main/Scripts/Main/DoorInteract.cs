using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour, InteractBase
{
    private Animator doorAnimator;
    private bool completed = true;

    private const string interactAnimation = "Interact";

    private int interact;

    private void Awake()
    {
        doorAnimator = GetComponent<Animator>();
        interact = Animator.StringToHash(interactAnimation);

    }

    public void InteractComplete()
    {
        completed = true;

    }

    public void InteractReceived()
    {

        if(completed)
        {
            doorAnimator.SetTrigger(interact);
            completed = false;
        }

        Debug.Log("Open the Door");
    }
}
