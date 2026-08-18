using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody playerPhysics;
    public InputAction playerMove;
    public float playerVelocity = 5f;
    public float rotationSpeed = 10f;
    Vector2 playerDirection;

    private void OnEnable()
    {
        playerMove.Enable();
    }

    private void OnDisable()
    {
        playerMove.Disable();
    }

    void Start()
    {
        playerPhysics = GetComponent<Rigidbody>();
    }

    void Update()
    {
        playerDirection = playerMove.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(playerDirection.x, 0, playerDirection.y);
        playerPhysics.linearVelocity = new Vector3(
            playerDirection.x * playerVelocity,
            playerPhysics.linearVelocity.y,
            playerDirection.y * playerVelocity
        );
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(
             transform.rotation,
             targetRotation,
             rotationSpeed * Time.fixedDeltaTime);
        }

    }
}