using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private float playerSpeed = 5.0f;
    private float gravityValue = -9.81f;

    [SerializeField] private SphereCollider detectionRange;
    

    [Header("Input Actions")]
    public InputAction moveAction;
    public InputAction collectAction;

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private PlayerInventory playerInventory;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        collectAction = InputSystem.actions.FindAction("Interact");
    }

    private void OnEnable()
    {
        moveAction.Enable();
        collectAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        collectAction.Disable();
    }

    void Update()
    {
        if (collectAction.WasCompletedThisFrame())
        {
            Collect();
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = Vector3.ClampMagnitude(move, 1f);

        rb.velocity = new Vector3(move.x * playerSpeed, gravityValue * Time.deltaTime * rb.velocity.y, move.z * playerSpeed);

        RotateTowardsMouse();
    }

    private void RotateTowardsMouse()
    {
        if (Camera.main == null || Mouse.current == null)
            return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        Plane groundPlane = new Plane(Vector3.up, transform.position);

        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 lookDirection = hitPoint - transform.position;
            lookDirection.y = 0f;

            if (lookDirection.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }
        }
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
