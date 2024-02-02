using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TMP_Text passwordText;
    public GameObject doorLeftPart; // Assignez le premier �l�ment de la porte
    public GameObject doorRightPart; // Assignez le deuxi�me �l�ment de la porte
    public string correctPassword = "MAGRITTE";
    public Color successColor = Color.green;
    public Color failureColor = Color.red;
    public Renderer passwordRenderer; // Le Renderer du cube Password

    private string enteredText = "";

    public void AddLetter(string letter)
    {
        enteredText += letter;
        passwordText.text = enteredText;
    }

    // Appel�e quand le bouton "ValidationButton" est press�
    public void ValidatePassword()
    {
        if (enteredText.Equals(correctPassword))
        {
            passwordRenderer.material.color = successColor;
            OpenDoor();
        }
        else
        {
            passwordRenderer.material.color = failureColor;
            // Optionnel : Ajoutez une logique pour effacer le texte apr�s un �chec.
            ClearText();
        }
    }

    private void OpenDoor()
    {
        doorLeftPart.SetActive(false); // D�sactivez une partie de la porte
        doorRightPart.SetActive(false); // D�sactivez l'autre partie de la porte
    }

    private void ClearText()
    {
        enteredText = "";
        passwordText.text = enteredText;
    }
}
