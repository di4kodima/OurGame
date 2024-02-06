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
    public PlayerMoney money;

    public static Player Instance;
    [SerializeField] private MoneyRenderer moneyRenderer;

    private void Awake()
    {
        GameManager.GameEventsHandler += OnEnemyKilled;
        GameManager.GameEventsHandler += OnBuiltStructure;
        money = startMoney;
        Instance = this;
    }

    private void OnDestroy()
    {
        GameManager.GameEventsHandler -= OnEnemyKilled;
        GameManager.GameEventsHandler -= OnBuiltStructure;
    }

    private void OnEnemyKilled(GameEvents events, object obj)
    {
        if (events == GameEvents.EnemyKilled)
        {
            if (!(obj as Enemy)) return;
            int enemyReward = ((Enemy)obj).Reward;
            addMoneyAmount(enemyReward);
        }
    }

    private void OnBuiltStructure(GameEvents events, object obj)
    {
        if (events == GameEvents.PlayerBuiltStructure)
        {
            if (!(obj as Tower)) return;
            int buildings_cost = ((Tower)obj).cost;
            spentMoneyAmount(buildings_cost);
        }
    }

    public void addMoneyAmount(int amount)
    {
        money += amount;
        moneyRenderer.updateMoneyCount(money);
    }

    public void spentMoneyAmount(int amount)
    {
        money.Spend(amount);
        moneyRenderer.updateMoneyCount(money);
    }
}
