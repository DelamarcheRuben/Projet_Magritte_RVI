using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Button : MonoBehaviour, IInteractable
{
    public Color pressedColor = Color.black; // La couleur lors de l'appui sur le bouton
    public float colorResetDelay = 0.1f; // Le délai avant de réinitialiser la couleur
    private Color originalColor;
    private Renderer buttonRenderer;

    public UnityEvent onPressed;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
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
            // Commencez la coroutine pour réinitialiser la couleur après un délai
            StartCoroutine(ResetColorAfterDelay());
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
