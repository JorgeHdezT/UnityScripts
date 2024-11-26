using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportDestination; // El destino del teletransporte

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra es el jugador
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga el tag "Player"
        {
            // Teletransportar al jugador
            other.transform.position = teleportDestination.position;
        }
    }
}