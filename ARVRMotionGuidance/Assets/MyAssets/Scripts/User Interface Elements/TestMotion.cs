using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMotion : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool isactive = false;
    public static List<Trajectory> allTrajectories = new List<Trajectory>();
    public static List<Vector3> currentTrajectory = new List<Vector3>();
    public static List<Vector3> coachTrajectoryPoints;
    public static User user;
    public static Trajectory coachTrajectory;
    public static int iterationCount;

    void OnEnable() {

        Start();

    }

    void Start()
    {
        iterationCount = 0;
        user = MeasureBtnScript.user;
        isactive = true;
        Trajectory unscaledCoachTrajectory = DropDownMotion.chosenTrajectory;
        coachTrajectory = TrajectoryScaling.scaleTrajectory(unscaledCoachTrajectory, user);
        coachTrajectoryPoints = coachTrajectory.getTrajectoryPoints();
    }


    void Update()
    {

        if (isactive == true)
        {

            if (ControllerInputHandler.isButtonPressed == false)
            {


            }

            else if (ControllerInputHandler.isButtonPressed == true)
            {
                
                Vector3 controllerPos = ControllerMeasurement.takeMeasurement();
                currentTrajectory.Add(controllerPos);

            }

        }
        else if (isactive == false)
        {


        }


    }
}
