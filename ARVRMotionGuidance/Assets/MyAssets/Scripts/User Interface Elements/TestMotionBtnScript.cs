using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMotionBtnScript : MonoBehaviour
{
    public GameObject gridone;
    public GameObject gridtwo;
    public GameObject gridthree;
    public GameObject gridfour;
    public GameObject gridfive;
    public GameObject gridsix;

    public void pressBtn()
    {
        TestMotion.isactive = true;
        gridone.SetActive(false);
        gridtwo.SetActive(false);
        gridthree.SetActive(false);
        gridfour.SetActive(false);
        gridfive.SetActive(false);
        gridsix.SetActive(true);

    }
}
