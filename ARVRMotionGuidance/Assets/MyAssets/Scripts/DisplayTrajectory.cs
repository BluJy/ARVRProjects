using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTrajectory : MonoBehaviour
{

    public static void updateTrajectory(LineRendererController line, Trajectory trajectory) {

        List<Vector3> parts = trajectory.getTrajectoryPoints();

        Color green = new Color((float)0.2, (float)1, (float)0.2, (float)0.7);
        Color purple = new Color((float)0.27, (float)0.05, (float)0.75, (float)0.7);

        line.setColor(green, purple);
        line.setUpLine(parts.ToArray());
    }

    public static void disableTrajectory(LineRendererController line) {

        line.disableLine();
    
    }

}
