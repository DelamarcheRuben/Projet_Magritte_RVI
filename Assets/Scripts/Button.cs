using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Button : MonoBehaviour, IInteractable
{
    public Color pressedColor = Color.black; // La couleur lors de l'appui sur le bouton
    public float colorResetDelay = 0.3f; // Le délai avant de réinitialiser la couleur
    private Color originalColor;
    private Renderer buttonRenderer;

    public UnityEvent onPressed;

    // Assurez-vous d'avoir un AudioSource sur le même GameObject que ce script
    public AudioSource audio;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
        audio = GetComponent<AudioSource>(); // Obtenir la référence AudioSource
        if (buttonRenderer != null)
        {
            // Sauvegardez la couleur originale du bouton
            originalColor = buttonRenderer.material.color;
        }
    }

    public void OnPress()
    {
        // Changez la couleur du bouton
        if (buttonRenderer != null)
        {
            buttonRenderer.material.color = pressedColor;
            onPressed?.Invoke();
            // Joue le son attaché à l'AudioSource
            PlaySound();
            // Commencez la coroutine pour réinitialiser la couleur après un délai
            StartCoroutine(ResetColorAfterDelay());
        }
    }

    private void PlaySound()
    {
        if (audio != null)
        {
            audio.Play();
        }
    }

    private IEnumerator ResetColorAfterDelay()
    {
        // Attendez le délai défini
        yield return new WaitForSeconds(colorResetDelay);
        // Réinitialisez la couleur du bouton
        if (buttonRenderer != null)
        {
            buttonRenderer.material.color = originalColor;
        }
    }
}
