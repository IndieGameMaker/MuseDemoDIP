// 11/23/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private InputActionProperty moveAction;
    [SerializeField] private InputActionProperty lookAction;

    public Vector2 GetMoveInput()
    {
        return moveAction.action.ReadValue<Vector2>();
    }

    public Vector2 GetLookInput()
    {
        return lookAction.action.ReadValue<Vector2>();
    }

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
}