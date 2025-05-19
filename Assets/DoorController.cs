using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorTransform; // Objeto de la puerta (el GameObject con bisagra)
    public float openAngle = 130f;   // Ángulo de apertura
    public float openSpeed = 2f;    // Velocidad de apertura
    public bool isOpen = false;     // Estado de la puerta

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = doorTransform.rotation;
        openRotation = doorTransform.rotation * Quaternion.Euler(openAngle, 0, 0);
    }

    void Update()
    {
        // Rotación suave
        if (isOpen)
            doorTransform.rotation = Quaternion.Slerp(doorTransform.rotation, openRotation, Time.deltaTime * openSpeed);
        else
            doorTransform.rotation = Quaternion.Slerp(doorTransform.rotation, closedRotation, Time.deltaTime * openSpeed);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
}
