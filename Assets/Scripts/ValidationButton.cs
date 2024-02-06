using UnityEngine;
using UnityEngine.Events;

public class ValidationButton : MonoBehaviour, IInteractable
{
    public AudioSource audioSource;
    public UnityEvent onValidated; // Ajoutez cet événement pour être déclenché après la validation

    public void OnPress()
    {
        onValidated?.Invoke(); // Déclenche l'événement après la validation

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
