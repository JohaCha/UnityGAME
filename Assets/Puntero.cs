using UnityEngine;

public class Puntero : MonoBehaviour
{
    public float distancia = 5f;  // Distancia a la que debe estar el puntero
    public Camera playerCamera;   // C�mara del jugador

    void Update()
    {
        if (playerCamera != null)
        {
            // Hacer que el puntero se mueva hacia donde est� mirando la c�mara
            Vector3 targetPosition = playerCamera.transform.position + playerCamera.transform.forward * distancia;
            transform.position = targetPosition;
        }
    }
}
