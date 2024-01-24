using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy_Goblin : MonoBehaviour
{
    public float SpeedX = 0.1f;
    public float SpeedY = 0.1f;

    public WayPointRandom WayPoint;

    void Start()
    {
        
    }
    public void Move()
    {
        if (WayPoint == null) return;

        Vector3 res = transform.position;

        if (WayPoint.transform.position.x > transform.position.x) res.x += SpeedX * Time.deltaTime;
        else res.x -= SpeedX * Time.deltaTime;

        if (WayPoint.transform.position.y > transform.position.y) res.y += SpeedY * Time.deltaTime;
        else res.y -= SpeedY * Time.deltaTime;
        
        transform.position = res;
        
        if (math.abs(res.x - WayPoint.transform.position.x) < 0.1f && math.abs(res.y - WayPoint.transform.position.y) < 0.1f) ChangePoint();
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
