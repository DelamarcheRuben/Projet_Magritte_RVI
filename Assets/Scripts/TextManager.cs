using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TMP_Text passwordText; // Le text du panneau 'Password'
    public AudioSource successAudioSource; // AudioSource pour le son de succès
    public AudioSource failureAudioSource; // AudioSource pour le son d'échec
    public string correctPassword = "M1E3R2T1";
    public Color successColor = Color.green;
    public Color failureColor = Color.red;
    public Renderer passwordRenderer; // Le Renderer du cube Password
    public TMP_Text passwordHisto;
    public GameObject doorObject;
    public GameObject mur; // Solution approximative pour gérer le problème de porte qui a un collider bugué.

    private FixedSizeQueue<string> queueHistoric = new FixedSizeQueue<string>(9);

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
            queueHistoric.Enqueue("\n Succès : " + enteredText);
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

        UpdatePasswordHistory(); // Mise à jour de l'historique
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
        mur.SetActive(false);
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
