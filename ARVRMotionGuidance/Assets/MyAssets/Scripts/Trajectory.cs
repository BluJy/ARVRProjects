using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trajectory
{

    private User trajectoryUser;
    //Vectors of Shoulder to Wrist in every Frame
    private List<Vector3> trajectoryPoints;

    public Trajectory(List<Vector3> trajectoryPoints, User trajectoryUser) {
        this.trajectoryPoints = trajectoryPoints;
        this.trajectoryUser = trajectoryUser;
    }

    public User getUser() {
        return this.trajectoryUser;
    }

    public Vector3 getShoulderPoint() {
        return this.trajectoryUser.shoulderPoint;
    }

    public List<Vector3> getTrajectoryPoints()
    {
        return this.trajectoryPoints;
    }

    public float getArmLength()
    {
        return this.trajectoryUser.armLength;
    }
    
    public string toString() {
        string trajlist = "[Trajectory: TrajectoryPoints = [";
        foreach (Vector3 vector in trajectoryPoints) {
            trajlist += vector.ToString();
        }
        trajlist += "]";
        trajlist += trajectoryUser.toString();
        trajlist += "]";


        return trajlist;
    }




}
