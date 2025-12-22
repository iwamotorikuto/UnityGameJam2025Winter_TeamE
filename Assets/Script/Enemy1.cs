using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{
    public Image healthImage;
    public int maxHealth = 100;
    public int currentHealth;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    damage(10);
        //}
        //if (Input.GetMouseButtonDown(1))
        //{
        //    heal(5);
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //当たったのがプレイヤー
        if (other.gameObject.CompareTag("Player"))
        {

            damage(10);
        }
    }

    void Damage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    // ダメージを受ける処理
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // HP0のときの処理
    void Die()
    {
        Destroy(healthImage.gameObject);

        Destroy(gameObject);
    }

    public void damage(int damage)
    {
        currentHealth -= damage;
        healthImage.fillAmount = (float)currentHealth / maxHealth;
    }

    public void heal(int heal)
    {
        currentHealth += heal;
        healthImage.fillAmount = (float)currentHealth / maxHealth;
    }
}
