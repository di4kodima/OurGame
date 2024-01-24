using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WayPointRandom : MonoBehaviour, IWayPoint
{
    public List<IWayPoint> ParentPoints { get; } = new List<IWayPoint>();
    public List<IWayPoint> ChildPoints { get; } = new List<IWayPoint>();

    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;

    void Awake()
    {
        if (a != null)
            ChildPoints.Add(a.GetComponent<IWayPoint>());
        if(b != null)
            ChildPoints.Add(b.GetComponent<IWayPoint>());
        if(c != null)
            ChildPoints.Add(c.GetComponent<IWayPoint>());
        if(d != null)
            ChildPoints.Add(d.GetComponent<IWayPoint>());
        if(e != null)
            ChildPoints.Add(e.GetComponent<IWayPoint>());
    }

    public IWayPoint GetNextPoint()
    {
        if (ChildPoints.Count == 0) return null;
        int rnd = Random.Range(0, ChildPoints.Count);
        return ChildPoints[rnd];
    }
}
