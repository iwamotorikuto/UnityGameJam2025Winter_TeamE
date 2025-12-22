///
/// 
/// プレイヤー２の体力を管理するスクリプト
/// 
/// 
using UnityEngine;

public class Player2PState : MonoBehaviour
{
    [Header("プレイヤー２の最大体力"), SerializeField]
    private float maxHealth = 100;

    [Header("プレイヤー２の現時点の体力"), SerializeField]
    private float currentHealth;

   
    void Start()
    {
        currentHealth = 100;
    }

    void Update()
    {
        
    }

    //当たり判定でダメージを受ける
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
