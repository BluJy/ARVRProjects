using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;

public class MRTKController : MonoBehaviour
{
    // Start is called before the first frame update

    public static Vector3 getControllerPosition() {

        Vector3 controllerPosition = new Vector3(0,0,0);

        int i = 0;
        foreach (var controller in CoreServices.InputSystem.DetectedControllers)
        {
            i = 0;
            foreach (MixedRealityInteractionMapping inputMapping in controller.Interactions)
            {
                if ((inputMapping.InputType == DeviceInputType.SpatialGrip) && (i == 0))
                {
                    controllerPosition = inputMapping.PositionData;
                }
            }
            i++;
        }

        i = 0;

        return controllerPosition;

    }

}

