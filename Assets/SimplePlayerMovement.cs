using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimplePlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 4.0f;
    public float runSpeed = 7.0f;          // Hold Left Shift to run
    public float jumpHeight = 1.2f;        // Set to 0 if you do not want jumping
    public float gravity = -20f;           // Stronger than real gravity feels better in games

    [Header("Mouse Look")]
    public Transform playerCamera;         // Drag your Camera here in the Inspector
    public float mouseSensitivity = 2.0f;
    public float maxLookAngle = 80f;

    private CharacterController controller;
    private float verticalVelocity;        // Y velocity (gravity/jump)
    private float cameraPitch = 0f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        // If you forgot to assign the camera, try to find it automatically
        if (playerCamera == null)
        {
            Camera cam = GetComponentInChildren<Camera>();
            if (cam != null) playerCamera = cam.transform;
        }
    }

    void Start()
    {
        // Lock the cursor so mouse look feels like a real FPS
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    private void HandleMouseLook()
    {
        if (playerCamera == null) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate player left/right
        transform.Rotate(Vector3.up * mouseX);

        // Rotate camera up/down (pitch)
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -maxLookAngle, maxLookAngle);
        playerCamera.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);

        // Press Esc to release mouse if needed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void HandleMovement()
    {
        // Ground check: if grounded and falling, keep a small downward force so we "stick" to slopes
        if (controller.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        }

        // Speed selection
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        // WASD input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Movement relative to where the player is facing
        Vector3 move = transform.right * x + transform.forward * z;
        move = Vector3.ClampMagnitude(move, 1f);

        // Jump (optional)
        if (jumpHeight > 0f && controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            // v = sqrt(h * -2g)
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        verticalVelocity += gravity * Time.deltaTime;

        // Final motion (horizontal + vertical)
        Vector3 velocity = move * speed;
        velocity.y = verticalVelocity;

        controller.Move(velocity * Time.deltaTime);
    }
}