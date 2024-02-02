using UnityEngine;

public class ValidationButton : MonoBehaviour
{
    public TextManager textManager;

    // Cette méthode sera appelée par votre système d'interaction VR
    // quand le bouton "ValidationButton" est pressé.
    public void OnButtonPressed()
    {
        textManager.ValidatePassword();
    }
}
