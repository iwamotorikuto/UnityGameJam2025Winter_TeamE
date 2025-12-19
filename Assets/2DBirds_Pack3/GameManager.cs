///
///
///プレイヤーのターンを制御するスクリプト
///
///
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    [Header("プレイヤー１Pの登録"), SerializeField]
    private Object Player1P;

    [Header("プレイヤーのターンの判断"), SerializeField]
    private bool isPlayerTurn = true;

    [Header("ターン数"), SerializeField]
    private int TurnCount = 0;

    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

    void Start()
    {
        StartPlayerTurn();
    }

    void Update()
    {
        
    }

    // プレイヤーの攻撃ターン開始
    public void StartPlayerTurn()
    {
        isPlayerTurn = true;
        TurnCount++;
        Debug.Log("ターン開始！ 現在のターン数: " + TurnCount);
    }

    // プレイヤーの攻撃ターン終了
    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        Debug.Log("ターン終了！");

        // 今は敵ターンを作らないので、すぐ次のプレイヤーターンへ
        Invoke(nameof(StartPlayerTurn), 1.0f); // 1秒後に次のターン開始
    }
}

