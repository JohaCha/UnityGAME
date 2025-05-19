using UnityEngine;
using UnityEngine.UI;

public class InteractPrompt : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask interactLayer;
    public GameObject promptUI; // Asigna el objeto del texto aqu�

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactLayer))
        {
            promptUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Aqu� llamas al m�todo de apertura
                Debug.Log("Interacci�n: abrir objeto");
            }
        }
        else
        {
            promptUI.SetActive(false);
        }
    }
}
