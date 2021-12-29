using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.XR;

public class ControllerPositionTracking : MonoBehaviour
{
    private InputDevice targetDevice; 

    // Start is called before the first frame update
    void Start()
    {
        //Microsoft.mixedreality.Input.mutioncontroller

        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);

        }

        if (devices.Count > 0) {
            targetDevice = devices[0];        
        }

    }

    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue) {
            Debug.Log("Pressing Primary Button");
        }
    }
}
