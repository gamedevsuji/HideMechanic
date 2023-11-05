using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBox : MonoBehaviour
{

    [SerializeField] private GameObject screamUI;

    [SerializeField] private DoorInteract doorInteract;


    private void Start()
    {
        screamUI.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {

        MovementController playerController = other.gameObject.GetComponent<MovementController>();

        if (playerController != null)
        {

            EnableHideUI();

        }
    }


    private void EnableHideUI()
    {
        
        screamUI.SetActive(doorInteract.closeCompleted);
       
    }
}
