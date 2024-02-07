using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Класс игрока
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField] private int startMoney;
    [SerializeField] private int startHealth;
    private int _health;
    private PlayerMoney _money;
    public PlayerMoney money { get { return _money; } set
        {
            _money = value;
            moneyRenderer.updateText(_money.ToString());
        }
    }

    public int health
    {
        get { return _health; }
        set
        {
            _health = value;
            healthRenderer.updateText(_health.ToString());
        }
    }

    public static Player Instance;
    [SerializeField] private TextRenderer moneyRenderer;
    [SerializeField] private TextRenderer healthRenderer;

    private void Awake()
    {
        Instance = this;
        Enemy.OnKilled += OnEnemyKilled;
        Enemy.OnEnteredInTheTown += OnEnemyEnterInTheTown;
        BuildingsPlacer.OnPlayerBuiltStructure += OnBuiltStructure;
    }

    private void Start()
    {
        health = startHealth;
        money = startMoney;
    }

    private void OnDestroy()
    {
        Enemy.OnKilled -= OnEnemyKilled;
        Enemy.OnEnteredInTheTown -= OnEnemyEnterInTheTown;
        BuildingsPlacer.OnPlayerBuiltStructure -= OnBuiltStructure;
    }

    private void OnEnemyKilled(Enemy enemy)
    {
        money += enemy.Reward;
        moneyRenderer.updateText(money.ToString());
    }

    private void OnEnemyEnterInTheTown(Enemy enemy) { 
        health -= enemy.Damage;
    }

    private void OnBuiltStructure(Tower tower)
    {
        money = money.Spend(tower.cost);
    }
}
