using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordBtnScript : MonoBehaviour
{
    public GameObject gridone;
    public GameObject gridtwo;
    public GameObject gridthree;
    public GameObject gridfour;
    public GameObject gridfive;
    public GameObject gridsix;


    public void pressBtn()
    {
        RecordMotion.user = MeasureBtnScript.user;
        RecordMotion.isactive = true;
        RecordMotion.recordedTrajectoy = new List<Vector3>();

        gridone.SetActive(false);
        gridtwo.SetActive(false);
        gridthree.SetActive(false);
        gridfour.SetActive(true);
        gridfive.SetActive(false);
        gridsix.SetActive(false);


    }

}
