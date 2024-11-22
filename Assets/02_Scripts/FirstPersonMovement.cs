// 11/22/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
    // 플레이어 이동 속도
    [SerializeField] private float speed = 5.0f;

    // 마우스 감도 설정
    [SerializeField] private float mouseSensitivity = 100.0f;

    // 이동 및 시야 회전을 위한 InputActionProperty
    [SerializeField] private InputActionProperty moveAction;
    [SerializeField] private InputActionProperty lookAction;

    private CharacterController characterController; // 플레이어의 캐릭터 컨트롤러
    private Vector2 movementInput; // 이동 입력 벡터
    private Vector2 lookInput; // 시야 회전 입력 벡터
    private float xRotation = 0f; // 카메라의 X축 회전 값

    void Awake()
    {
        // CharacterController 컴포넌트 가져오기
        characterController = GetComponent<CharacterController>();

        // 이동 및 시야 회전 액션에 이벤트 핸들러 등록
        moveAction.action.performed += OnMovePerformed;
        moveAction.action.canceled += OnMoveCanceled;
        lookAction.action.performed += OnLookPerformed;
        lookAction.action.canceled += OnLookCanceled;
    }

    void OnEnable()
    {
        // 액션 활성화
        moveAction.action.Enable();
        lookAction.action.Enable();
    }

    void OnDisable()
    {
        // 액션 비활성화
        moveAction.action.Disable();
        lookAction.action.Disable();
    }

    void Update()
    {
        // 매 프레임마다 이동 및 시야 회전 처리
        Move();
        Look();
    }

    // 이동 입력 발생 시 호출되는 메소드
    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>(); // 2D 벡터 형태로 이동 입력 받기
    }

    // 이동 입력 취소 시 호출되는 메소드
    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        movementInput = Vector2.zero; // 이동 입력 벡터를 초기화
    }

    // 시야 회전 입력 발생 시 호출되는 메소드
    private void OnLookPerformed(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>(); // 2D 벡터 형태로 시야 회전 입력 받기
    }

    // 시야 회전 입력 취소 시 호출되는 메소드
    private void OnLookCanceled(InputAction.CallbackContext context)
    {
        lookInput = Vector2.zero; // 시야 회전 입력 벡터를 초기화
    }

    // 플레이어 이동 처리
    private void Move()
    {
        // 입력 벡터를 바탕으로 이동 방향 계산
        Vector3 move = transform.right * movementInput.x + transform.forward * movementInput.y;

        // CharacterController를 사용하여 이동
        characterController.Move(move * speed * Time.deltaTime);
    }

    // 플레이어 시야 회전 처리
    private void Look()
    {
        // 마우스 입력을 바탕으로 회전 값 계산
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        // X축 회전 값 갱신 및 제한
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 로컬 회전 설정 (카메라 피치)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 부모 오브젝트 회전 (캐릭터 요)
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
