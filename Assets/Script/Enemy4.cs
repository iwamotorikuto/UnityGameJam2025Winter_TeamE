using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy4 : MonoBehaviour
{
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

    // ダメージ処理はこれ1本だけ
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
        Destroy(gameObject); // HPバーが子なら一緒に消える
    }
}

