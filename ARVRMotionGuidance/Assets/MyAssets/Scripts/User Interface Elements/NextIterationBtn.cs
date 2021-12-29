using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextIterationBtn : MonoBehaviour
{

    public void pressBtn()
    {
        User user = LearnMotion.user;
        LearnMotion.iterationCount += 1;
        Trajectory trajectory = new Trajectory(LearnMotion.currentTrajectory, user);
        LearnMotion.allTrajectories.Add(trajectory);
        LearnMotion.currentTrajectory = new List<Vector3>();
        LearnStatisticsScript.updateStatistics(LearnMotion.allTrajectories, LearnMotion.coachTrajectory, LearnMotion.iterationCount);
    }

}
