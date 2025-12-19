///
/// 
/// プレイヤー1Pの当たり判定を制御するスクリプト
/// 
/// S
using UnityEngine;


public class Player1PCollision : MonoBehaviour
{
    [Header("ボックス状の2Dの当たり判定"), SerializeField]
    private BoxCollider2D rbCollider;

    [Header("プレイヤーの2Dの当たり判定"), SerializeField]
    private Rigidbody2D rb;

    /// <summary>
    /// 2Dの当たり判定が入った時
    /// </summary>
    /// <param name="other"> 当たった当たり判定 </param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Enemyのみ当たったときの処理を施す

        if (!other.CompareTag("Enemy"))
        {
            return;
        }

        if (rb != null && rb.velocity != Vector2.zero)
        {
            // X方向とY方向を反転（減速付き）
            rb.velocity = new Vector2(rb.velocity.x / 1.5f, -rb.velocity.y / 1.5f);

            //反転の規模が0.85f以下になったら(0,0)にする
            if (rb.velocity.magnitude < 0.85f)
            {
                rb.velocity = Vector2.zero;
                // 攻撃したら GameManager に「ターン開始」を通知
                FindObjectOfType<GameManager>().StartPlayerTurn();
            }
        }
        rbCollider.enabled = true;
    }
    
}
