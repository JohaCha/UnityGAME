using UnityEngine;

public class DoorInteractor : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask doorLayer;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, doorLayer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorController door = hit.collider.GetComponent<DoorController>();
                if (door != null)
                {
                    door.ToggleDoor();
                }
            }
        }
    }
}
