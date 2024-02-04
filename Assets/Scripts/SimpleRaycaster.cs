using UnityEngine;

public class SimpleRaycaster : MonoBehaviour
{
    public PadBottomHandler padBottomHandler;
    public float maxDistance = 100.0f;
    public LayerMask interactableLayer;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, interactableLayer))
        {
            padBottomHandler.selectedObject = hit.collider.gameObject;
        }
        else
        {
            padBottomHandler.selectedObject = null;
        }
    }
}
