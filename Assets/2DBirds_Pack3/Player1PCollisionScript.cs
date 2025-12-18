///
/// 
/// プレイヤー1Pの当たり判定を制御するスクリプト
/// 
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1PCollisionScript : MonoBehaviour
{
    private BoxCollider2D col;
    private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D rbCollider;


    // Start is called before the first frame update
    void Start()
    {
        //当たり判定の追加
        col = GetComponent<BoxCollider2D>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Enemyに当たったら
        {
            if (rb != null && rb.velocity != Vector2.zero)
            {
                // X方向とY方向を反転（減速付き）
                rb.velocity = new Vector2(rb.velocity.x / 1.5f,  -rb.velocity.y / 1.5f);
            }


            rbCollider.enabled = true;

        }
    }
   
      


}
