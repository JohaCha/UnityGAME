using System.Collections;
using UnityEngine;

public class UnirObjetosSinRigidbody : MonoBehaviour
{
    public GameObject esfera1, esfera2, esfera3;
    public GameObject cuadrado1, cuadrado2, cuadrado3;

    public Light[] luces;  // ← múltiples luces

    public float velocidad = 2f;

    private Vector3 posOriginal1, posOriginal2, posOriginal3;
    private bool unidos = false;

    void Start()
    {
        // Guardar posiciones originales
        posOriginal1 = esfera1.transform.position;
        posOriginal2 = esfera2.transform.position;
        posOriginal3 = esfera3.transform.position;

        // Apagar todas las luces al inicio
        foreach (Light l in luces)
        {
            if (l != null)
                l.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !unidos)
        {
            StartCoroutine(UnirEsferas());
        }
        else if (Input.GetKeyDown(KeyCode.R) && unidos)
        {
            StartCoroutine(SepararEsferas());
        }
    }

    IEnumerator UnirEsferas()
    {
        yield return StartCoroutine(MoverEsferaHacia(esfera1, cuadrado1.transform.position));
        yield return StartCoroutine(MoverEsferaHacia(esfera2, cuadrado2.transform.position));
        yield return StartCoroutine(MoverEsferaHacia(esfera3, cuadrado3.transform.position));

        if (EstanUnidos())
        {
            foreach (Light l in luces)
            {
                if (l != null)
                    l.enabled = true;
            }
        }

        unidos = true;
    }

    IEnumerator SepararEsferas()
    {
        yield return StartCoroutine(MoverEsferaHacia(esfera1, posOriginal1));
        yield return StartCoroutine(MoverEsferaHacia(esfera2, posOriginal2));
        yield return StartCoroutine(MoverEsferaHacia(esfera3, posOriginal3));

        foreach (Light l in luces)
        {
            if (l != null)
                l.enabled = false;
        }

        unidos = false;
    }

    IEnumerator MoverEsferaHacia(GameObject esfera, Vector3 destino)
    {
        float tiempo = 0f;
        Vector3 inicio = esfera.transform.position;

        while (tiempo < 1f)
        {
            tiempo += Time.deltaTime * velocidad;
            esfera.transform.position = Vector3.Lerp(inicio, destino, tiempo);
            yield return null;
        }
    }

    bool EstanUnidos()
    {
        return Vector3.Distance(esfera1.transform.position, cuadrado1.transform.position) < 0.1f &&
               Vector3.Distance(esfera2.transform.position, cuadrado2.transform.position) < 0.1f &&
               Vector3.Distance(esfera3.transform.position, cuadrado3.transform.position) < 0.1f;
    }
}
