using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // El objeto del jugador que la cámara seguirá
    public float mouseSensitivity = 100f; // Sensibilidad del mouse

    private float xRotation = 0f;

    void Start()
    {
        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Obtener movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotar hacia arriba y hacia abajo (cámara)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotación vertical
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotar el jugador hacia los lados (horizontal)
        player.Rotate(Vector3.up * mouseX);
    }
}
