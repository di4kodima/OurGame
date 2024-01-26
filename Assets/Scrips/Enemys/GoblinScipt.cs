using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy_Goblin : MonoBehaviour
{
    public float Speed = 0.1f;
    public WayPointRandom WayPoint;

    private Vector3 MoveDirection;

    void Start()
    {
        Debug.Log("I born!");
    }
    public void Move()
    {
        if (WayPoint == null) return;

        MoveDirection = Vector3.Normalize(WayPoint.transform.position - transform.position);
        transform.position += MoveDirection * Time.deltaTime * Speed;
        
        if (Vector3.Distance(transform.position, WayPoint.transform.position) < 0.1f) ChangePoint();
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
