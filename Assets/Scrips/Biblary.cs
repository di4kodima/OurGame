using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biblary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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