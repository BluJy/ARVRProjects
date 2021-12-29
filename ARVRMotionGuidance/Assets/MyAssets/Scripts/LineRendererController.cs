using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    // Start is called before the first frame update

    private LineRenderer lr;
    private Vector3[] points;
 
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void setUpLine(Vector3[] points) {
        lr.positionCount = points.Length;
        this.points = points;
    }

    public void disableLine() {
        lr.positionCount = 0;
        this.points = new Vector3[0];
    }

    public void setColor(Color start, Color end) {
        //color % of 255 -> if you want white use (1,1,1,1)
        lr.SetColors(start, end);
    }

    public void setWidth(Color start, Color end)
    {
        lr.SetColors(start, end);
    }

    // Update is called once per frame
    private void Update()
    {
        if (points != null)
        {
            for (int i = 0; i < points.Length; i++)
            {
                lr.SetPosition(i, points[i]);
            }
        }
    }
}
