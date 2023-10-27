using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    public static GameInput Instance { get; private set; }

    public event EventHandler OnJump; 
    public event EventHandler OnPause; 

    private PlayerInput playerInput;

    private void Awake()
    {
        Instance = this;
        playerInput = new PlayerInput();
        playerInput.Enable();
        playerInput.Player.Jump.performed += Jump_performed;
        playerInput.Player.Pause.performed += Pause_performed;
    }

    private void OnDestroy()
    {
        playerInput.Player.Jump.performed -= Jump_performed;
        playerInput.Player.Pause.performed -= Pause_performed;
        playerInput.Disable();
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPause?.Invoke(this, EventArgs.Empty);
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJump?.Invoke(this, EventArgs.Empty);
    }
}
