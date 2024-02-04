using UnityEngine;
using UnityEngine.Events;

public class LetterButton : MonoBehaviour, IInteractable
{
    public UnityEvent<string> onLetterPressed;
    public Renderer passwordRenderer; // Le Renderer du cube Password pour le mettre en blanc quand on retente un nouveau mot de passe
    public Color whiteColor = Color.white;
    public string letter;

    public void OnPress() // Impl�mentation de la m�thode de l'interface
    {
        // Ajoutez ici toute autre logique n�cessaire lors de l'appui sur le bouton

        passwordRenderer.material.color = whiteColor; // On repasse la couleur � blanc
        onLetterPressed?.Invoke(letter);
        
    }
}
