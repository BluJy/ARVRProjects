using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedBtn : MonoBehaviour
{
    public GameObject Eggy;
    public GameObject Chili;

    public void damaged()
    {
        Debug.Log("Unity Damaged");
        Eggy.GetComponent<Animator>().SetTrigger("damaged");
        Chili.GetComponent<Animator>().SetTrigger("damaged");
    }

}
