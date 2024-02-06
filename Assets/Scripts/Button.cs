using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, IInteractable
{
    public UnityEvent onPressed; 

    public void OnPress()
    {
        onPressed?.Invoke();
    }
}
