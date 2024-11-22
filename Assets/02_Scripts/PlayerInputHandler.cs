// 11/22/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using System;
using UnityEditor;
using UnityEngine;
using InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Player.Enable();
        playerInput.Player.Move.performed += OnMove;
        playerInput.Player.Look.performed += OnLook;

        playerInput.Player.Move.canceled += ctx => MoveInput = Vector2.zero;
        playerInput.Player.Look.canceled += ctx => LookInput = Vector2.zero;
    }

    private void OnDisable()
    {
        playerInput.Player.Move.performed -= OnMove;
        playerInput.Player.Look.performed -= OnLook;
        playerInput.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        LookInput = context.ReadValue<Vector2>();
    }
}
