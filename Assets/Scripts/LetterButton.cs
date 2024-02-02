using UnityEngine;
using UnityEngine.Events;

public class LetterButton : MonoBehaviour
{
    public UnityEvent<string> onLetterPressed;
    public string letter;

    public void OnButtonPressed() // Appelé par le système d'interaction VR
    {
        onLetterPressed?.Invoke(letter);
    }
}
