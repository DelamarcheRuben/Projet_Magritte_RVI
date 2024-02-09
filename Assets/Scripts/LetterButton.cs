using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class LetterButton : MonoBehaviour, IInteractable
{
    public UnityEvent<string> onLetterPressed;
    public string letter;
    public AudioSource audio;

    private Vector3 originalPosition;
    public float pressDistance = 0.03f; // Distance que le bouton s'enfonce
    public float pressDuration = 0.2f; // Dur�e de l'enfoncement

    void Start()
    {
        // Sauvegarde la position originale du bouton
        originalPosition = transform.localPosition;
    }

    public void OnPress()
    {
        if (!IsInvoking("PressAndRelease"))
        {
            StartCoroutine(PressAndRelease());
            PlaySound();
            onLetterPressed?.Invoke(letter);
        }
    }

    private IEnumerator PressAndRelease()
    {
        // D�place le bouton vers l'int�rieur du mur sur l'axe X
        Vector3 pressedPosition = originalPosition - transform.right * pressDistance; // Utilisez -transform.right pour d�placer sur l'axe X n�gatif
        float elapsedTime = 0f;

        // Bouge le bouton vers l'int�rieur
        while (elapsedTime < pressDuration)
        {
            transform.localPosition = Vector3.Lerp(originalPosition, pressedPosition, elapsedTime / pressDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Remet le bouton � sa position originale
        elapsedTime = 0f;
        while (elapsedTime < pressDuration)
        {
            transform.localPosition = Vector3.Lerp(pressedPosition, originalPosition, elapsedTime / pressDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Assure que le bouton est bien revenu � sa position originale
        transform.localPosition = originalPosition;
    }

    private void PlaySound()
    {
        if (audio != null)
        {
            audio.Play();
        }
    }
}
