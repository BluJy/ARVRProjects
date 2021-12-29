using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasureBtnScript : MonoBehaviour
{
    public GameObject gridone;
    public GameObject gridtwo;
    public GameObject gridthree;
    public GameObject gridfour;
    public GameObject gridfive;
    public GameObject gridsix;
    public int measurementcounter;

    public static Vector3 rightPoint;
    public static Vector3 bottomPoint;
    
    public static Vector3 userShoulderPoint;
    public static float userArmLength;

    public static User user;

    public GameObject statisticsLabel;
    public GameObject diagnostics; 
    public string text;

    [SerializeField] private LineRendererController coachline;
    [SerializeField] private LineRendererController rubberbandline;
    [SerializeField] private LineRendererController asymptoticline;

 

    public void Start() {
        
        gridtwo.SetActive(false);
        gridthree.SetActive(false);
        gridfour.SetActive(false);
        gridfive.SetActive(false);
        gridsix.SetActive(false);

        //Disable Coach Trajectory
        DisplayTrajectory.disableTrajectory(coachline);
        //Disable RubberBand
        RubberBand.disableRubberBand(rubberbandline);

        AsymptoticTrajectory.disableAsymptoticTrajectory(asymptoticline);
        diagnostics = GameObject.Find("Diagnostics");
        diagnostics.SetActive(false);

    }

    public void pressBtn() {

        //Hardcoded for use without VR headset
        measure();
        measure();

        gridone.SetActive(false);
        gridtwo.SetActive(true);
        gridthree.SetActive(false);
        gridfour.SetActive(false);
        gridfive.SetActive(false);
        gridsix.SetActive(false);

    }


    public void measure() {

        if (measurementcounter == 0){

            measurementcounter += 1;
            rightPoint = ControllerMeasurement.takeMeasurement();

            text = "";
            text += "Determine Arm Length";
            text += "\n";
            text += "first position: " + rightPoint;
            text += "\n";
            text += "second position: incomplete";
            text += "\n";
            text += "shoulder point: none";
            text += "\n";
            text += "arm length: none";
            statisticsLabel.GetComponent<TMPro.TextMeshProUGUI>().text = text;

            }

        else{

            measurementcounter += 1;
            bottomPoint = ControllerMeasurement.takeMeasurement();

            //Hardcoded for use without VR headset
            rightPoint = new Vector3((float)0.8, (float)0.1, (float)-0.4);
            bottomPoint = new Vector3((float)0.3, (float)-0.5, (float)-0.3);
            userShoulderPoint = new Vector3((float)-9.01900005, (float)-1.28069997, (float)-1.05120003);

            userShoulderPoint = new Vector3((float)bottomPoint.x, (float)rightPoint.y, (float)bottomPoint.z);
            userArmLength = ControllerMeasurement.calculateVectorDistance(userShoulderPoint, rightPoint);
            user = new User(userShoulderPoint, userArmLength);


            text = "";
            text += "Determine Arm Length";
            text += "\n";
            text += "first position: " + rightPoint;
            text += "\n";
            text += "second position: " + bottomPoint;
            text += "\n";
            text += "shoulder point: " + userShoulderPoint;
            text += "\n";
            text += "arm length: " + userArmLength;
            statisticsLabel.GetComponent<TMPro.TextMeshProUGUI>().text = text;

            }

    }

}
