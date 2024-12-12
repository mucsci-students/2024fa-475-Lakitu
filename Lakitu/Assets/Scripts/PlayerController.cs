using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    [Header("Mouse Look Settings")]
    public Transform cameraTransform;
    public float mouseSensitivity = .0001f;
    public bool invertMouseY = false;

    [Header("Teleport Settings")]
    public GameObject teleportTarget; // Reference to the invisible GameObject
    public KeyCode teleportKey = KeyCode.T; // Key to trigger teleport
    public float teleportCooldown = 5f; // Cooldown between teleports

    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float xRotation = 0f;
    private float teleportTimer;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Initialize teleport timer
        teleportTimer = teleportCooldown;
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
        HandleTeleport();
        UpdateTeleportTimer();
    }

    void HandleMovement()
    {
        // Check if the player is on the ground
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Ensure the player sticks to the ground
        }

        // Get movement input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Apply movement
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
        characterController.Move(move * currentSpeed * Time.deltaTime);

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust camera rotation
        xRotation -= mouseY * (invertMouseY ? -1 : 1);
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp vertical rotation

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleTeleport()
    {
        if (Input.GetKeyDown(teleportKey) && teleportTimer >= teleportCooldown)
        {
            Teleport(teleportTarget.transform.position, teleportTarget.transform.rotation);
            teleportTimer = 0f; // Reset the teleport timer
        }
    }

    void UpdateTeleportTimer()
    {
        if (teleportTimer < teleportCooldown)
        {
            teleportTimer += Time.deltaTime;
        }
    }

    public void Teleport(Vector3 targetPosition, Quaternion targetRotation)
    {
        // Set the player's position and orientation directly
        characterController.enabled = false; // Disable CharacterController temporarily
        transform.position = targetPosition;
        transform.rotation = targetRotation;

        // Rotate the player 180 degrees
        transform.Rotate(0f, 180f, 0f); // Turn the player 180 degrees

        characterController.enabled = true; // Re-enable CharacterController
    }
}
