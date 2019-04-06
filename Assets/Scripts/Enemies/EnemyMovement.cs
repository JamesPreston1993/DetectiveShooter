using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 4.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    private MovementNode movementNode;
    private Transform movementTransform;
    private float distanceTolerance = 0.125f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        var distance = (movementTransform.position - transform.position).magnitude;
        if (distance < distanceTolerance)
        {
            SetMovementNode(movementNode.PickRandomNextNode());
            return;
        }

        if (controller.isGrounded)
        {
            // Calculate movement
            moveDirection = Vector3.forward;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            // Calculate direction
            var rotation = Quaternion.LookRotation(movementTransform.position - transform.position);
            rotation.x = rotation.z = 0;
            transform.rotation = rotation;
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void SetMovementNode(GameObject node)
    {
        movementNode = node.GetComponent<MovementNode>();
        movementTransform = node.transform;
    }
}
