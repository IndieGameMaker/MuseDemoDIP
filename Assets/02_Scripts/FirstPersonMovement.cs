// 11/12/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;

    public InputActionProperty moveAction;
    public InputActionProperty lookAction;

    private CharacterController characterController;
    private float verticalLookRotation;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
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

    private void Update()
    {
        // Move player
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // Look around
        Vector2 lookInput = lookAction.action.ReadValue<Vector2>();
        transform.Rotate(Vector3.up * lookInput.x * lookSpeed);
        verticalLookRotation -= lookInput.y * lookSpeed;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        Camera.main.transform.localEulerAngles = Vector3.right * verticalLookRotation;
    }
}