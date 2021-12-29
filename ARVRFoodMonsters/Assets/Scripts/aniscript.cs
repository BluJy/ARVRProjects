using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aniscript : MonoBehaviour
{

    public Animator myAnimator;
    public float statusRepresent;

    void Start()
    {
        statusRepresent = 1;
    }

    void Update()
    {
        myAnimator.SetFloat("status", statusRepresent);
    }
}
