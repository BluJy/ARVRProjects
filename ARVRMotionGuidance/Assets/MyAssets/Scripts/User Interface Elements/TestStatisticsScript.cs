using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStatisticsScript : MonoBehaviour
{
    public static GameObject statisticsLabel;
    public static string text; 
    public static float currentAccuracy;
    public static float totalAccuracy;
    public static float currentDistance;
    public static float totalDistance;

    public void Awake() {


        totalAccuracy = 0;
        totalDistance = 0;
        currentAccuracy = 0;
        currentDistance = 0;


    }

    public void onDisable() {

        totalAccuracy = 0;
        totalDistance = 0;
        currentAccuracy = 0;
        currentDistance = 0;
    }

    public static void updateStatistics(List<Trajectory> allTrajectories, Trajectory coachTrajectory, int iterationCount)
    {
        Trajectory latestTrajectory = allTrajectories[allTrajectories.Count - 1];
        currentAccuracy = Statistics.accuracy(latestTrajectory, coachTrajectory);
        currentDistance = Statistics.distance(latestTrajectory, coachTrajectory);

        if (allTrajectories.Count > 0)
        {

            foreach (Trajectory trajectory in allTrajectories)
            {
                totalAccuracy += Statistics.accuracy(trajectory, coachTrajectory);
                totalDistance += Statistics.distance(trajectory, coachTrajectory);
            }

            totalAccuracy = totalAccuracy / allTrajectories.Count;
            totalDistance = totalDistance / allTrajectories.Count;
            
        }


        //Debug.Log("TestStatisticsScript: totalAccuracy: " + totalAccuracy);
        //Debug.Log("TestStatisticsScript: Alltrajectories.count: " + allTrajectories.Count);

        //Debug.Log("TestStatisticsScript: totalAccuracy: " + totalAccuracy);

        text = "";
        text += "Statistics: ";
        text += "\n";
        text += "Iteration: " + TestMotion.iterationCount;
        text += "\n";
        text += "Current Accuracy: " + currentAccuracy;
        text += "\n";
        text += "Average Accuracy: " + totalAccuracy;
        text += "\n";
        text += "Current Distance: " + currentDistance;
        text += "\n";
        text += "Average Distance: " + totalDistance;
        statisticsLabel = GameObject.Find("TestStatisticsLabel");
        statisticsLabel.GetComponent<TMPro.TextMeshProUGUI>().text = text;
        totalAccuracy = 0;
        totalDistance = 0;
    }
}
