///
/// 
/// プレイヤーの行動と操作と行動範囲を制御するスクリプト
/// 
/// 
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player1P: MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 endPos;
    private Rigidbody2D rb;
     
    [Header("ドラッグによる力の倍率"),SerializeField] 
    float power = 10f;　

    [Header("ドラッグ距離の最大範囲"),SerializeField] 
    float maxDistance = 5f;

    [Header("ドラッグ距離の最小範囲"),SerializeField] 
    float minDistance = 0f;

    [Header("最小限界行動範囲"),SerializeField] 
    Vector2 minBounds = new Vector2(-1.56f, -1.78f); 
    [Header("最大限界行動範囲"),SerializeField] 
    Vector2 maxBounds = new Vector2(1.83f, 3.39f);

    /// <summary>
    /// プレイヤーの操作
    /// </summary>
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        // ドラッグ開始
        if (Input.GetMouseButtonDown(0))
        {
            //マウス位置をワールド座標に変換（開始）
            startPos = Camera.main.ScreenToWorldPoint(
                new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }

        // ドラッグ終了
        if (Input.GetMouseButtonUp(0))
        {
            //マウス位置をワールド座標に変換（終了)
            endPos = Camera.main.ScreenToWorldPoint(
                new Vector2(Input.mousePosition.x, Input.mousePosition.y));

            if (rb != null)
            {

                //距離計算
                Vector2 diff = startPos - endPos;　//開始位置と終了位置の計算
                Vector2 dir = diff.normalized;　// 移動ベクトルの正規化
                float distance = Mathf.Clamp(diff.magnitude, minDistance, maxDistance); // 距離制限

                rb.AddForce(dir * distance * power, ForceMode2D.Impulse);　//RigidBody2Dに力を加えた分、移動

            }

        }

        // 境界処理（AABB）
        Vector2 pos = transform.position;

        //X方向の境界確認
        if ((pos.x < minBounds.x && rb.velocity.x < 0) || (pos.x > maxBounds.x && rb.velocity.x > 0))
        {
            rb.velocity = new Vector2(-rb.velocity.x / 1.5f, rb.velocity.y);

            //反転の規模が0.85f以下になったら(0,0)にする
            if (rb.velocity.magnitude < 0.85f)
            {
                rb.velocity = Vector2.zero;
                // 攻撃したら GameManager に「ターン開始」を通知
                FindObjectOfType<GameManager>().StartPlayerTurn();
            }

        }

        //Y座標の境界確認
        if ((pos.y < minBounds.y && rb.velocity.y < 0) || (pos.y > maxBounds.y && rb.velocity.y > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y / 1.5f);

            //反転の規模が0.85以下になったら(0,0)にする 
            if (rb.velocity.magnitude < 0.85f)
            {
                rb.velocity = Vector2.zero;
                // 攻撃したら GameManager に「ターン開始」を通知
                FindObjectOfType<GameManager>().StartPlayerTurn();
            }

        }

    }
  
}









