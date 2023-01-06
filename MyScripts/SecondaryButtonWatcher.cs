using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

[System.Serializable]
public class SecondaryButtonEvent : UnityEvent<bool> { }

public class SecondaryButtonWatcher : MonoBehaviour
{
    public SecondaryButtonEvent secondaryButtonPress;

    private bool lastButtonState = false;
    private List<InputDevice> devicesWithSecondaryButton;

    private void Awake()
    {
        if (secondaryButtonPress == null)
        {
            secondaryButtonPress = new SecondaryButtonEvent();
        }

        devicesWithSecondaryButton = new List<InputDevice>();
    }

    void OnEnable()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach (InputDevice device in allDevices)
            InputDevices_deviceConnected(device);

        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        devicesWithSecondaryButton.Clear();
    }

    private void InputDevices_deviceConnected(InputDevice device)
    {
        bool discardedValue;
        if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out discardedValue))
        {
            devicesWithSecondaryButton.Add(device); // Add any devices that have a secondary button.
        }
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (devicesWithSecondaryButton.Contains(device))
            devicesWithSecondaryButton.Remove(device);
    }

    void Update()
    {
        bool tempState = false;
        foreach (var device in devicesWithSecondaryButton)
        {
            bool secondaryButtonState = false;
            tempState = device.TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryButtonState) // did get a value
                        && secondaryButtonState // the value we got
                        || tempState; // cumulative result from other controllers
        }

        if (tempState != lastButtonState) // Button state changed since last frame
        {
            secondaryButtonPress.Invoke(tempState);
            lastButtonState = tempState;
        }
    }
}