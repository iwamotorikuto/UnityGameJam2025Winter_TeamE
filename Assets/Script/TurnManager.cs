using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TurnState
{
    PlayerTurn,
    EnemyTurn,
    //Busy
}

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    public TurnState currentTurn;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentTurn = TurnState.PlayerTurn;
    }

    void Update()
    {

    }


    public void EndPlayerTurn()
    {
        currentTurn = TurnState.EnemyTurn;
    }
}


