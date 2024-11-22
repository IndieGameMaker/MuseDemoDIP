// 11/13/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

// InputHandler.cs
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }

    [SerializeField] private InputActionProperty moveAction;
    [SerializeField] private InputActionProperty lookAction;

    private void OnEnable()
    {
        moveAction.action.Enable();
        lookAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        lookAction.action.Disable();
    }

    private void Update()
    {
        MoveInput = moveAction.action.ReadValue<Vector2>();
        LookInput = lookAction.action.ReadValue<Vector2>();
    }
}