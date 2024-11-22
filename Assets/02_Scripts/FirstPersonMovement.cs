// 11/13/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

// FirstPersonMovement.cs
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lookSpeed = 2f;
    [SerializeField] private float rotationSmoothing = 0.1f;

    private CharacterController characterController;
    private PlayerInputHandler inputHandler;
    private float verticalLookRotation;
    private Quaternion targetRotation;
    private Quaternion targetCameraRotation;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        inputHandler = GetComponent<PlayerInputHandler>();
        targetRotation = transform.rotation;
        targetCameraRotation = Camera.main.transform.localRotation;
    }

    private void Update()
    {
        // Move player
        Vector3 move = transform.right * inputHandler.MoveInput.x + transform.forward * inputHandler.MoveInput.y;
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // Smooth rotation using Slerp
        targetRotation *= Quaternion.Euler(0f, inputHandler.LookInput.x * lookSpeed, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothing);

        verticalLookRotation -= inputHandler.LookInput.y * lookSpeed;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        targetCameraRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
        Camera.main.transform.localRotation = Quaternion.Slerp(Camera.main.transform.localRotation, targetCameraRotation, rotationSmoothing);
    }
}