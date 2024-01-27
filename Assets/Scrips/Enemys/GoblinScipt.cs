using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy_Goblin : MonoBehaviour
{
    public float Speed = 0.25f;
    public Sprite Goblin_Front;
    public Sprite Goblin_Back;
    public Sprite Goblin_Right;
    public Sprite Goblin_Left;
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

        ChangeMovingSprite();
    }

    void ChangeMovingSprite() {
        SpriteRenderer spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        float maxCoord = math.max(math.abs(MoveDirection.x), math.abs(MoveDirection.y));

        if (maxCoord == MoveDirection.x) spriteRenderer.sprite = Goblin_Right;
        else if (maxCoord == -MoveDirection.x) spriteRenderer.sprite = Goblin_Left;
        if (maxCoord == MoveDirection.y) spriteRenderer.sprite = Goblin_Back;
        else if (maxCoord == -MoveDirection.y) spriteRenderer.sprite = Goblin_Front;
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
