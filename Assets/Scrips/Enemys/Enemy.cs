using Unity.Mathematics;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class Enemy : MonoBehaviour
{
	public WayPoint WayPoint;
	private Vector3 MoveDirection;
	private SpriteRenderer sr;
	private Animator anim;

    public float Health;
    public float Speed;
    public float Damage;
	public int Reward;


	protected void Awake()
	{
		sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
    }

	protected void Start()
	{
        
    }

	protected void Update()
	{
	}

	void TimeStop()
    {
        Animator anim = transform.GetComponent<Animator>();
        anim.speed = 0;
	}

	void TimeUpdate(float boost)
	{
		Move();
		ChangeMovingAnim();
		Animator anim = transform.GetComponent<Animator>();
		anim.speed = boost;
	}


	public virtual void Move()
	{
        if (WayPoint == null) { EnteredInTheTown(); return; }
        MoveDirection = Vector3.Normalize(WayPoint.transform.position - transform.position);
		transform.position += MoveDirection * Speed;
		
		if (Vector3.Distance(transform.position, WayPoint.transform.position) < 0.1f) ChangePoint();
    }

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
    public void Death()
	{
        GameManager.Instance.InvokeGameEvent(GameEvents.EnemyKilled, this);
        Destroy(gameObject);
		return;
    }

	public void EnteredInTheTown()
	{
		GameManager.Instance.InvokeGameEvent(GameEvents.EnemyEnteredInTheTown, this);
        Destroy(gameObject);
        return;
    }

	public virtual void ChangePoint()
	{
		WayPoint = WayPoint.GetNextPoint();
	}
}
