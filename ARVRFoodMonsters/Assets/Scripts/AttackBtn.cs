using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBtn : MonoBehaviour
{
    public GameObject Eggy;
    public GameObject Chili;

    public void attack()
    {
        Debug.Log("Unity Attack");
        Eggy.GetComponent<Animator>().SetTrigger("attack");
        Chili.GetComponent<Animator>().SetTrigger("attack");
        
    }

    
}
