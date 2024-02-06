using UnityEngine;
using UnityEngine.Events;

public class ValidationButton : MonoBehaviour, IInteractable
{
    public UnityEvent onValidated; // Ajoutez cet �v�nement pour �tre d�clench� apr�s la validation

    public void OnPress()
    {
        onValidated?.Invoke(); // D�clenche l'�v�nement apr�s la validation
    }
}
