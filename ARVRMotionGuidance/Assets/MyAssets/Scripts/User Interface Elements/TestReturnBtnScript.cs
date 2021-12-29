using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestReturnBtnScript : MonoBehaviour
{
    public GameObject gridone;
    public GameObject gridtwo;
    public GameObject gridthree;
    public GameObject gridfour;
    public GameObject gridfive;
    public GameObject gridsix;

    public void pressBtn()
    {
        TestMotion.isactive = false;
        TestMotion.currentTrajectory = new List<Vector3>();
        TestMotion.allTrajectories = new List<Trajectory>();
        gridone.SetActive(false);
        gridtwo.SetActive(true);
        gridthree.SetActive(false);
        gridfour.SetActive(false);
        gridfive.SetActive(false);
        gridsix.SetActive(false);

    }
}
