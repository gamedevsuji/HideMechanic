using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour, InteractBase
{
    [SerializeField]private Animator doorAnimator;
    private bool completed = true;
    private bool opened = false;

    public bool closeCompleted;

    private const string interactAnimation = "Interact";


    

    private int interact;


    private void Awake()
    {
        interact = Animator.StringToHash(interactAnimation);
    }

    public void InteractComplete()
    {
        closeCompleted = !opened;
        completed = true;
    }


    public void InteractReceived()
    {
        if(completed)
        {
            if (!opened) opened = true;
            else opened = false;


            doorAnimator.SetTrigger(interact);
            completed = false;
        }

        Debug.Log("Open the Door");
    }
}
