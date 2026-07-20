using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody playerPhysics;
    public InputAction playerMove;
    public float playerVelocity = 5f;
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
        playerPhysics.linearVelocity = new Vector3(
            playerDirection.x * playerVelocity,
            playerPhysics.linearVelocity.y,
            playerDirection.y * playerVelocity
        );
    }
}