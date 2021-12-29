using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{

    public static float accuracy(Trajectory t1, Trajectory t2) {

        //TODO Might need rework: now calculates if each point in the users trajectory was in the vicinity of the coach trajectory
        //Debug.Log(t1.toString());
        //Debug.Log(t2.toString());

        float totaldistance = 0;
        Vector3[] t1list = t1.getTrajectoryPoints().ToArray();
        Vector3[] t2list = t2.getTrajectoryPoints().ToArray();
        int listlength = Mathf.Min(t1list.Length, t2list.Length);
        int totalfaults = 0;
        int totalcorrect = 0;
        float faulttolerance = (float)0.2;

        for (int i = 0; i < listlength; i++){
            float currentdistance = calculateVectorDistance(t1list[i], t2list[i]);
            totaldistance += currentdistance;

            if (currentdistance > faulttolerance) {
                totalfaults += 1;
            } else if (currentdistance <= faulttolerance) {
                totalcorrect += 1;
            }
        }

        //Debug.Log("Statistics: Totalfaults: " + totalfaults);
        //Debug.Log("Statistics: Totalcorrect: " + totalcorrect);

        float accuracy = (float)(((float)totalcorrect) / ((float)totalfaults + (float)totalcorrect));

        //Debug.Log("Statistics: accuracy: " + accuracy);

        return accuracy;

    }


    public static float distance(Trajectory usertrajectory, Trajectory coachtrajectory) {
        float totaldistance = 0;
        Vector3[] t1list = usertrajectory.getTrajectoryPoints().ToArray();
        Vector3[] t2list = coachtrajectory.getTrajectoryPoints().ToArray();

        Vector3 closestVector = new Vector3(0, 0, 0);
        float closestDistance = float.MaxValue;
        foreach (Vector3 uservector in t1list) {

            foreach (Vector3 coachvector in t2list) {

                float vectordistance = calculateVectorDistance(uservector, coachvector);
                if (vectordistance < closestDistance) {
                    closestDistance = vectordistance;
                    closestVector = coachvector;
                }

            }

            totaldistance += closestDistance;
            closestDistance = float.MaxValue;
            closestVector = new Vector3(0, 0, 0);

        }

        return totaldistance;
    }


    public static float calculateVectorDistance(Vector3 pointone, Vector3 pointtwo)
    {
        
        float xdistance = (float)Mathf.Pow((float)pointone.x - (float)pointtwo.x, 2);
        float ydistance = (float)Mathf.Pow((float)pointone.y - (float)pointtwo.y, 2);
        float zdistance = (float)Mathf.Pow((float)pointone.z - (float)pointtwo.z, 2);
        float sumOfSquares = (float)xdistance + (float)ydistance + (float)zdistance;
        float distance = (float)Mathf.Sqrt((float)sumOfSquares);
        return (float)distance;

    }

}
