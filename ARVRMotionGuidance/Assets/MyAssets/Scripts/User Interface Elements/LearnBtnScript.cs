using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnBtnScript : MonoBehaviour
{

    public GameObject gridone;
    public GameObject gridtwo;
    public GameObject gridthree;
    public GameObject gridfour;
    public GameObject gridfive;
    public GameObject gridsix;


    public static User user;

    public void pressBtn()
    {
        gridone.SetActive(false);
        gridtwo.SetActive(false);
        gridthree.SetActive(true);
        gridfour.SetActive(false);
        gridfive.SetActive(false);
        gridsix.SetActive(false);
        LearnMotion.isactive = true;


        //coachline.SetActive(true);

        //if (DropDownMethod.chosenMethod == "RubberBand"){
        //    rubberbandline.SetActive(true);
        //}
        //else if (DropDownMethod.chosenMethod == "AsymptoticTrajectory") {
        //    asymptoticline.SetActive(true);
        //}

           

        //user = MeasureBtnScript.user;
        //Trajectory coachTrajectory = RecordTrajectory.readTrajectory("/MyAssets/Trajectories/trajectory.json");
        //Trajectory coachTrajectoryScaled = TrajectoryScaling.calculateTrajectory(coachTrajectory, user.getShoulderPoint(), user.getArmLength());
        //Debug.Log(coachTrajectoryScaled.toString());

    }

}
