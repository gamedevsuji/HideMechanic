using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentDoor : MonoBehaviour
{
    [SerializeField] private Renderer doorRenderer;
    [SerializeField]private bool isOpen = false;
    [SerializeField] private Color closedColor;
    [SerializeField] private Color openColor;

    void Start()
    {
        // Get the Renderer component of the door
        doorRenderer = GetComponent < Renderer>();

        // Define the colors for open and closed states
        closedColor = doorRenderer.material.color;
        openColor = new Color(closedColor.r, closedColor.g, closedColor.b, 1f); // Fully opaque color
    }

    void Update()
    {
        // Check for input to open or close the door
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Transparent Mesh");
            isOpen = !isOpen;
            if (isOpen)
            {
                doorRenderer.material.color = openColor; // Set to fully opaque color when open
            }
            else
            {
                doorRenderer.material.color = new Color(closedColor.r, closedColor.g, closedColor.b, 0.5f); // Set to semi-transparent color when closed
            }
        }
    }
}
