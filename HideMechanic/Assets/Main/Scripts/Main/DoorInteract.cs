using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour, InteractBase
{
    [SerializeField]private Animator doorAnimator;
    private bool completed = true;
    [SerializeField]private bool opened = false;

    private const string interactAnimation = "Interact";

    private int interact;

    private void Awake()
    {
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
