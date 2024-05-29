using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float moveSpeed = 10f;

    private void Update()
    {
        if (virtualCamera != null)
        {
            // Get the transform of the virtual camera
            Transform cameraTransform = virtualCamera.transform;

            // Calculate movement direction based on WASD input
            Vector3 moveDirection = new Vector3();
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection += Vector3.forward;

                //Check if the camera is moving forward and it z position is greater than -20 then stop the camera moving forward...
                if (cameraTransform.position.z > -24)
                {
                    moveDirection = Vector3.zero;
                }

            }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection += Vector3.back;

                //Check if the camera is moving backward and it z position is greater that -25 then stop the camera moving backward...
                if (cameraTransform.position.z < -27)
                {
                    moveDirection = Vector3.zero;
                }


            }
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection += Vector3.left;

                //Check if the camera is moving left  and it x position is greater that -4 then stop the camera moving left...
                if (cameraTransform.position.x < -4)
                {
                    moveDirection = Vector3.zero;
                }


            }
            if (Input.GetKey(KeyCode.D))
            {
                moveDirection += Vector3.right;

                //Check if the camera is moving right  and it x position is greater that 10 then stop the camera moving right...
                if (cameraTransform.position.x > 5)
                {
                    moveDirection = Vector3.zero;
                }

            }

            // Normalize direction to prevent faster diagonal movement
            moveDirection.Normalize();

            // Move the camera
            cameraTransform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        else
        {
            Debug.LogError("Virtual Camera is not assigned.");
        }
    }
}
