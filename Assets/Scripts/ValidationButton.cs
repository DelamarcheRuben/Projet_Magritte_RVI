using UnityEngine;

public class ValidationButton : MonoBehaviour, IInteractable
{
    public TextManager textManager;
    public AudioSource audioSource; // Assurez-vous que ce composant est attaché dans l'éditeur Unity

    public void OnPress() // Implémentation de la méthode de l'interface
    {
        textManager.ValidatePassword();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        // Ajoutez ici toute autre logique nécessaire lors de l'appui sur le bouton
    }
}
