using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс для обработки глобальных событий
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameEvents _gameState;
    public GameEvents gameState { get { return _gameState; } }

    public static Action <GameEvents, object> GameEventsHandler; // Делегат подписки на события


    private void Awake()
    {
        Instance = this;
    }

    public void InvokeGameEvent(GameEvents gameEvent, object obj)
    {
        _gameState = gameEvent;

        switch (gameEvent)
        {
            case GameEvents.EnemyKilled:
                Debug.Log("Enemy killed Event happens!");
                break;
            case GameEvents.PlayerBuiltStructure:
                Debug.Log("Enemy killed Event happens!");
                break;
            case GameEvents.EnemyEnteredInTheTown:
                Debug.Log("Enemy entered in the Town!");
                break;
            default:
                break;
        }

        GameEventsHandler?.Invoke(gameEvent, obj);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Enemy enemy = FindAnyObjectByType<Enemy>();
            if (enemy != null)
            {
                enemy.Death();
            }
        }
    }
}

public enum GameEvents
{
    EnemyKilled,
    PlayerBuiltStructure,
    EnemyEnteredInTheTown,
}