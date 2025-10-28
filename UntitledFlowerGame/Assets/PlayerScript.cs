// This first example shows how to move using Input System Package (New)

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private float playerSpeed = 5.0f;
    private float gravityValue = -9.81f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer = false;
    [SerializeField] private SphereCollider detectionRange;

    [Header("Input Actions")]
    public InputAction moveAction; // expects Vector2
    public InputAction collectAction; // expects   

    [SerializeField] PlayerInventory playerInventory;
    
    private void Start() 
    {
        moveAction = InputSystem.actions.FindAction("Move");
        collectAction = InputSystem.actions.FindAction("Interact");
        controller = GetComponent<CharacterController>();
    }
    
    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (collectAction.WasPressedThisFrame())
        {
            Collect();
        }

        // Read input
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
    }

    private void Collect()
    {
        foreach (Collider collider in Physics.OverlapSphere(transform.position + detectionRange.center, detectionRange.radius))
        {
            if (collider.CompareTag("Collectible"))
            {
                CollectibleScript collectible = collider.gameObject.GetComponent<CollectibleScript>();

                playerInventory.AddCollectible(collectible.getCollectibleType());

                collectible.OnCollect();
            }
        }
    }
}