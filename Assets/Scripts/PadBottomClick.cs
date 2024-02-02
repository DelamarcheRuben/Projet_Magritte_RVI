using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PadInputHandler : MonoBehaviour
{
    /*public TextManager textManager;

    private List<InputDevice> devicesWithPrimary2DAxis;
    private bool lastButtonState = false;

    private void OnEnable()
    {
        RegisterDevices();
    }

    private void OnDisable()
    {
        UnregisterDevices();
    }

    private void RegisterDevices()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach (InputDevice device in allDevices)
            InputDevices_deviceConnected(device);

        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    private void UnregisterDevices()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        devicesWithPadButton.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        // On écoute en continu si on appuie sur le bouton bas du pad
        CheckForPadDownInput();
    }

    private void CheckForPadDownInput()
    {
        bool buttonState = false;
        foreach (var device in devicesWithPrimary2DAxis)
        {
            bool primary2DAxisClicked = false;
            buttonState = device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out primary2DAxisClicked)
                            && primary2DAxisClicked
                            || buttonState;
        }

        if (buttonState != lastButtonState && Input.GetAxis("Vertical") < -0.5)
        {
            // Ici, nous supposons que nous avons une méthode pour obtenir la lettre actuelle
            string currentLetter = GetCurrentSelectedLetter();
            
            // Ajout de la lettre via la fonction du TextManager
            textManager.AddLetter(currentLetter);
            lastButtonState = buttonState;
        }
    }

    private string GetCurrentSelectedLetter()
    {
        // Obtenir la lettre actuelle.
        // Par exemple, cela pourrait être basé sur le bouton de lettre actuellement sélectionné.
        return "E3"; // Test pour le moment 
    } */
}
