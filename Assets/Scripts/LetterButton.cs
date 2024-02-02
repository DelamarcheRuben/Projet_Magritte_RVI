using UnityEngine;
using UnityEngine.Events;

public class LetterButton : MonoBehaviour
{
    public UnityEvent<string> onLetterPressed;
    public string letter;

    public void OnButtonPressed() // Appel� par le syst�me d'interaction VR
    {
        onLetterPressed?.Invoke(letter);
    }
}
