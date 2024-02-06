using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.Events;

public class Human : MonoBehaviour, IInteractable
{
    public UnityEvent onHumanPressed;
    public void OnPress()
    {
        onHumanPressed?.Invoke();
    }
}