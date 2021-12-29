using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnMotion : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool isactive = false;
    public static List<Trajectory> allTrajectories = new List<Trajectory>();
    public static List<Vector3> currentTrajectory = new List<Vector3>();
    public static List<Vector3> coachTrajectoyPoints;
    [SerializeField] private LineRendererController coachline;
    [SerializeField] private LineRendererController rubberbandline;
    [SerializeField] private LineRendererController asymptoticline;
    public static User user;
    public static Trajectory coachTrajectory;
    public static int iterationCount;
    public static string chosenMethod;


    void Start()
    {
        iterationCount = 0; 
        user = MeasureBtnScript.user;
        isactive = true;
        Trajectory unscaledCoachTrajectory = DropDownMotion.chosenTrajectory;

        coachTrajectory = TrajectoryScaling.scaleTrajectory(unscaledCoachTrajectory, user);
        coachTrajectoyPoints = coachTrajectory.getTrajectoryPoints();

        //Test without scaling later remove
        //coachTrajectory = unscaledCoachTrajectory;
        //coachTrajectoyPoints = unscaledCoachTrajectory.getTrajectoryPoints();

        chosenMethod = DropDownMethod.chosenMethod;

    }

    void OnEnable()
    {
        Start();
    }

    void OnDisable() {

        //Disable Coach Trajectory
        DisplayTrajectory.disableTrajectory(coachline);
        //Disable RubberBand
        RubberBand.disableRubberBand(rubberbandline);
        //Disable Asymptotic Trajectory
        AsymptoticTrajectory.disableAsymptoticTrajectory(asymptoticline);

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

            //Display Coach Trajectory
            DisplayTrajectory.updateTrajectory(coachline, coachTrajectory);

            if (chosenMethod == "RubberBand")
            {
                //Display RubberBand
                RubberBand.updateRubberBand(rubberbandline, coachTrajectory, ControllerMeasurement.takeMeasurement(), (float)0.3);
            }
            else if (chosenMethod == "AsymptoticTrajectory") {

                //Display AsymptoticTrajectory
                AsymptoticTrajectory.updateAsymptoticTrajectory(asymptoticline, coachTrajectory, ControllerMeasurement.takeMeasurement());
            
            }

        }
        else if (isactive == false) {
            

        }


    }
}
