using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsymptoticTrajectory : MonoBehaviour
{

    public static void updateAsymptoticTrajectory(LineRendererController asymptoticline, Trajectory trajectory, Vector3 controllerPoint){

        List<Vector3> parts = trajectory.getTrajectoryPoints();

        
        Color white = new Color(1, 1, 1, 1);

        asymptoticline.setColor(white, white);

        int closestPointIndex = calculateClosestPointIndex(trajectory, controllerPoint);

        Vector3 lerpPoint1;
        Vector3 lerpPoint2;
        List<Vector3> curvePoints;

        if (closestPointIndex + 30 < parts.Count)
        {
            //Debug.Log("Case: 1 Parts Count: " + parts.Count + "ClosestPointIndex: " + closestPointIndex);
            lerpPoint1 = parts[closestPointIndex + 15];
            lerpPoint2 = parts[closestPointIndex + 30];
            curvePoints = bezierCurve(controllerPoint, lerpPoint1, lerpPoint2, 12);
        }
        else if (closestPointIndex + 3 < parts.Count)
        {
            //Debug.Log("Case: 2 Parts Count: " + parts.Count + "ClosestPointIndex: " + closestPointIndex);
            lerpPoint1 = parts[closestPointIndex + 1];
            lerpPoint2 = parts[closestPointIndex + 2];
            curvePoints = bezierCurve(controllerPoint, lerpPoint1, lerpPoint2, 12);
        }
        else {
            //Debug.Log("Case: 3 Parts Count: " + parts.Count + "ClosestPointIndex: " + closestPointIndex);
            curvePoints = new List<Vector3>();
            curvePoints.Add(controllerPoint);
            curvePoints.Add(parts[closestPointIndex]);
        }

        //Debug.Log("ControllerPoint: " + controllerPoint + "ClosestPointIndex: " + closestPointIndex);

        asymptoticline.setUpLine(curvePoints.ToArray());
    }

    public static void disableAsymptoticTrajectory(LineRendererController line){

        line.disableLine();

    }

    public static List<Vector3> bezierCurve(Vector3 controllerPoint, Vector3 trajectoryPoint1, Vector3 trajectoryPoint2, int vertexCount) {

        List <Vector3> bezierPoints = new List<Vector3>();

        for (float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount) {
            Vector3 tangentLineVertex1 = Vector3.Lerp(controllerPoint, trajectoryPoint1, ratio);
            Vector3 tangentLineVertex2 = Vector3.Lerp(trajectoryPoint1, trajectoryPoint2, ratio);
            Vector3 bezierPoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio);
            bezierPoints.Add(bezierPoint);
        }
        
        return bezierPoints;
    }


    public static int calculateClosestPointIndex(Trajectory trajectory, Vector3 controllerPoint)
    {
        float distance = calculateVectorDistance(trajectory.getTrajectoryPoints()[0], controllerPoint);
        Vector3 closestPoint = trajectory.getTrajectoryPoints()[0];
        int smallestIndex = 0;
        int indx = 0;

        foreach (Vector3 point in trajectory.getTrajectoryPoints())
        {
            float pointdistance = calculateVectorDistance(point, controllerPoint);
            if (pointdistance < distance)
            {
                closestPoint = point;
                distance = pointdistance;
                smallestIndex = indx;
            }

            indx++;
        }



        return smallestIndex;

    }

    public static float calculateVectorDistance(Vector3 pointone, Vector3 pointtwo)
    {

        float xdistance = Mathf.Pow(pointone.x - pointtwo.x, 2);
        float ydistance = Mathf.Pow(pointone.y - pointtwo.y, 2);
        float zdistance = Mathf.Pow(pointone.z - pointtwo.z, 2);
        float sumOfSquares = xdistance + ydistance + zdistance;
        float distance = Mathf.Sqrt(sumOfSquares);
        return distance;


    }

}
