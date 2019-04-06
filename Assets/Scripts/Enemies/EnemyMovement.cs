using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 4.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = Vector3.forward;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}
