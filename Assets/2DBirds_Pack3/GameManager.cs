///
///
///プレイヤーのターンを制御するスクリプト
///
///
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("現在のプレイヤー番号（1 or 2）")]
    [SerializeField] private int currentPlayer = 1;

    [Header("プレイヤーのターン中かどうか")]
    [SerializeField] private bool isPlayerTurn = true;

    [Header("ターン数")]
    [SerializeField] private int turnCount = 0;

    public bool IsPlayerTurn() => isPlayerTurn;
    public int GetCurrentPlayer() => currentPlayer;

    void Start()
    {
        StartPlayerTurn();
    }

    // プレイヤーの攻撃ターン開始
    public void StartPlayerTurn()
    {
        isPlayerTurn = true;
        turnCount++;
        Debug.Log($"ターン開始！ 現在のターン数: {turnCount}  現在のプレイヤー: {currentPlayer}");
    }

    // プレイヤーの攻撃ターン終了
    public void EndPlayerTurn()
    {
        if (!isPlayerTurn) return; // 二重呼び出し防止

        isPlayerTurn = false;
        Debug.Log("ターン終了！");

        // プレイヤー交代
        currentPlayer = (currentPlayer == 1) ? 2 : 1;

        // 1秒後に次のターン開始
        Invoke(nameof(StartPlayerTurn), 1.0f);
    }
}
