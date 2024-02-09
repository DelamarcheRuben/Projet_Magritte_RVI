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
    public float pressDuration = 0.2f; // Durée de l'enfoncement

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
        // Déplace le bouton vers l'intérieur du mur sur l'axe X
        Vector3 pressedPosition = originalPosition - transform.right * pressDistance; // Utilisez -transform.right pour déplacer sur l'axe X négatif
        float elapsedTime = 0f;

        // Bouge le bouton vers l'intérieur
        while (elapsedTime < pressDuration)
        {
            transform.localPosition = Vector3.Lerp(originalPosition, pressedPosition, elapsedTime / pressDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Remet le bouton à sa position originale
        elapsedTime = 0f;
        while (elapsedTime < pressDuration)
        {
            transform.localPosition = Vector3.Lerp(pressedPosition, originalPosition, elapsedTime / pressDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Assure que le bouton est bien revenu à sa position originale
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
