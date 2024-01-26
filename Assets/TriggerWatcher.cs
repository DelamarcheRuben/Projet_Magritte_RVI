using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR;

public class TriggerWatcher : MonoBehaviour
{
	public ZoomIn zoom;
	public BallShooter shooter;
	public bool enabled = false;
	public bool activated = true;

	private bool lastButtonState = false;

	private List<InputDevice> devicesWithTriggerButton;

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
		devicesWithTriggerButton = new List<InputDevice>();

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
		devicesWithTriggerButton.Clear();
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
		if (device.TryGetFeatureValue(CommonUsages.triggerButton, out discardedValue))
		{
			devicesWithTriggerButton.Add(device);
		}
	}

	private void InputDevices_deviceDisconnected(InputDevice device)
	{
		if (devicesWithTriggerButton.Contains(device))
		{
			devicesWithTriggerButton.Remove(device);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (true)
		{
			bool tempState = false;
			foreach (var device in devicesWithTriggerButton)
			{
				bool primaryButtonState = false;
				tempState = device.TryGetFeatureValue(CommonUsages.triggerButton, out primaryButtonState)
							&& primaryButtonState
							|| tempState;
			}

			if (tempState != lastButtonState)
			{
				shooter.OnTriggerPressed(tempState && enabled);

				lastButtonState = tempState;
			}
		}
	}
}
