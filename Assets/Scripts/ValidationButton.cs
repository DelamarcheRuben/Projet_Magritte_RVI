using UnityEngine;

public class ValidationButton : MonoBehaviour, IInteractable
{
    public TextManager textManager;
    public AudioSource audioSource; // Assurez-vous que ce composant est attach� dans l'�diteur Unity

    public void OnPress() // Impl�mentation de la m�thode de l'interface
    {
        textManager.ValidatePassword();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        // Ajoutez ici toute autre logique n�cessaire lors de l'appui sur le bouton
    }
}
