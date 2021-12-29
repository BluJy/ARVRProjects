using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownMotion : MonoBehaviour
{
    public TMP_Dropdown dropDownMotion;
    public static Trajectory chosenTrajectory;

    void Start() {

        Debug.Log(Application.dataPath.ToString());
        chosenTrajectory = RecordTrajectory.readTrajectory("/MyAssets/Trajectories/trajectory.json");
    }

        public void HandleInputData() {

            if (dropDownMotion.value == 0){
                chosenTrajectory = RecordTrajectory.readTrajectory("/MyAssets/Trajectories/trajectory.json");
            }
            else if (dropDownMotion.value == 1){
                chosenTrajectory = RecordTrajectory.readTrajectory("/MyAssets/Trajectories/trajectory1.json");
            }
            else if (dropDownMotion.value == 2){
                chosenTrajectory = RecordTrajectory.readTrajectory("/MyAssets/Trajectories/trajectory2.json");
            }

    }
}
