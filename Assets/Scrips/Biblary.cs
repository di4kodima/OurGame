using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    string Name { get; }
}

public interface IWayPoint
{
    public List<IWayPoint> ParentPoints { get; }
    public List<IWayPoint> ChildPoints { get; }

    public IWayPoint GetNextPoint();
}