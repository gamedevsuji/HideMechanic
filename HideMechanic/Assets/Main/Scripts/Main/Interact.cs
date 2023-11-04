using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float rayLength =2;

    private bool clicked = false;

    [SerializeField] private GameObject interactUI;

    private void Start()
    {
        interactUI.SetActive(false);
        //layerMask = ~layerMask;
    }

    void FixedUpdate()
    {

        // Bit shift the index of the layer (8) to get a bit mask
        //int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.

        RaycastHit hit;

       
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength, layerMask))
        {
            interactUI.SetActive(true);

            if (InputController.instance.GetInteract() && !clicked)
            {
                clicked = true;


                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
                Debug.Log("Did Hit " + hit.transform.gameObject.name);

                InteractBase interactObject = hit.transform.GetComponent<InteractBase>();

                if (interactObject != null)
                {
                    interactObject.InteractReceived();
                }
            }
            else if (!InputController.instance.GetInteract())
            {
                clicked = false;

            }
        }
        else
        {
            interactUI.SetActive(false);

            //Debug.DrawRay(transform.position, transform.forward * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
        
        
    }
}
