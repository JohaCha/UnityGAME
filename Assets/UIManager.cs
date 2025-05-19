using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text mensajeText;

    public void MostrarMensaje(string mensaje, float duracion = 2f)
    {
        StopAllCoroutines();
        StartCoroutine(MostrarTemporalmente(mensaje, duracion));
    }

    private System.Collections.IEnumerator MostrarTemporalmente(string mensaje, float duracion)
    {
        mensajeText.text = mensaje;
        yield return new WaitForSeconds(duracion);
        mensajeText.text = "";
    }
}

