using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScipt : MonoBehaviour
{
    public float Speed = 100;

    public WayPointRandom WayPoint;

    void Start()
    {
        
    }
    public void Move()
    {
        if (WayPoint == null)
            return;
        Vector3 vel = (WayPoint.transform.position - transform.position) * Speed * Time.deltaTime;
        vel.z = 0;
        this.transform.position += vel;
        if (vel.x < 0.001f && vel.y < 0.001)
            ChangePoint();
    }
    public void ChangePoint()
    {
        WayPoint =  (WayPointRandom)WayPoint.GetNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
