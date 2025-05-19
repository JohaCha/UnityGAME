using System.Collections;  // Asegúrate de incluir esto
using UnityEngine;

public class UnirObjeto3 : MonoBehaviour
{
    public GameObject objeto1;  // El primer objeto
    public GameObject objeto2;  // El segundo objeto
    public float velocidad = 2f;  // Velocidad de movimiento para unir los objetos

    private bool unidos = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && !unidos)
        {
            Unir();
        }
    }

    void Unir()
    {
        // Mover objeto1 hacia objeto2
        StartCoroutine(MoverObjetos());
    }

    IEnumerator MoverObjetos()
    {
        float tiempo = 0f;
        Vector3 posicionInicial = objeto1.transform.position;
        Vector3 posicionFinal = objeto2.transform.position;

        while (tiempo < 1f)
        {
            tiempo += Time.deltaTime * velocidad;
            objeto1.transform.position = Vector3.Lerp(posicionInicial, posicionFinal, tiempo);
            yield return null;
        }

        // Una vez que el objeto1 ha llegado a la posición de objeto2, los consideramos unidos
        unidos = true;
        Debug.Log("Objetos unidos");
    }
}
