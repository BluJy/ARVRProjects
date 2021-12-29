using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBtnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gridone;
    public GameObject gridtwo;
    public GameObject gridthree;
    public GameObject gridfour;
    public GameObject gridfive;
    public GameObject gridsix;

    public void pressBtn()
    {
        

        if (!(RecordMotion.recordedTrajectoy.Count == 0))
        {
            User currentUser = MeasureBtnScript.user;
            List<Vector3> trajectoryPoints = RecordMotion.recordedTrajectoy;
            Trajectory trajectory = new Trajectory(trajectoryPoints, currentUser);
            RecordTrajectory.writeTrajectory(trajectory, "/MyAssets/Trajectories/trajectory.json");
            


            RecordMotion.isactive = false;
            gridone.SetActive(false);
            gridtwo.SetActive(true);
            gridthree.SetActive(false);
            gridfour.SetActive(false);
            gridfive.SetActive(false);
            gridsix.SetActive(false);

        }
        else {
            Debug.Log("SaveBtnScript: No trajectory saved, list was empty");
        }

       

    }
}
