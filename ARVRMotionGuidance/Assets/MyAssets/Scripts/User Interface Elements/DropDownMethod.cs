using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownMethod : MonoBehaviour
{
    public TMP_Dropdown dropDownMethod;
    public static string chosenMethod = "RubberBand";

    public void HandleInputData()
    {
        Debug.Log("here!");
        if (dropDownMethod.value == 0)
        {
            chosenMethod = "RubberBand";
        }
        else if (dropDownMethod.value == 1)
        {
            chosenMethod = "AsymptoticTrajectory";
        }

    }
}
