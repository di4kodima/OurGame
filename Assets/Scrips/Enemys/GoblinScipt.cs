using Unity.Mathematics;
using UnityEngine;

public class Enemy_Goblin : MonoBehaviour
{
    public float Speed = 0.25f;
    public WayPointRandom WayPoint;
    private Vector3 MoveDirection;
    private SpriteRenderer sr;
    private Animator anim;



    private void Awake()
    {
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>(); // ƒл€ sr.flipX = true || false;
        anim = GetComponent<Animator>();                           // ƒл€ изменени€ анимаций путем изменени€ anim.SetInteger
    }



    void Start()
    {

    }



    void Update()
    {
        Move();
        ChangeMovingAnim();
    }



    /// <summary>
    /// ƒвижение к WayPoint
    /// </summary>
    public void Move()
    {
        if (WayPoint == null) { Destroy(gameObject); return; }                               // ѕри отсутствии следующей точки мы удал€ем врага
        MoveDirection = Vector3.Normalize(WayPoint.transform.position - transform.position); // ≈диничный вектор, в направлии от врага до WayPoint
        transform.position += MoveDirection * Time.deltaTime * Speed;                        // »змен€ем координаты врага
        
        if (Vector3.Distance(transform.position, WayPoint.transform.position) < 0.1f) ChangePoint(); //  огда враг дошел до WayPoint, он берет в качестве нового направлени€ движени€ следующий
    }



    /// <summary>
    /// »зменение вида анимации в зависимости от направлени€ движени€
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
    /// ѕросим любезно предоставить текущему WayPoint следующий.
    /// </summary>
    public void ChangePoint()
    {
        WayPoint = (WayPointRandom)WayPoint.GetNextPoint();
    }
}
