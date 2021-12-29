using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMeasurement : MonoBehaviour
{

    public static Vector3 takeMeasurement()
    {
        Vector3 point;
        point = MRTKController.getControllerPosition();

        return point;

    }



    public static float calculateVectorDistance(Vector3 pointone, Vector3 pointtwo)
    {
        float xdistance = (float)Mathf.Pow((float)pointone.x - (float)pointtwo.x, (float)2);
        float ydistance = (float)Mathf.Pow((float)pointone.y - (float)pointtwo.y, (float)2);
        float zdistance = (float)Mathf.Pow((float)pointone.z - (float)pointtwo.z, (float)2);
        float sumOfSquares = (float)xdistance + (float)ydistance + (float)zdistance;
        float distance = (float)Mathf.Sqrt((float)sumOfSquares);
        return (float)distance;
    }


}
