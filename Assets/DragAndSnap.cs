using UnityEngine;
using UnityEngine.UI;

public class DragAndSnap : MonoBehaviour
{
    private Camera cam;
    private bool isDragging = false;
    private Vector3 offset;
    private Rigidbody rb;

    public float snapDistance = 1.0f;
    public Transform snapTarget;
    private bool isSnapped = false;

    public Text mensajeText; // ← arrastrar el objeto de UI aquí en el Inspector

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void OnMouseDown()
    {
        isDragging = true;

        if (isSnapped)
        {
            isSnapped = false;
            rb.constraints = RigidbodyConstraints.None;
        }

        rb.isKinematic = true;
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseUp()
    {
        isDragging = false;
        rb.isKinematic = false;

        if (Vector3.Distance(transform.position, snapTarget.position) < snapDistance)
        {
            SnapToTarget();
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 targetPos = GetMouseWorldPos() + offset;
            transform.position = targetPos;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if (plane.Raycast(ray, out distance))
            return ray.GetPoint(distance);
        return transform.position;
    }

    void SnapToTarget()
    {
        transform.position = snapTarget.position;
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        isSnapped = true;

        if (mensajeText != null)
        {
            mensajeText.text = "Conexión a tierra exitosa";
            Invoke("LimpiarMensaje", 2f); // limpiar luego de 2 segundos
        }
    }

    void LimpiarMensaje()
    {
        if (mensajeText != null)
            mensajeText.text = "";
    }
}
