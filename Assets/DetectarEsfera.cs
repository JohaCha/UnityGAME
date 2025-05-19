using UnityEngine;

public class DetectarEsfera : MonoBehaviour
{
    public float distancia = 5f;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, distancia))
        {
            if (hit.collider.CompareTag("Esfera"))
            {
                Debug.Log("Estás mirando la esfera");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Presionaste E sobre la esfera");
                    // Aquí puedes hacer que cambie de color, se conecte, etc.
                }
            }
        }
    }
}
