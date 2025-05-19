using UnityEngine;

public class Puntero : MonoBehaviour
{
    public float distancia = 5f;  // Distancia a la que debe estar el puntero
    public Camera playerCamera;   // Cámara del jugador

    void Update()
    {
        if (playerCamera != null)
        {
            // Hacer que el puntero se mueva hacia donde está mirando la cámara
            Vector3 targetPosition = playerCamera.transform.position + playerCamera.transform.forward * distancia;
            transform.position = targetPosition;
        }
    }
}
