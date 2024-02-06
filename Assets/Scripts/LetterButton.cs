using UnityEngine;
using UnityEngine.Events;

public class LetterButton : MonoBehaviour, IInteractable
{
    public UnityEvent<string> onLetterPressed;
    public string letter;

    public void OnPress() // Implémentation de la méthode de l'interface
    {
        // Ajoutez ici toute autre logique nécessaire lors de l'appui sur le bouton
        onLetterPressed?.Invoke(letter);

    }
}
