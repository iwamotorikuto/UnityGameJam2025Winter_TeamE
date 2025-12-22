using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{
    public int attackInterval = 5;
    public Image healthImage;
    public int maxHealth = 100;
    private int currentHealth;

    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        UpdateHPBar();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TakeDamage(10);
        }
    }

   
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHPBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHPBar()
    {
        if (healthImage != null)
        {
            healthImage.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Destroy(gameObject); 
    }
    public void CheckAttackTurn(int currentTurn)
    {
        if (currentTurn % attackInterval == 0)
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("Enemyの攻撃！");
    }
}
