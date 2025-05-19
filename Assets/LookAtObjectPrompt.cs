using UnityEngine;

public class LookAtObjectPrompt : MonoBehaviour
{
    public GameObject promptTextUI;       // El texto de UI que se muestra
    public float detectionDistance = 5f;  // Distancia máxima para detectar
    public LayerMask targetLayer;         // Capa de los objetos detectables

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, detectionDistance, targetLayer))
        {
            // Si apuntamos al objeto, mostramos el mensaje
            promptTextUI.SetActive(true);
        }
        else
        {
            // Si no, lo ocultamos
            promptTextUI.SetActive(false);
        }
    }
}
