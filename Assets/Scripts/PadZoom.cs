using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR;

public class PadZoom : MonoBehaviour
{
	public ZoomIn zoom;
	public Console console;
	public bool enabled = true;
	public bool activated = true;

	private List<InputDevice> devicesWithPadButton;
    private bool lastButtonState = false;

    public void setEnabled(bool newVal)
	{
		enabled = newVal;
	}

	public void setActivated(bool newVal)
	{
		activated = newVal;
	}

	// Start is called before the first frame update
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
		foreach (InputDevice device in allDevices)
			InputDevices_deviceConnected(device);

		InputDevices.deviceConnected += InputDevices_deviceConnected;
		InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
	}

	private void InputDevices_deviceConnected(InputDevice device)
	{
		bool discardedValue;
		if (device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out discardedValue))
		{
			devicesWithPadButton.Add(device);
		}
	}

	private void InputDevices_deviceDisconnected(InputDevice device)
	{
		if (devicesWithPadButton.Contains(device))
		{
			devicesWithPadButton.Remove(device);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (true)
		{
			bool tempState = false;
			foreach (var device in devicesWithPadButton)
			{
				bool primaryButtonState = false;
				tempState = device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out primaryButtonState)
							&& primaryButtonState
							|| tempState;
			}
			if (tempState != lastButtonState && Input.GetAxis("Vertical") > 0.5)
			{
				zoom.OnPadPressed(tempState);
				lastButtonState = tempState;
			}
		}
	}
}
