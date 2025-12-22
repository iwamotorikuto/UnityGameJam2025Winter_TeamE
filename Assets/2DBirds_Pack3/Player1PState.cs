///
///
///Player1Pの体力を管理するスクリプト
///
///
using UnityEngine;

public class Player1PState : MonoBehaviour
{
    [Header("プレイヤーの最大体力"), SerializeField]
    private float maxHealth = 100;

    [Header("プレイヤーの現状の体力"), SerializeField]
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //当たり判定でダメージを受ける
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }

    //ダメージ処理
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

    }

}
