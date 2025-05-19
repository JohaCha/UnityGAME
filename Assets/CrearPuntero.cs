using UnityEngine;
using UnityEngine.UI;

public class CrearPuntero : MonoBehaviour
{
    public Sprite punteroSprite; // Arrastra aquí tu imagen de punto desde el Inspector

    void Start()
    {
        // Crear Canvas
        GameObject canvasObj = new GameObject("PunteroCanvas");
        canvasObj.layer = LayerMask.NameToLayer("UI");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        // Crear Image
        GameObject punteroObj = new GameObject("Puntero");
        punteroObj.transform.SetParent(canvasObj.transform);

        Image punteroImage = punteroObj.AddComponent<Image>();
        punteroImage.sprite = punteroSprite;

        // Configurar tamaño y posición (centro de la pantalla)
        RectTransform rect = punteroImage.GetComponent<RectTransform>();
        rect.anchoredPosition = Vector2.zero;
        rect.sizeDelta = new Vector2(16, 16); // tamaño del punto
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.pivot = new Vector2(0.5f, 0.5f);
    }
}
