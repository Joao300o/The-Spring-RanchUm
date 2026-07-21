using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody playerPhysics;
    public InputAction playerMove;
    public float playerVelocity = 5f;
    public float rotationSpeed = 10f; // velocidade da rotação (quanto maior, mais rápido gira)
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
        // Movimento
        playerPhysics.linearVelocity = new Vector3(
            playerDirection.x * playerVelocity,
            playerPhysics.linearVelocity.y,
            playerDirection.y * playerVelocity
        );

        // Rotação
        Vector3 moveDir = new Vector3(playerDirection.x, 0f, playerDirection.y);
        if (moveDir.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            playerPhysics.rotation = Quaternion.Slerp(
                playerPhysics.rotation,
                targetRotation,
                rotationSpeed * Time.fixedDeltaTime
            );
        }
    }
}