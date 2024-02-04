using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TMP_Text passwordText;
    public Animator doorAnimator; // L'Animator de la porte
    public AudioSource successAudioSource; // AudioSource pour le son de succès
    public AudioSource failureAudioSource; // AudioSource pour le son d'échec
    public string correctPassword = "E3";
    public Color successColor = Color.green;
    public Color failureColor = Color.red;
    public Renderer passwordRenderer; // Le Renderer du cube Password

    private string enteredText = "";

    public void AddLetter(string letter)
    {
        enteredText += letter;
        passwordText.text = enteredText;
    }

    public void ValidatePassword()
    {
        if (enteredText.Equals(correctPassword))
        {
            passwordRenderer.material.color = successColor;
            OpenDoorWithSuccess();
        }
        else
        {
            passwordRenderer.material.color = failureColor;
            PlayFailureSound();
            ClearText();
        }
    }

    private void OpenDoorWithSuccess()
    {
        doorAnimator.SetTrigger("Open"); // Remplacez "Open" par le nom exact de votre trigger d'animation
        successAudioSource.Play();
    }

    private void PlayFailureSound()
    {
        failureAudioSource.Play();
    }

    private void ClearText()
    {
        enteredText = "";
        passwordText.text = enteredText;
    }
}
