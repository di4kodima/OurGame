using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WayPointRandom : MonoBehaviour, IWayPoint
{
    public List<WayPointRandom> PastPoints { get; set; }
    public List<WayPointRandom> NextPoints { get; set; }

    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;

    void Awake()
    {
        NextPoints = new List<WayPointRandom>();
        PastPoints = new List<WayPointRandom>();

        if (a != null)
            NextPoints.Add(a.GetComponent<WayPointRandom>());
        if(b != null)
            NextPoints.Add(b.GetComponent<WayPointRandom>());
        if(c != null)
            NextPoints.Add(c.GetComponent<WayPointRandom>());
        if(d != null)
            NextPoints.Add(d.GetComponent<WayPointRandom>());
        if(e != null)
            NextPoints.Add(e.GetComponent<WayPointRandom>());
    }

    public IWayPoint GetNextPoint()
    {
        int rnd = Random.Range(0, NextPoints.Count);
        return NextPoints[rnd];
    }

    public List<IWayPoint> GetPastPoints()
    {
        List<IWayPoint> convertedPastPoints = new List<IWayPoint>(PastPoints.Cast<IWayPoint>());
        return convertedPastPoints;
    }

    public List<IWayPoint> GetNextPoints()
    {
        List<IWayPoint> convertedNextPoints = new List<IWayPoint>(NextPoints.Cast<IWayPoint>());
        return convertedNextPoints;
    }
}
