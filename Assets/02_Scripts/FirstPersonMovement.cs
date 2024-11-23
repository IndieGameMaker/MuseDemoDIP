// 11/23/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lookSpeed = 2f;
    [SerializeField] private float rotationSmoothing = 0.1f;

    private CharacterController characterController;
    private float verticalLookRotation;
    private Quaternion targetRotation;
    private Quaternion targetCameraRotation;

    private PlayerInputHandler inputHandler;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        inputHandler = GetComponent<PlayerInputHandler>();

        targetRotation = transform.rotation;
        targetCameraRotation = Camera.main.transform.localRotation;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        // Move player
        Vector2 moveInput = inputHandler.GetMoveInput();
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        // Rotate player
        Vector2 lookInput = inputHandler.GetLookInput();

        // Smooth rotation using Slerp
        targetRotation *= Quaternion.Euler(0f, lookInput.x * lookSpeed, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothing);

        verticalLookRotation -= lookInput.y * lookSpeed;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        targetCameraRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
        Camera.main.transform.localRotation = Quaternion.Slerp(Camera.main.transform.localRotation, targetCameraRotation, rotationSmoothing);
    }
}