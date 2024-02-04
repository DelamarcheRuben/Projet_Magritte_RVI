using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR;

public class PadBottomHandler : MonoBehaviour
{
    public GameObject selectedObject;

    private List<InputDevice> devicesWithPadButton;
    private bool lastButtonState = false;

    void Start()
    {
        devicesWithPadButton = new List<InputDevice>();
        RegisterDevices();
    }

    private void OnEnable()
    {
        RegisterDevices();
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        devicesWithPadButton.Clear();
    }

    private void RegisterDevices()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach (var device in allDevices)
            InputDevices_deviceConnected(device);

        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    private void InputDevices_deviceConnected(InputDevice device)
    {
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out _))
        {
            devicesWithPadButton.Add(device);
        }
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        devicesWithPadButton.Remove(device);
    }

    void Update()
    {
        CheckForPadDownInput();
    }

    private void CheckForPadDownInput()
    {
        bool buttonState = false;
        foreach (var device in devicesWithPadButton)
        {
            device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool primary2DAxisClicked);
            buttonState = primary2DAxisClicked || buttonState;
        }

        if (buttonState != lastButtonState && Input.GetAxis("Vertical") < -0.5)
        {
            lastButtonState = buttonState;
            if (buttonState && selectedObject != null)
            {
                var interactable = selectedObject.GetComponent<IInteractable>();
                interactable?.OnPress();
            }
        }
    }
}
