using System.Collections.Generic;
using UnityEngine;

public abstract class WayPoint : MonoBehaviour
{
    public List<WayPoint> ParentPoints { get; } = new List<WayPoint>();
    public List<WayPoint> ChildPoints { get; } = new List<WayPoint>();

    public GameObject a;

    void Awake()
    {
        if (a != null) ChildPoints.Add(a.GetComponent<WayPoint>());
    }

    public virtual WayPoint GetNextPoint()
    {
        return ChildPoints[0];
    }
}



public class WayPointRandom : WayPoint
{
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;

    private void Awake()
    {
        if (a != null)
            ChildPoints.Add(a.GetComponent<WayPoint>());
        if (b != null)
            ChildPoints.Add(b.GetComponent<WayPoint>());
        if (c != null)
            ChildPoints.Add(c.GetComponent<WayPoint>());
        if (d != null)
            ChildPoints.Add(d.GetComponent<WayPoint>());
        if (e != null)
            ChildPoints.Add(e.GetComponent<WayPoint>());
    }

    public override WayPoint GetNextPoint()
    {
        if (ChildPoints.Count == 0) return null;
        int rnd = Random.Range(0, ChildPoints.Count);
        return ChildPoints[rnd];
    }
}