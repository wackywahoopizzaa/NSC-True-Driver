using UnityEngine;

public class FirstPersonCarCamera : MonoBehaviour
{
    public Transform cameraTransform;   // Assign the camera (child of this object)
    public float mouseSensitivity = 3f;
    public float minPitch = -60f;
    public float maxPitch = 60f;

    private float pitch = 0f;
    private bool isRotating = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        // Start rotating on RMB down
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Stop rotating on RMB up
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Only rotate when RMB is held
        if (isRotating)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // Horizontal (yaw) — rotate the pivot
            transform.Rotate(Vector3.up * mouseX);

            // Vertical (pitch) — camera only
            pitch -= mouseY;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
            cameraTransform.localEulerAngles = new Vector3(pitch, 0f, 0f);
        }
    }
}
