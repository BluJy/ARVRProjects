using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecordTrajectory : MonoBehaviour
{
    
    void Start()
    {
        /*
        List<Vector3> tPoints = new List<Vector3>();
        tPoints.Add(new Vector3((float)2.0, (float)2.2, (float)2.3));
        tPoints.Add(new Vector3((float)2.2, (float)2.3, (float)2.3));
        tPoints.Add(new Vector3((float)1.9, (float)2.2, (float)1.7));
        tPoints.Add(new Vector3((float)2.3, (float)2.3, (float)1.6));
        Trajectory coachTrajectory = new Trajectory((float)1.22, new Vector3(1, 2, 1), tPoints);
        //Debug.Log(coachTrajectory.toString());
        writeTrajectory(coachTrajectory, "/MyAssets/Trajectories/trajectory.json");
        Trajectory tra = readTrajectory("/MyAssets/Trajectories/trajectory.json");
        //Debug.Log("After Writing and Reading: " + tra.toString());
        */
    }

    public static void writeTrajectory(Trajectory trueTrajectory, string filePath)
    {
        TrajectorySaver coachTrajectory = new TrajectorySaver();
        coachTrajectory.shoulderPoint = trueTrajectory.getShoulderPoint();
        coachTrajectory.armLength = trueTrajectory.getArmLength();
        coachTrajectory.trajectoryPoints = trueTrajectory.getTrajectoryPoints();
        string json = JsonUtility.ToJson(coachTrajectory);
        File.WriteAllText(Application.dataPath + filePath, json);
    }


    public static Trajectory readTrajectory(string filePath) {
        Debug.Log("first " + Application.dataPath + filePath);
        Debug.Log("second " + System.IO.Directory.GetCurrentDirectory() + filePath);

        string json = File.ReadAllText(Application.dataPath + filePath);
        TrajectorySaver ts = JsonUtility.FromJson<TrajectorySaver>(json);
        User trajectoryUser = new User(ts.shoulderPoint, ts.armLength);
        Trajectory trueTrajectory = new Trajectory(ts.trajectoryPoints, trajectoryUser);
        return trueTrajectory;
    }


}

