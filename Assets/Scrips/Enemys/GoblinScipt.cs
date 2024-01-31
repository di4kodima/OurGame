using Unity.Mathematics;
using UnityEngine;

public class Enemy_Goblin : GumanoidEnemy
{
    public Sprite Goblin_Front;
    public Sprite Goblin_Back;
    public Sprite Goblin_Right;
    public Sprite Goblin_Left;
    public WayPointRandom WayPoint;
    private Vector3 MoveDirection;
    private SpriteRenderer sr;
    private Animator anim;



    private void Awake()
    {
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>(); // ��� sr.flipX = true || false;
        anim = GetComponent<Animator>();                           // ��� ��������� �������� ����� ��������� anim.SetInteger
    }



    void Start()
    {
        //TimeTicker.Instance.Tickk += Move;
        //TimeTicker.Instance.Tickk += ChangePoint;
        TimeTicker.Instance.Tickk += Hello;
    }

    void Hello() => Debug.Log("Ns kj[!");


    void Update()
    {
        Move();
        ChangeMovingAnim();
    }
    public override void Move()
    {
        if (WayPoint == null) 
            { Destroy(gameObject); return; }                               // ��� ���������� ��������� ����� �� ������� �����
        MoveDirection = Vector3.Normalize(WayPoint.transform.position - transform.position); // ��������� ������, � ��������� �� ����� �� WayPoint
        transform.position += MoveDirection * Time.deltaTime * Speed;                        // �������� ���������� �����
        
        if (Vector3.Distance(transform.position, WayPoint.transform.position) < 0.1f) ChangePoint(); // ����� ���� ����� �� WayPoint, �� ����� � �������� ������ ����������� �������� ���������
    }



    /// <summary>
    /// ��������� ���� �������� � ����������� �� ����������� ��������
    /// </summary>
    void ChangeMovingAnim() {
        float maxCoord = math.max(math.abs(MoveDirection.x), math.abs(MoveDirection.y));
        if (maxCoord == MoveDirection.x)
        {
            anim.SetInteger("move_direction", 0);
            sr.flipX = false;
        }
        else if (maxCoord == -MoveDirection.x)
        {
            anim.SetInteger("move_direction", 0);
            sr.flipX = true;
        }
        if (maxCoord == MoveDirection.y) anim.SetInteger("move_direction", -1);
        else if (maxCoord == -MoveDirection.y) anim.SetInteger("move_direction", 1);
    }
    


    /// <summary>
    /// ������ ������� ������������ �������� WayPoint ���������.
    /// </summary>
    public void ChangePoint()
    {
        WayPoint = (WayPointRandom)WayPoint.GetNextPoint();
    }
}
