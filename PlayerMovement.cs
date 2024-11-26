using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables públicas configurables desde el Inspector
    public float speed = 5f;
    public float runSpeed = 8f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Variables privadas
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Referencia al Rigidbody
        rb = GetComponent<Rigidbody>();

        // Bloquear la rotación en el Rigidbody
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        // Movimiento horizontal
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Comprobar si está corriendo
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;
        rb.velocity = new Vector3(move.x * currentSpeed, rb.velocity.y, move.z * currentSpeed);

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        // Verificar si está en el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
    }
}
