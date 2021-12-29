using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberBand : MonoBehaviour
{
    static GameObject rubberBand;

    public static void updateRubberBand(LineRendererController line, Trajectory trajectory, Vector3 controllerPoint, float maximumDistance) {
        
        //get closest point to trajectory
        Vector3 closestPoint = calculateClosestPoint(trajectory, controllerPoint);
        float closestDistance = calculateVectorDistance(controllerPoint, closestPoint);

        //TODO: Change color/thickness of the band based on the distance.
        float RGB_red = calculateBandColorValue(closestDistance, maximumDistance);
        Color red = new Color(1, 1-RGB_red, 1-RGB_red, 1);
        line.setColor(red,red);

        //Update Linerenderer
        Vector3[] positionArray = new[] {controllerPoint, closestPoint};
        line.setUpLine(positionArray);
    }

    public static void disableRubberBand(LineRendererController line) {
        line.disableLine();
    }

    public static float calculateBandColorValue(float distance, float maximumdistance) {
        float ratio = distance / maximumdistance;
        if (ratio >= 1)
        {
            return 1;
        }
        else if (ratio < 1)
        {
            return ratio;
        }
        else {
            return 0;
        }
    }

    public static float calculateBandWidth(float distance, float maximumdistance) {
        float ratio = distance / maximumdistance;
        if (ratio >= 1)
        {
            return (float)1;
        }
        else if (ratio < 1)
        {
            return ratio * (float)0.5;
        }
        else {
            return 0;
        }
    }

    public static Vector3 calculateClosestPoint(Trajectory trajectory, Vector3 controllerPoint) {
        float distance = calculateVectorDistance(trajectory.getTrajectoryPoints()[0], controllerPoint);
        Vector3 closestPoint = trajectory.getTrajectoryPoints()[0];

        foreach (Vector3 point in trajectory.getTrajectoryPoints())
        {
            float pointdistance = calculateVectorDistance(point, controllerPoint);
            if (pointdistance < distance)
            {
                closestPoint = point;
                distance = pointdistance;
            }
        }

        

        return closestPoint;

    }

    public static float calculateVectorDistance(Vector3 pointone, Vector3 pointtwo) {

        float xdistance = Mathf.Pow(pointone.x - pointtwo.x, 2);
        float ydistance = Mathf.Pow(pointone.y - pointtwo.y, 2);
        float zdistance = Mathf.Pow(pointone.z - pointtwo.z, 2);
        float sumOfSquares = xdistance + ydistance + zdistance;
        float distance = Mathf.Sqrt(sumOfSquares);
        return distance;


    }

}
