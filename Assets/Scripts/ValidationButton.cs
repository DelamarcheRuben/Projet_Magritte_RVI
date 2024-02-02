using UnityEngine;

public class ValidationButton : MonoBehaviour
{
    public TextManager textManager;

    // Cette m�thode sera appel�e par votre syst�me d'interaction VR
    // quand le bouton "ValidationButton" est press�.
    public void OnButtonPressed()
    {
        textManager.ValidatePassword();
    }
}
