using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController controller;
    [SerializeField] private Transform camera;
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float speedSmoothTime = 91f;
    [SerializeField] private float gravity = 5f;

    [Header("Input Settings")]
    private float hInput;
    private float vInput;
    private float speed;
    private float verticalVelocity;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleInput();
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(hInput, 0f, vInput);
        direction = camera.TransformDirection(direction);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = Mathf.Lerp(speed, runSpeed, speedSmoothTime * Time.deltaTime);
        }
        else
        {
            speed = Mathf.Lerp(speed, walkSpeed, speedSmoothTime * Time.deltaTime);
        }
        direction *= speed;
        direction.y = VerticalVelocity();
        
        controller.Move(direction * Time.deltaTime);
    }

    private void Rotate()
    {
        if (Mathf.Abs(hInput) != 0 || Mathf.Abs(vInput) != 0)
        {
            Vector3 targetDirection = controller.velocity.normalized;
            targetDirection.y = 0;
            targetDirection.Normalize();

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }

    private float VerticalVelocity()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        return verticalVelocity;
    }

    private void HandleInput()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }
}
