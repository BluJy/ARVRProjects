using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordMotion : MonoBehaviour
{
    public static bool isactive = false;
    public static List<Vector3> recordedTrajectoy;
    [SerializeField] public LineRendererController line;
    public static User user;


    void Update(){


        if (isactive == true)
        {


            if (ControllerInputHandler.isButtonPressed == false)
            {



            }

            else if (ControllerInputHandler.isButtonPressed == true)
            {
                Vector3 controllerPos = ControllerMeasurement.takeMeasurement();
                recordedTrajectoy.Add(controllerPos);

            }

            Trajectory coachTrajectory = new Trajectory(recordedTrajectoy, user);
            DisplayTrajectory.updateTrajectory(line, coachTrajectory);

        }

    }

    void OnDisable(){
        recordedTrajectoy = new List<Vector3>();

        //Remove Line Renderer
        DisplayTrajectory.disableTrajectory(line);
    }
}
