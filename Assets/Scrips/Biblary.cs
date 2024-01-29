using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnem
{
    string Name { get; }
}

public enum Enemys
{ Goblin, Ogr }
public interface IWayPoint
{
    public List<IWayPoint> ParentPoints { get; }
    public List<IWayPoint> ChildPoints { get; }

    public IWayPoint GetNextPoint();
}

public interface IEnemy
{
    public void Move();
}

public abstract class GumanoidEnemy :  MonoBehaviour, IEnemy
{
    public float Health;
    public float Speed;
    static float MaxHealth;
    static float MaxSpeed;
    static float Damage;
    public abstract void Move();

}