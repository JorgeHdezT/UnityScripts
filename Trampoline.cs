using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 10f; // Fuerza de impulso del trampolín

    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si el objeto que colisiona es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtenemos el Rigidbody del jugador
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                // Reiniciamos la velocidad Y para asegurarnos de que no haya una velocidad descendente no deseada
                playerRb.velocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

                // Aplicamos un impulso hacia arriba para simular el trampolín
                playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }
        }
    }
}
