using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerCamera;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        RotatePlayer(mouseX);

        RotateCamera(mouseY);
    }

    void RotatePlayer(float movement)
    {
        // Rotate player body
        var playerRotation = transform.rotation.eulerAngles;

        // Rotate player container Y axis
        playerRotation.y += movement;

        transform.rotation = Quaternion.Euler(playerRotation);
    }

    void RotateCamera(float movement)
    {
        var cameraRotation = playerCamera.transform.rotation.eulerAngles;

        // Since we have rotated the player container, only need to rotate X axis
        cameraRotation.x -= movement;

        playerCamera.transform.rotation = Quaternion.Euler(cameraRotation);
    }
}
