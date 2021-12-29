using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnReturnBtnScript : MonoBehaviour
{
    public GameObject gridone;
    public GameObject gridtwo;
    public GameObject gridthree;
    public GameObject gridfour;
    public GameObject gridfive;
    public GameObject gridsix;

    public void pressBtn()
    {
        LearnMotion.isactive = false;
        LearnMotion.currentTrajectory = new List<Vector3>();
        LearnMotion.allTrajectories = new List<Trajectory>();
        LearnMotion.iterationCount = 0; 
        gridone.SetActive(false);
        gridtwo.SetActive(true);
        gridthree.SetActive(false);
        gridfour.SetActive(false);
        gridfive.SetActive(false);
        gridsix.SetActive(false);

    }
}
