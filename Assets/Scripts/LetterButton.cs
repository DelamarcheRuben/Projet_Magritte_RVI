using UnityEngine;
using UnityEngine.Events;

public class LetterButton : MonoBehaviour, IInteractable
{
    public UnityEvent<string> onLetterPressed;
    public string letter;

    public void OnPress() // Impl�mentation de la m�thode de l'interface
    {
        // Ajoutez ici toute autre logique n�cessaire lors de l'appui sur le bouton
        onLetterPressed?.Invoke(letter);

    }
}
