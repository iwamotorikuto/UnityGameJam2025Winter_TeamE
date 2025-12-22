///
/// 
/// プレイヤー2の行動と基本操作と行動範囲を制御するスクリプト
/// 
/// 
using UnityEngine;

public class Player2P : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 endPos;
    private Rigidbody2D rb;
    private GameManager gm;

    private bool isMoving = false;
    private bool hasEndedTurn = false;

    [SerializeField] float power = 10f;
    [SerializeField] float maxDistance = 5f;
    [SerializeField] float minDistance = 0f;

    [SerializeField] Vector2 minBounds = new Vector2(-1.56f, -1.78f);
    [SerializeField] Vector2 maxBounds = new Vector2(1.83f, 3.39f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gm == null) return;

        // ターン開始時にフラグリセット
        if (gm.GetCurrentPlayer() == 2 && !isMoving)
            hasEndedTurn = false;

        // 移動中の処理
        if (isMoving)
        {
            if (rb.velocity.magnitude < 0.05f)
            {
                rb.velocity = Vector2.zero;
                isMoving = false;

                if (!hasEndedTurn)
                {
                    gm.EndPlayerTurn();
                    hasEndedTurn = true;
                }
            }

            HandleBounds();
            return;
        }

        // Player2 のターンでなければ操作禁止
        if (!gm.IsPlayerTurn() || gm.GetCurrentPlayer() != 2)
            return;

        // ドラッグ開始
        if (Input.GetMouseButtonDown(0))
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ドラッグ終了
        if (Input.GetMouseButtonUp(0))
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 diff = startPos - endPos;
            Vector2 dir = diff.normalized;
            float distance = Mathf.Clamp(diff.magnitude, minDistance, maxDistance);

            rb.AddForce(dir * distance * power, ForceMode2D.Impulse);
            isMoving = true;
        }
    }

    void HandleBounds()
    {
        Vector2 pos = transform.position;

        // X方向
        if ((pos.x < minBounds.x && rb.velocity.x < 0) ||
            (pos.x > maxBounds.x && rb.velocity.x > 0))
        {
            rb.velocity = new Vector2(-rb.velocity.x / 1.5f, rb.velocity.y);

            if (rb.velocity.magnitude < 0.85f)
            {
                rb.velocity = Vector2.zero;

                if (!hasEndedTurn)
                {
                    gm.EndPlayerTurn();
                    hasEndedTurn = true;
                }
            }
        }

        // Y方向
        if ((pos.y < minBounds.y && rb.velocity.y < 0) ||
            (pos.y > maxBounds.y && rb.velocity.y > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y / 1.5f);

            if (rb.velocity.magnitude < 0.85f)
            {
                rb.velocity = Vector2.zero;

                if (!hasEndedTurn)
                {
                    gm.EndPlayerTurn();
                    hasEndedTurn = true;
                }
            }
        }
    }
}



