using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNextIterationBtnScript : MonoBehaviour
{

    public void pressBtn()
    {
        User user = TestMotion.user;
        TestMotion.iterationCount += 1;
        Trajectory trajectory = new Trajectory(TestMotion.currentTrajectory, user);
        TestMotion.allTrajectories.Add(trajectory);
        TestMotion.currentTrajectory = new List<Vector3>();
        TestStatisticsScript.updateStatistics(TestMotion.allTrajectories, TestMotion.coachTrajectory, TestMotion.iterationCount);
    }


}
