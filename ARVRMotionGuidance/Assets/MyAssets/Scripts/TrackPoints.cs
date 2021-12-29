using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPoints : MonoBehaviour
{

    GameObject obj;
    LineRenderer lr;
    List<Vector3> parts = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.position);
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        parts.Add(transform.position);
        //Debug.Log(parts);
        lr.positionCount = parts.Count;
        for (int i = 0; i < parts.Count; i++)
        {
           lr.SetPosition(i, parts[i]);
        };
    }
}
