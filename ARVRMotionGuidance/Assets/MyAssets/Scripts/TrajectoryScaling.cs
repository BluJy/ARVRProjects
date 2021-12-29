using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrajectoryScaling
{
    public static Vector3 measurement()
    {
        //get position of controller and return
        Vector3 position = new Vector3(10, 20, 30);
        return position;
    }

    public static float calculateScalingFactor(float coachArmLength, float armlength)
    {
        float armScalingFactor = armlength / coachArmLength;
        return armScalingFactor;
    }

    public static List<Vector3> calculateTrajectory(Trajectory coachTrajectory, User user, float scalingFactor)
    {
        /*
         * Old: We used the usual points for the trajectories not the points from coach shoulder to trajectory
         * -> Works Now
         * 
         * 
         * if vec_a = shoulder point of coach
         *    vec_c = original trajectory point
         *    -> vec_c = vec_a + vec_b
         *    -> vec_b = vec_c - vec_a
         *    -> vec_b is the vector from the coaches shoulder to the trajectory point
         *    -> now multiply each element of vec_b with scalingFactor to receive the points from users shoulder to trajectory.
         *    -> then add these resulting vectors to the users shoulderpoint 
         *    -> done
         * 
         * Old Calculation
         * scaledVectors.Add(new Vector3(shoulderPoint.x + (scalingFactor * original.x), shoulderPoint.y + (scalingFactor * original.y), shoulderPoint.z + (scalingFactor * original.z)));
         * 
         * 
         * */

        //Takes in Vectors from Coaches Shoulder to the Trajectory
        List<Vector3> originalPoints = coachTrajectory.getTrajectoryPoints();
        Vector3 coachShoulderPoint = coachTrajectory.getShoulderPoint();

        List<Vector3> scaledVectors = new List<Vector3>();

        foreach (Vector3 original in originalPoints)
        {
            Vector3 b_Vector = original - coachShoulderPoint;
            Vector3 scaled_b_Vector = b_Vector * scalingFactor;
            Vector3 newPoint = user.getShoulderPoint()+scaled_b_Vector;
            scaledVectors.Add(newPoint);
        }

        return scaledVectors;
    }

    public static Trajectory scaleTrajectory(Trajectory coachTrajectory, User user)
    {
        //Start with this method
        //Debug.Log(coachTrajectory.getUser().toString());
        //Debug.Log(user.toString());
        float scalingFactor = calculateScalingFactor(coachTrajectory.getArmLength(), user.getArmLength());
        List<Vector3> trajectoryPoints = calculateTrajectory(coachTrajectory, user, scalingFactor);
        Trajectory userTrajectory = new Trajectory(trajectoryPoints, user);
        return userTrajectory;
    }

}

