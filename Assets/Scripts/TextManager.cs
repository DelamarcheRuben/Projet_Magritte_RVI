using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TMP_Text passwordText;
    public Animator doorAnimator; // L'Animator de la porte
    public AudioSource successAudioSource; // AudioSource pour le son de succ�s
    public AudioSource failureAudioSource; // AudioSource pour le son d'�chec
    public string correctPassword = "E3";
    public Color successColor = Color.green;
    public Color failureColor = Color.red;
    public Renderer passwordRenderer; // Le Renderer du cube Password
    public TMP_Text passwordHisto;
    public GameObject doorObject;

    private FixedSizeQueue<string> queueHistoric = new FixedSizeQueue<string>(10);

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
            queueHistoric.Enqueue("\n Succ�s : " + enteredText);
            passwordRenderer.material.color = successColor;
            OpenDoorWithSuccess();
        }
        else
        {
            queueHistoric.Enqueue("\n Echec : " + enteredText);
            passwordRenderer.material.color = failureColor;
            PlayFailureSound();
            ClearText();
        }

        UpdatePasswordHistory(); // Mise � jour de l'historique
    }

    private void OpenDoorWithSuccess()
    {
        DoorAnimation();
        PlaySuccessSound();
    }

    private void PlayFailureSound()
    {
        failureAudioSource.Play();
    }

    private void PlaySuccessSound()
    {
        successAudioSource.Play();
    }

    private void ClearText()
    {
        enteredText = "";
        passwordText.text = enteredText;
    }

    private void DoorAnimation()
    {
        doorObject.SetActive(false);
    }

    private void UpdatePasswordHistory()
    {
        passwordHisto.text = "";
        foreach (string entry in queueHistoric)
        {
            passwordHisto.text += entry;
        }
    }
}
