using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBtn : MonoBehaviour
{
    public GameObject Eggy;
    public GameObject Chili;
    public void walk()
    {
        Debug.Log("Unity Walk");
        Eggy.GetComponent<Animator>().SetTrigger("walk");
        Chili.GetComponent<Animator>().SetTrigger("walk");
    }

}
