using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoSingleton<InputController>
{

    [SerializeField]private PlayerInput playerInput;
    [SerializeField] private Controls controls;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private bool interactInput;

    public Vector2 GetPlayerMovement() => moveInput;
    public Vector2 GetLook() => lookInput;


    private void Awake() => controls = new Controls();

    private void OnEnable() 
    { 
        controls.Gameplay.Move.Enable();
        controls.Gameplay.Look.Enable();
        controls.Gameplay.Interact.Enable();


        controls.Gameplay.Move.started += OnMovementInput;
        controls.Gameplay.Move.performed += OnMovementInput;
        controls.Gameplay.Move.canceled += OnMovementInput;

        controls.Gameplay.Look.started += OnLookInput;
        controls.Gameplay.Look.performed += OnLookInput;
        controls.Gameplay.Look.canceled += OnLookInput;

        controls.Gameplay.Interact.started += OnInteractInput;
        controls.Gameplay.Interact.canceled += OnInteractInput;

    }

    private void OnDisable() 
    {
        controls.Gameplay.Move.Disable();
        controls.Gameplay.Look.Disable();
        controls.Gameplay.Interact.Disable();


        controls.Gameplay.Move.started -= OnMovementInput;
        controls.Gameplay.Move.performed -= OnMovementInput;
        controls.Gameplay.Move.canceled -= OnMovementInput;

        controls.Gameplay.Look.started -= OnLookInput;
        controls.Gameplay.Look.performed -= OnLookInput;
        controls.Gameplay.Look.canceled -= OnLookInput;

        controls.Gameplay.Interact.started -= OnInteractInput;
        controls.Gameplay.Interact.canceled -= OnInteractInput;
    }

    private void OnMovementInput(InputAction.CallbackContext context) => moveInput = context.ReadValue<Vector2>();
    private void OnLookInput(InputAction.CallbackContext context) => lookInput = context.ReadValue<Vector2>();
    private void OnInteractInput(InputAction.CallbackContext context) => interactInput = context.ReadValue<bool>();


}
