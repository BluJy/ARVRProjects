using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputHandler : MonoBehaviour
{
    public static bool isButtonPressed = false;

    public static void buttonPressed() {

        isButtonPressed = true;

    }

    public static void buttonReleased(){

        isButtonPressed = false;

    }

}
